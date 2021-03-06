using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RelationLibrary;
using Attribute = RelationLibrary.Attribute;
using Microsoft.QualityTools.Testing.Fakes;

namespace RelationLibraryTest {
    [TestClass]
    public class RelationTest {
        Relation rel;
        Attribute A, B, C, D, E, F;

        [TestInitialize]
        public void TestInitialize() {
            A = new Attribute("A");
            B = new Attribute("B");
            C = new Attribute("C");
            D = new Attribute("D");
            E = new Attribute("E");
            F = new Attribute("F");
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
            Assert.AreEqual(new Attribute("A"), new Attribute("A"));
            Assert.AreEqual(B.DependsOn(C, D), B.DependsOn(C, D));
            Assert.AreEqual(B.DependsOn(C, D).GetHashCode(), B.DependsOn(C, D).GetHashCode());
            Assert.AreEqual(B.DependsOn(C, D), B.DependsOn(D, C));
            Assert.IsTrue(Utilities.CreateSet(A, B, C).SetEquals(Utilities.CreateSet(B, A, C)));
        }

        [TestMethod]
        public void GetCandidateKeyTest1() {
            var realCK = Utilities.CreateSet(A, D);
            Relation rel2;
            var attributes = Utilities.CreateSet(A, B, C, D);
            var fds = new HashSet<FunctionalDependency>();
            fds.Add(C.DependsOn(A));
            fds.Add(D.DependsOn(B));
            fds.Add(B.DependsOn(D, A));
            rel2 = new Relation(attributes, fds);
            Assert.IsTrue(realCK.SetEquals(rel2.GetCandidateKey()));
        }

        [TestMethod]
        public void GetCandidateKeyTest2() {
            var realCK = Utilities.CreateSet(A, E);
            Assert.IsTrue(realCK.SetEquals(rel.GetCandidateKey()));
        }
    }
}
