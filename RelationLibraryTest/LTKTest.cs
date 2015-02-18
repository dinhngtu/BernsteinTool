using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RelationLibrary;
using Attribute = RelationLibrary.Attribute;
using System.Collections.Generic;

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

            Trace.WriteLine("#step 0");
            Trace.WriteLine(rel);

            var step1 = LingTompaKameda.EliminateExtras(rel);
            Trace.WriteLine("#step 1");
            Trace.WriteLine(step1);

            var step23 = LingTompaKameda.ConstructRelations(step1);
            Trace.WriteLine("#step 23");
            foreach (var r in step23) {
                Trace.WriteLine(r);
            }

            var step4 = LingTompaKameda.AugmentRelations(rel, step23);
            Trace.WriteLine("#step 4");
            foreach (var r in step4) {
                Trace.WriteLine(r);
            }
            Trace.WriteLine(step4.First());

            Trace.WriteLine("#LTK test");
            Trace.WriteLine(LingTompaKameda.IsAttributeSuperfluous(rel, step4, step4.First(), A).Item1);
            Trace.WriteLine(LingTompaKameda.IsAttributeSuperfluous(rel, step4, step4.First(), B).Item1);
            Trace.WriteLine(LingTompaKameda.IsAttributeSuperfluous(rel, step4, step4.First(), C).Item1);
            Trace.WriteLine(LingTompaKameda.IsAttributeSuperfluous(rel, step4, step4.First(), D).Item1);
            Trace.WriteLine(LingTompaKameda.IsAttributeSuperfluous(rel, step4, step4.First(), E).Item1);
            Trace.WriteLine(LingTompaKameda.IsAttributeSuperfluous(rel, step4, step4.First(), F).Item1);
        }

        public bool IsRelationAttributeSetEqual(Relation r1, Relation r2) {
            return r1.Attributes.SetEquals(r2.Attributes);
        }

        [TestMethod]
        public void LTKFullTest() {
            // adapted from NUS CS4221 LTK tutorial, pg. 15
            var SN = new Attribute("S#");
            var ICN = new Attribute("IC#");
            var Name = new Attribute("Name");
            var CN = new Attribute("C#");
            var Cname = new Attribute("Cname");
            var Desc = new Attribute("Desc");
            var Mark = new Attribute("Mark");
            var Year = new Attribute("Year");

            var rel = new Relation(Utilities.CreateSet(SN, ICN, Name, CN, Cname, Desc, Mark, Year),
                ICN.DependsOn(SN), Name.DependsOn(SN),
                SN.DependsOn(ICN),
                Cname.DependsOn(CN), Desc.DependsOn(CN),
                CN.DependsOn(Cname),
                Mark.DependsOn(SN, CN),
                Year.DependsOn(ICN, Cname));

            var rel11 = LingTompaKameda.EliminateExtras(rel);
            var rels13 = LingTompaKameda.ConstructRelations(rel11);
            var rels14 = LingTompaKameda.AugmentRelations(rel, rels13);

            var pr1 = new Relation(Utilities.CreateSet(SN, ICN, Name));
            var pr2 = new Relation(Utilities.CreateSet(CN, Cname, Desc));
            var pr3 = new Relation(Utilities.CreateSet(SN, CN, ICN, Cname, Mark, Year));
            var preparatory_expected = Utilities.CreateSet(pr1, pr2, pr3);

            Assert.IsTrue(rels14.Count == 3);
            Assert.IsTrue(rels14.Any(r => IsRelationAttributeSetEqual(r, pr1)));
            Assert.IsTrue(rels14.Any(r => IsRelationAttributeSetEqual(r, pr2)));
            Assert.IsTrue(rels14.Any(r => IsRelationAttributeSetEqual(r, pr3)));

            var rels2 = LingTompaKameda.DeletionNormalization(rel, rels14);

            var lr1 = new Relation(Utilities.CreateSet(SN, ICN, Name));
            var lr2 = new Relation(Utilities.CreateSet(CN, Cname, Desc));
            var lr31 = new Relation(Utilities.CreateSet(ICN, Cname, Mark, Year));
            var lr32 = new Relation(Utilities.CreateSet(SN, Cname, Mark, Year));
            var lr33 = new Relation(Utilities.CreateSet(CN, ICN, Mark, Year));
            var lr34 = new Relation(Utilities.CreateSet(SN, CN, Mark, Year));

            var k1 = Utilities.CreateSet(SN, ICN);
            var k2 = Utilities.CreateSet(CN, Cname);
            var k31 = Utilities.CreateSet(ICN, Cname);
            var k32 = Utilities.CreateSet(SN, Cname);
            var k33 = Utilities.CreateSet(CN, ICN);
            var k34 = Utilities.CreateSet(SN, CN);

            Assert.IsTrue(rels2.Count == 3);

            var rels2r = rels2.Select(t => t.Item1);
            Assert.IsTrue(rels2r.Any(r => IsRelationAttributeSetEqual(r, lr1)));
            Assert.IsTrue(rels2r.Any(r => IsRelationAttributeSetEqual(r, lr2)));

            var has31 = rels2r.Any(r => IsRelationAttributeSetEqual(r, lr31));
            var has32 = rels2r.Any(r => IsRelationAttributeSetEqual(r, lr32));
            var has33 = rels2r.Any(r => IsRelationAttributeSetEqual(r, lr33));
            var has34 = rels2r.Any(r => IsRelationAttributeSetEqual(r, lr34));
            Assert.IsTrue(Utilities.OnlyOne(has31, has32, has33, has34));

            var rels2k = rels2.Select(t => t.Item2);
            Assert.IsTrue(rels2k.Any(k => k.SetEquals(k1)));
            Assert.IsTrue(rels2k.Any(k => k.SetEquals(k2)));

            var gk31 = rels2k.Any(k => k.SetEquals(k31));
            var gk32 = rels2k.Any(k => k.SetEquals(k32));
            var gk33 = rels2k.Any(k => k.SetEquals(k33));
            var gk34 = rels2k.Any(k => k.SetEquals(k34));
            Assert.IsTrue(Utilities.OnlyOne(gk31, gk32, gk33, gk34));
        }
    }
}
