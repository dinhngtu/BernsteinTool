using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    public static class LingTompaKameda {
        // Here be dragons!
        // READ THE PAPER! http://www.comp.nus.edu.sg/~lingtw/papers/tods81.LTK.pdf

        #region Preparatory algorithm

        /// <summary>
        /// Step 1.1
        /// </summary>
        /// <param name="rel"></param>
        /// <returns></returns>
        public static Relation EliminateExtras(Relation rel) {
            var ret = new Relation(rel.Attributes, rel.FDs);
            ret.FDs = new HashSet<FunctionalDependency>(ret.FDs.Select(fd => ret.GetMinimalFD(fd)));
            ret.FDs = ret.GetMinimalCovering();
            return ret;
        }

        /// <summary>
        /// Step 1.2 + 1.3
        /// </summary>
        /// <param name="rel"></param>
        /// <returns></returns>
        public static HashSet<Relation> ConstructRelations(Relation rel) {
            var relations = new HashSet<Relation>();
            var keygroups = rel.FDs.GroupBy(fd => fd.Determinants, new ClosureEqualityComparer(rel));
            foreach (var group in keygroups) {
                relations.Add(new Relation(Relation.GetAttributeSet(group), new HashSet<FunctionalDependency>(group)));
            }
            return relations;
        }

        /// <summary>
        /// Step 1.4
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static HashSet<Relation> AugmentRelations(Relation reference, HashSet<Relation> input) {
            var ret = new HashSet<Relation>(input);
            if (!ret.Any(r => reference.IsSuperkey(r.Attributes))) {
                var key = reference.GetCandidateKey();
                var crel = new Relation(key, reference.GetFDSubset(key));
                ret.Add(crel);
            }
            return ret;
        }

        #endregion

        #region Superfluous test

        /// <summary>
        /// Step 2
        /// </summary>
        public static Tuple<bool, HashSet<HashSet<Attribute>>> IsAttributeSuperfluous(Relation reference, HashSet<Relation> relations, Relation target, Attribute attr) {
            var none = Tuple.Create<bool, HashSet<HashSet<Attribute>>>(false, null);

            if (!target.Attributes.Contains(attr)) {
                throw new ArgumentException("target relation does not contain requested attribute");
            }
            if (!relations.Contains(target)) {
                throw new ArgumentException("relation set does not contain target relation");
            }

            var Ki = new HashSet<HashSet<Attribute>>(target.FDs.Select(fd => fd.Determinants), HashSet<Attribute>.CreateSetComparer());
            if (Ki.Count == 1 && Ki.Single().SetEquals(target.Attributes)) {
                return none;
            }

            var Ki_prime = new HashSet<HashSet<Attribute>>(Ki.Where(x => !x.Contains(attr)), HashSet<Attribute>.CreateSetComparer());
            if (!Ki_prime.Any()) {
                return none;
            }

            var Gi = new HashSet<FunctionalDependency>();
            foreach (var K in Ki) {
                Gi.UnionWith(FunctionalDependency.Decompose(K, target.Attributes.GetExceptedMany(K)));
            }
            var Gi_R = new Relation(Relation.GetAttributeSet(Gi), Gi);

            var Gi_prime = new HashSet<FunctionalDependency>();
            foreach (var G in relations.Where(r => r != target)) {
                Gi_prime.UnionWith(G.FDs);
            }
            var exceptAttr = target.FDs.Where(fd => !fd.Determinants.Contains(attr));
            var Ai_prime = target.Attributes.GetExcepted(attr);
            foreach (var fd in exceptAttr) {
                var K = fd.Determinants;
                Gi_prime.UnionWith(FunctionalDependency.Decompose(K, Ai_prime.GetExceptedMany(K)));
            }
            var Gi_primeR = new Relation(Relation.GetAttributeSet(Gi_prime), Gi_prime);

            // check restorability
            foreach (var K in Ki_prime) {
                if (!Gi_primeR.GetClosure(K).Contains(attr)) {
                    return none;
                }
            }

            // B is restorable, check non-essentiality
            foreach (var K in Ki.Except(Ki_prime)) {
                var M = Gi_primeR.GetClosure(K);
                if (target.Attributes.SetEquals(M)) {
                    return Tuple.Create(true, Ki_prime);
                }

                var M_test = new HashSet<Attribute>(M);
                M_test.IntersectWith(target.Attributes);
                M_test.Remove(attr);
                // M_test = (M intersect Ai) - B
                if (!reference.GetClosure(M_test).IsSupersetOf(target.Attributes)) {
                    return none;
                }

                // add key of Ri in M_test to Ki_prime
                // only consider attributes found in FDs, not "dangling" attributes
                var attrCover = new HashSet<Attribute>();
                foreach (var k in Ki_prime) {
                    attrCover.UnionWith(k);
                }
                attrCover.IntersectWith(M_test);
                //Ki_prime.Clear();
                Ki_prime.Add(target.MinimizeAttributeSet(attrCover));
            }

            return Tuple.Create(true, Ki_prime);
        }

        public static List<Tuple<Relation, HashSet<Attribute>>> DeletionNormalization(Relation reference, HashSet<Relation> relations) {
            var ret = new List<Tuple<Relation, HashSet<Attribute>>>();
            foreach (Relation r in relations) {
                var key = new HashSet<Attribute>();
                foreach (var det in r.FDs.Select(fd => fd.Determinants)) {
                    key.UnionWith(det);
                }
                var candidate = Tuple.Create(r, key);
                foreach (Attribute a in r.Attributes) {
                    var test = IsAttributeSuperfluous(reference, relations, r, a);
                    if (test.Item1) {
                        var k = new HashSet<Attribute>();
                        foreach (var i in test.Item2) {
                            k.UnionWith(i);
                        }
                        candidate = Tuple.Create(r.GetExcepted(a), r.MinimizeAttributeSet(k));
                    }
                }
                ret.Add(candidate);
            }
            return ret;
        }

        #endregion
    }
}
