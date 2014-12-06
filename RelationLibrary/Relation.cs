using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    public class Relation {
        public HashSet<Attribute> Attributes { get; set; }

        public HashSet<FunctionalDependency> FDs { get; set; }

        public Relation(HashSet<Attribute> attributes, IEnumerable<FunctionalDependency> fds) {
            this.Attributes = attributes;
            this.FDs = new HashSet<FunctionalDependency>(fds);
        }

        public Relation(HashSet<Attribute> attrs, params FunctionalDependency[] fds) {
            this.Attributes = attrs;
            this.FDs = new HashSet<FunctionalDependency>(fds);
        }

        HashSet<Attribute> ClosureLoop(HashSet<FunctionalDependency> fds, HashSet<Attribute> attrs) {
            foreach (var fd in fds) {
                if (fd.Determinants.IsSubsetOf(attrs)) {
                    var a_prime = new HashSet<Attribute>(attrs);
                    a_prime.Add(fd.Dependent);
                    return ClosureLoop(fds.GetExcepted(fd), a_prime);
                }
            }
            return attrs;
        }

        public HashSet<Attribute> GetClosure(HashSet<Attribute> determinants) {
            return ClosureLoop(this.FDs, determinants);
        }

        public FunctionalDependency GetMinimalFD(FunctionalDependency fd) {
            var det = fd.Determinants;
            if (det.Count == 1) {
                return fd;
            }
            var refClosure = GetClosure(det);
            foreach (var attr in det) {
                var testdets = det.GetExcepted(attr);
                if (refClosure.SetEquals(GetClosure(testdets))) {
                    return GetMinimalFD(fd.Dependent.DependsOn(testdets));
                }
            }
            return fd.Dependent.DependsOn(det);
        }

        HashSet<FunctionalDependency> MinimalCoveringLoop(HashSet<FunctionalDependency> fds) {
            foreach (var fd in fds) {
                var excluded = fds.GetExcepted(fd);
                var closure = ClosureLoop(excluded, fd.Determinants);
                if (closure.Contains(fd.Dependent)) {
                    return MinimalCoveringLoop(excluded);
                }
            }
            return fds;
        }

        public HashSet<FunctionalDependency> GetMinimalCovering() {
            return MinimalCoveringLoop(this.FDs);
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
            this.FDs = this.GetMinimalCovering();
            return MinimizeAttributeSet(this.Attributes);
        }

        public HashSet<Attribute> MinimizeAttributeSet(HashSet<Attribute> input) {
            var inputClosure = GetClosure(input);
            foreach (var a in input) {
                var testset = input.GetExcepted(a);
                if (GetClosure(testset).SetEquals(inputClosure)) {
                    return MinimizeAttributeSet(testset);
                }
            }
            return input;
        }

        public bool IsSuperkey(HashSet<Attribute> attrs) {
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

        public Relation GetExcepted(params Attribute[] exclude) {
            return new Relation(Attributes.GetExceptedMany(exclude), FDs.Where(fd => exclude.All(a => !fd.HasAttribute(a))));
        }

        [Obsolete]
        public HashSet<Relation> CreateRelations() {
            var relations = new HashSet<Relation>();
            var keygroups = FDs.GroupBy(fd => fd.Determinants, HashSet<Attribute>.CreateSetComparer());
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
            if (addCrel && !dedup.Any(r => IsSuperkey(r.Attributes))) {
                dedup.Add(crel);
            }
            return dedup;
        }

        public override string ToString() {
            return string.Format("({0}): {{ {1} }}", string.Join("", Attributes), string.Join(", ", FDs.Select(fd => fd.ToString())));
        }
    }
}
