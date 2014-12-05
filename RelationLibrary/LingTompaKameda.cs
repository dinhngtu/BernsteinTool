using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    public static class LingTompaKameda {
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
        public static Tuple<bool, IEnumerable<HashSet<Attribute>>> IsAttributeSuperfluous(HashSet<Relation> relations, Relation target, Attribute attr) {
            if (!target.Attributes.Contains(attr)) {
                throw new ArgumentException("Attribute not in target");
            }
            if (!relations.Contains(target)) {
                throw new ArgumentException("Target not in relation set");
            }

            var none = new Tuple<bool, IEnumerable<HashSet<Attribute>>>(false, null);

            var Ki = new HashSet<HashSet<Attribute>>(target.FDs.Select(fd => fd.Determinants), HashSet<Attribute>.CreateSetComparer());
            if (Ki.Single().SetEquals(target.Attributes)) {
                return none;
            }

            var Ki_prime = target.FDs.Select(fd => fd.Determinants).Where(det => !det.Contains(attr));
            if (!Ki_prime.Any()) {
                return none;
            }

            var exceptAttr = target.FDs.Where(fd => !fd.HasAttribute(attr));
            var Gi_prime = new HashSet<FunctionalDependency>();
            foreach (var fd in exceptAttr) {
                var K = fd.Determinants;
                Gi_prime.UnionWith(FunctionalDependency.Decompose(K, target.Attributes.GetExceptedMany(K)));
            }
            var Gi_primeR = new Relation(Relation.GetAttributeSet(Gi_prime), Gi_prime);

            foreach (var K in Ki_prime) {
                if (!Gi_primeR.GetClosure(K).Contains(attr)) {
                    return none;
                }
            }

            foreach (var K in Ki.Except(Ki_prime)) {
                var M = Gi_primeR.GetClosure(K);
                // TODO
            }

            return none;
        }

        #endregion
    }
}
