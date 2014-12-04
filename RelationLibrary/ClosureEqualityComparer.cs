using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    public class ClosureEqualityComparer : EqualityComparer<HashSet<Attribute>> {
        public Relation Relation { get; private set; }

        public ClosureEqualityComparer(Relation reference) {
            this.Relation = reference;
        }

        public override bool Equals(HashSet<Attribute> x, HashSet<Attribute> y) {
            return Relation.GetClosure(x).IsSupersetOf(y) &&
                Relation.GetClosure(y).IsSupersetOf(x);
        }

        public override int GetHashCode(HashSet<Attribute> obj) {
            int acc = 0;
            foreach (var x in Relation.GetClosure(obj)) {
                acc |= x.GetHashCode();
            }
            return acc;
        }
    }
}
