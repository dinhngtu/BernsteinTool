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

        public FunctionalDependency EliminateExtraneousAttributes(FunctionalDependency fd) {
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

        public static HashSet<Attribute> GetAttributes(IEnumerable<FunctionalDependency> fds) {
            var attrs = new HashSet<Attribute>();
            foreach (var fd in fds) {
                attrs.Add(fd.Dependent);
                attrs.UnionWith(fd.Determinants);
            }
            return attrs;
        }

        public HashSet<Attribute> GetCandidateKey() {
            throw new NotImplementedException();
        }

        public HashSet<FunctionalDependency> GetFunctionalDependencies(HashSet<Attribute> attributes) {
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
            var keygroups = FDs.GroupBy(fd => fd.Determinants);
            foreach (var group in keygroups) {
                relations.Add(new Relation(GetAttributes(group), new HashSet<FunctionalDependency>(group)));
            }
            var key = this.GetCandidateKey();
            relations.Add(new Relation(key, GetFunctionalDependencies(key)));
            var dedup = new HashSet<Relation>();
            foreach (var rel in relations) {
                if (!relations.Any(r => rel.Attributes.IsSubsetOf(r.Attributes))) {
                    dedup.Add(rel);
                }
            }
            return dedup;
        }
    }
}
