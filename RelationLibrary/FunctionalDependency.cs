using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    class FunctionalDependency {
        public HashSet<Attribute> Determinants { get; set; }

        // we normalize dependencies so that each dependency only has one dependent attribute
        public Attribute Dependent { get; set; }
    }
}
