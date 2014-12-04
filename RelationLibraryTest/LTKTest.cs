using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RelationLibrary;
using Attribute = RelationLibrary.Attribute;

namespace RelationLibraryTest {
    [TestClass]
    public class LTKTest {
        [TestMethod]
        public void LTKPreparatoryTest() {
            Attribute A, B, C, D, E, F;
            A = new Attribute("A");
            B = new Attribute("B");
            C = new Attribute("C");
            D = new Attribute("D");
            E = new Attribute("E");
            F = new Attribute("F");
            var rel = new Relation(Utilities.CreateSet(A, B, C, D, E, F),
                B.DependsOn(A, D), C.DependsOn(B), D.DependsOn(C), E.DependsOn(A, B), F.DependsOn(A, C));

            Trace.WriteLine("step 0");
            Trace.WriteLine(rel);

            var step1 = LingTompaKameda.EliminateExtras(rel);
            Trace.WriteLine("step 1");
            Trace.WriteLine(step1);

            var step23 = LingTompaKameda.ConstructRelations(step1);
            Trace.WriteLine("step 23");
            foreach (var r in step23) {
                Trace.WriteLine(r);
            }

            var step4 = LingTompaKameda.AugmentRelations(rel, step23);
            Trace.WriteLine("step 4");
            foreach (var r in step4) {
                Trace.WriteLine(r);
            }
        }
    }
}
