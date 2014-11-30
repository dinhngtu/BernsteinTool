using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationLibrary {
    public class Attribute {
        public string Name { get; set; }

        public Attribute(string name) {
            this.Name = name;
        }

        public FunctionalDependency DependsOn(params Attribute[] determinants) {
            return new FunctionalDependency(new HashSet<Attribute>(determinants), this);
        }
    }
}
