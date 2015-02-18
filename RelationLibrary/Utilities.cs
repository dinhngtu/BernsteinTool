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

        public static HashSet<T> GetExceptedMany<T>(this HashSet<T> set, IEnumerable<T> values) {
            HashSet<T> ret = new HashSet<T>(set);
            ret.ExceptWith(values);
            return ret;
        }

        public static HashSet<T> GetUnioned<T>(this HashSet<T> set, T value) {
            HashSet<T> ret = new HashSet<T>(set);
            ret.Add(value);
            return ret;
        }

        public static HashSet<T> CreateSet<T>(params T[] items) {
            return new HashSet<T>(items);
        }

        public static bool OnlyOne(params bool[] values) {
            bool one = false;
            bool two = false;
            foreach (var v in values) {
                if (v) {
                    if (one) {
                        two = true;
                    }
                    one = true;
                }
            }
            return (one && !two);
        }
    }
}
