using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    public class Relation {
        public HashSet<Attribute> Attributes { get; set; }

        public HashSet<FunctionalDependency> FDs { get; set; }

        public Relation(HashSet<Attribute> attributes, HashSet<FunctionalDependency> fds) {
            this.Attributes = attributes;
            this.FDs = fds;
        }

        public Relation(HashSet<Attribute> attrs, params FunctionalDependency[] fds) {
            this.Attributes = attrs;
            this.FDs = new HashSet<FunctionalDependency>(fds);
        }

        public HashSet<Attribute> GetClosure(HashSet<Attribute> determinants) {
            var ret = new HashSet<Attribute>(determinants);
            var testfds = new HashSet<FunctionalDependency>(FDs);
            bool found;
            do {
                found = false;
                var fdToRemove = new HashSet<FunctionalDependency>();
                foreach (var fd in testfds) {
                    if (fd.Determinants.IsSubsetOf(ret)) {
                        found = true;
                        ret.Add(fd.Dependent);
                        fdToRemove.Add(fd);
                        break;
                    }
                }
                testfds.ExceptWith(fdToRemove);
            } while (found);
            return ret;
        }

        public FunctionalDependency GetMinimalFD(FunctionalDependency fd) {
            if (fd.Determinants.Count == 1) {
                return fd;
            }
            var dets = new HashSet<Attribute>(fd.Determinants);
            var refClosure = GetClosure(fd.Determinants);
            bool found;
            do {
                found = false;
                var attrToRemove = new HashSet<Attribute>();
                foreach (var attr in dets) {
                    var testdets = dets.GetExcepted(attr);
                    if (refClosure.SetEquals(GetClosure(testdets))) {
                        found = true;
                        attrToRemove.Add(attr);
                        break;
                    }
                }
                dets.ExceptWith(attrToRemove);
            } while (found);
            return new FunctionalDependency(dets, fd.Dependent);
        }

        public HashSet<FunctionalDependency> GetMinimalCovering() {
            var testfds = new HashSet<FunctionalDependency>(FDs);
            bool found;
            do {
                found = false;
                var fdToRemove = new HashSet<FunctionalDependency>();
                foreach (var fd in testfds) {
                    var excluded = testfds.GetExcepted(fd);
                    var relExcluded = new Relation(this.Attributes, excluded);
                    var closure = relExcluded.GetClosure(fd.Determinants);
                    if (closure.Contains(fd.Dependent)) {
                        found = true;
                        fdToRemove.Add(fd);
                        break;
                    }
                }
                testfds.ExceptWith(fdToRemove);
            } while (found);
            return testfds;
        }

        public static HashSet<Attribute> GetAttributeSet(IEnumerable<FunctionalDependency> fds) {
            var attrs = new HashSet<Attribute>();
            foreach (var fd in fds) {
                attrs.Add(fd.Dependent);
                attrs.UnionWith(fd.Determinants);
            }
            return attrs;
        }

        public HashSet<Attribute> GetCandidateKey() {
            //throw new NotImplementedException();
            this.FDs = this.GetMinimalCovering();
            return GetMinimalCandidateKey(this.Attributes, this.Attributes);
            //var optimalKeys = new HashSet<Attribute>();
            //var possibleKeys = new HashSet<Attribute>();
            //var notKeys = new HashSet<Attribute>();

        }

        public HashSet<Attribute> GetMinimalCandidateKey(HashSet<Attribute> currentAttrs, HashSet<Attribute> minCK) {
            var currentClosure = this.GetClosure(currentAttrs);
            if (this.Attributes.SetEquals(currentClosure)
                && currentAttrs.Count <= minCK.Count) minCK = currentAttrs;
            else return minCK;
            if (currentAttrs.Count == 1) return minCK;
            foreach (var att in currentAttrs) {
                var subset = new HashSet<Attribute>(currentAttrs);
                subset.Remove(att);
                var subsetMinCK = GetMinimalCandidateKey(subset, minCK);
                if (minCK.Count > subsetMinCK.Count) {
                    minCK = subsetMinCK;
                }
            }
            return minCK;
        }

        public bool IsCandidateKey(HashSet<Attribute> attrs) {
            return this.Attributes.SetEquals(GetClosure(attrs));
        }

        public HashSet<FunctionalDependency> GetFDSubset(HashSet<Attribute> attributes) {
            var fds = new HashSet<FunctionalDependency>();
            foreach (var fd in this.FDs) {
                if (attributes.Contains(fd.Dependent) && attributes.IsSupersetOf(fd.Determinants)) {
                    fds.Add(fd);
                }
            }
            return fds;
        }

        public HashSet<Relation> CreateRelations() {
            var relations = new HashSet<Relation>();
            var keygroups = FDs.GroupBy(fd => fd.Determinants, new HashSetEqualityComparer<Attribute>());
            foreach (var group in keygroups) {
                relations.Add(new Relation(GetAttributeSet(group), new HashSet<FunctionalDependency>(group)));
            }
            var key = this.GetCandidateKey();
            var crel = new Relation(key, GetFDSubset(key));
            var dedup = new HashSet<Relation>();
            var addCrel = true;
            foreach (var rel in relations) {
                if (!rel.Attributes.IsSubsetOf(crel.Attributes) &&
                    !relations.Any(r => r != rel && r.Attributes.IsSupersetOf(rel.Attributes))) {
                    if (crel.Attributes.IsProperSubsetOf(rel.Attributes)) {
                        addCrel = false;
                    }
                    dedup.Add(rel);
                }
            }
            if (addCrel && !dedup.Any(r => IsCandidateKey(r.Attributes))) {
                dedup.Add(crel);
            }
            return dedup;
        }

        public override string ToString() {
            return string.Format("({0}): {{ {1} }}", string.Join("", Attributes), string.Join(", ", FDs.Select(fd => fd.ToString())));
        }
    }
}
