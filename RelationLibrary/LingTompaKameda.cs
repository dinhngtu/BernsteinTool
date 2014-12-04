using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    public static class LingTompaKameda {
        #region Preparatory algorithm

        /// <summary>
        /// Step 1
        /// </summary>
        /// <param name="rel"></param>
        /// <returns></returns>
        public static Relation EliminateExtras(Relation rel) {
            var ret = new Relation(rel.Attributes, rel.FDs);
            ret.FDs = new HashSet<FunctionalDependency>(ret.FDs.Select(fd => ret.GetMinimalFD(fd)));
            ret.FDs = ret.GetMinimalCovering();
            return ret;
        }

        /// <summary>
        /// Step 2 + 3
        /// </summary>
        /// <param name="rel"></param>
        /// <returns></returns>
        public static HashSet<Relation> ConstructRelations(Relation rel) {
            var relations = new HashSet<Relation>();
            var keygroups = rel.FDs.GroupBy(fd => fd.Determinants, new ClosureEqualityComparer(rel));
            foreach (var group in keygroups) {
                relations.Add(new Relation(Relation.GetAttributeSet(group), new HashSet<FunctionalDependency>(group)));
            }
            return relations;
        }

        /// <summary>
        /// Step 4
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static HashSet<Relation> AugmentRelations(Relation reference, HashSet<Relation> input) {
            var key = reference.GetCandidateKey();
            var crel = new Relation(key, reference.GetFDSubset(key));
            var ret = new HashSet<Relation>(input);
            foreach (var rel in input) {
                ret.Add(rel);
            }
            if (!ret.Any(r => reference.IsSuperkey(r.Attributes))) {
                ret.Add(crel);
            }
            return ret;
        }

        #endregion
    }
}
