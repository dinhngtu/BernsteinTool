using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    public static class Utilities {
        public static HashSet<T> GetExcepted<T>(this HashSet<T> set, T value) {
            HashSet<T> ret = new HashSet<T>(set);
            ret.Remove(value);
            return ret;
        }

        public static HashSet<T> CreateSet<T>(params T[] items) {
            return new HashSet<T>(items);
        }
    }
}
