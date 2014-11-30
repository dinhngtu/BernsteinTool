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

        public static HashSet<Attribute> GetClosure(HashSet<FunctionalDependency> fds, HashSet<Attribute> determinants) {
            var ret = new HashSet<Attribute>(determinants);
            var testfds = new HashSet<FunctionalDependency>(fds);
            bool found;
            do {
                found = false;
                var fdToRemove = new HashSet<FunctionalDependency>();
                foreach (var fd in testfds) {
                    if (fd.Determinants.IsSubsetOf(ret)) {
                        found = true;
                        ret.UnionWith(fd.Determinants);
                        fdToRemove.Add(fd);
                        break;
                    }
                }
                testfds.ExceptWith(fdToRemove);
            } while (found);
            return ret;
        }

        public HashSet<Attribute> GetClosure(HashSet<Attribute> determinants) {
            return GetClosure(this.FDs, determinants);
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
            var fds = new HashSet<FunctionalDependency>(FDs);
            bool found;
            do {
                found = false;
                var fdToRemove = new HashSet<FunctionalDependency>();
                foreach (var fd in fds) {
                    var refClosure = GetClosure(fd.Determinants);
                    var testfds = fds.GetExcepted(fd);
                    if (refClosure.Contains(fd.Dependent)) {
                        found = true;
                        fdToRemove.Add(fd);
                        break;
                    }
                }
                fds.ExceptWith(fdToRemove);
            } while (found);
            return fds;
        }
    }
}
