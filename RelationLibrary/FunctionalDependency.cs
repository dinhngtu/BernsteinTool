using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    public class FunctionalDependency {
        public HashSet<Attribute> Determinants { get; set; }

        // We normalize all FDs so that each FD only has one dependent attribute.
        public Attribute Dependent { get; set; }

        public FunctionalDependency(HashSet<Attribute> determinants, Attribute dependent) {
            this.Determinants = determinants;
            this.Dependent = dependent;
        }

        public static HashSet<FunctionalDependency> Decompose(HashSet<Attribute> determinants, HashSet<Attribute> dependents) {
            var ret = new HashSet<FunctionalDependency>();
            foreach (var dependent in dependents) {
                ret.Add(new FunctionalDependency(determinants, dependent));
            }
            return ret;
        }
    }
}
