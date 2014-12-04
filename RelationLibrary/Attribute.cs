using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    public struct Attribute : IEquatable<Attribute> {
        public string Name;

        public Attribute(string name) {
            this.Name = name;
        }

        public FunctionalDependency DependsOn(params Attribute[] determinants) {
            return new FunctionalDependency(new HashSet<Attribute>(determinants), this);
        }

        public FunctionalDependency DependsOn(IEnumerable<Attribute> determinants) {
            return new FunctionalDependency(new HashSet<Attribute>(determinants), this);
        }

        public bool Equals(Attribute other) {
            return this.Name == other.Name;
        }

        public override bool Equals(Object other) {
            if (other is Attribute) {
                return this.Name == ((Attribute)other).Name;
            } else {
                return false;
            }
        }

        public override int GetHashCode() {
            return this.Name.GetHashCode();
        }

        public static bool operator ==(Attribute a, Attribute b) {
            return a.Equals(b);
        }

        public static bool operator !=(Attribute a, Attribute b) {
            return !a.Equals(b);
        }

        public override string ToString() {
            return this.Name;
        }
    }
}
