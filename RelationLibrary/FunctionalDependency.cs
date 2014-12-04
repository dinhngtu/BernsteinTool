using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    public struct FunctionalDependency : IEquatable<FunctionalDependency> {
        public HashSet<Attribute> Determinants;

        // We normalize all FDs so that each FD only has one dependent attribute.
        public Attribute Dependent;

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

        public bool Equals(FunctionalDependency other) {
            return this.Determinants.SetEquals(other.Determinants) && this.Dependent == other.Dependent;
        }

        public override bool Equals(Object other) {
            if (other is FunctionalDependency) {
                return this.Determinants.SetEquals(((FunctionalDependency)other).Determinants) &&
                    this.Dependent == ((FunctionalDependency)other).Dependent;
            } else {
                return false;
            }
        }

        public override int GetHashCode() {
            unchecked {
                int acc = 17;
                acc = ((acc << 5) - acc) ^ this.Dependent.GetHashCode();
                foreach (var x in this.Determinants) {
                    acc += x.GetHashCode();
                }
                return acc;
            }
        }

        public static bool operator ==(FunctionalDependency a, FunctionalDependency b) {
            return a.Equals(b);
        }

        public static bool operator !=(FunctionalDependency a, FunctionalDependency b) {
            return !a.Equals(b);
        }

        public override string ToString() {
            return string.Format("{0}->{1}", string.Join("", Determinants.Select(attr => attr.ToString())), Dependent.ToString());
        }
    }
}
