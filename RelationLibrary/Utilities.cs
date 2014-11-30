using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    static class Utilities {
        public static HashSet<T> GetExcepted<T>(this HashSet<T> set, T value) {
            HashSet<T> ret = new HashSet<T>(set);
            ret.Remove(value);
            return ret;
        }
    }
}
