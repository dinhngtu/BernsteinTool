using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    class HashSetEqualityComparer<T> : EqualityComparer<HashSet<T>> {
        public override bool Equals(HashSet<T> x, HashSet<T> y) {
            return x.SetEquals(y);
        }

        public override int GetHashCode(HashSet<T> obj) {
            int acc = 0;
            foreach (var x in obj) {
                acc |= x.GetHashCode();
            }
            return acc;
        }
    }
}
