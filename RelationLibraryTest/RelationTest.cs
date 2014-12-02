using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RelationLibrary;

namespace RelationLibraryTest {
    [TestClass]
    public class RelationTest {
        Relation rel;
        RelationLibrary.Attribute A, B, C, D, E, F;

        [TestInitialize]
        public void TestInitialize() {
            A = new RelationLibrary.Attribute("A");
            B = new RelationLibrary.Attribute("B");
            C = new RelationLibrary.Attribute("C");
            D = new RelationLibrary.Attribute("D");
            E = new RelationLibrary.Attribute("E");
            F = new RelationLibrary.Attribute("F");
            var attributes = Utilities.CreateSet(A, B, C, D, E, F);
            var fds = new HashSet<FunctionalDependency>();
            fds.Add(B.DependsOn(A));
            fds.Add(C.DependsOn(A));
            fds.Add(C.DependsOn(B));
            fds.Add(D.DependsOn(B));
            fds.Add(B.DependsOn(D));
            fds.Add(F.DependsOn(A, B, E));
            rel = new Relation(attributes, fds);
        }

        [TestMethod]
        public void GetClosureTest() {
            var closure = rel.GetClosure(Utilities.CreateSet(A, E));
            Assert.IsTrue(closure.SetEquals(Utilities.CreateSet(A, B, C, D, E, F)));
        }

        [TestMethod]
        public void GetMinimalFDTest() {
            //var fd = new FunctionalDependency(Utilities.CreateSet(A, E), C);
            var fd = F.DependsOn(A, E);
            Assert.IsTrue(fd == rel.GetMinimalFD(F.DependsOn(A, B, E)));
            //Assert.IsTrue(fd == rel.EliminateExtraneousAttributes(F.DependsOn(A, B, E)));
        }

        [TestMethod]
        public void GetMinimalCoveringTest() {
            var fds = new HashSet<FunctionalDependency>();
            var attributes = Utilities.CreateSet(A, B, C, D, E, F);
            fds.Add(B.DependsOn(A));
            fds.Add(C.DependsOn(B));
            fds.Add(D.DependsOn(B));
            fds.Add(B.DependsOn(D));
            fds.Add(F.DependsOn(A, B, E));
            var minimal_rel = new Relation(attributes, fds);
            Assert.IsTrue(fds.SetEquals(rel.GetMinimalCovering()));
        }

        [TestMethod]
        public void EqualTest() {
            Assert.AreEqual(new RelationLibrary.Attribute("A"), new RelationLibrary.Attribute("A"));
            Assert.AreEqual(B.DependsOn(C, D), B.DependsOn(C, D));
            Assert.AreEqual(B.DependsOn(C, D).GetHashCode(), B.DependsOn(C, D).GetHashCode());
            Assert.AreEqual(B.DependsOn(C, D), B.DependsOn(D, C));
            Assert.IsTrue(Utilities.CreateSet(A, B, C).SetEquals(Utilities.CreateSet(B, A, C)));
        }

        [TestMethod]
        public void CreateRelationsTest() {
            var eliminated = rel.FDs.Select(fd => rel.GetMinimalFD(fd));
            rel.FDs = new HashSet<FunctionalDependency>(eliminated);
            rel.FDs = rel.GetMinimalCovering();
            var finalResult = rel.CreateRelations();
            Assert.IsTrue(finalResult.SetEquals(Utilities.CreateSet(
                new Relation(Utilities.CreateSet(A, B), B.DependsOn(A)),
                new Relation(Utilities.CreateSet(B, D, C), C.DependsOn(B, D)),
                new Relation(Utilities.CreateSet(A, E, F), F.DependsOn(A, E))
                )));
        }
    }
}
