using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    class Relation {
        public HashSet<Attribute> Attributes { get; set; }

        public HashSet<FunctionalDependency> FDs { get; set; }

        public HashSet<Attribute> GetClosure(HashSet<Attribute> determinants) {
            var ret = new HashSet<Attribute>(determinants);
            var fds = new HashSet<FunctionalDependency>(FDs);
            bool cont = true;
            while (cont) {
                cont = false;
                var fdToRemove = new HashSet<FunctionalDependency>();
                foreach (var fd in FDs) {
                    if (fd.Determinants.IsSubsetOf(ret)) {
                        cont = true;
                        ret.UnionWith(fd.Determinants);
                        fdToRemove.Add(fd);
                    }
                }
                fds.ExceptWith(fdToRemove);
            }
            return ret;
        }
    }
}
