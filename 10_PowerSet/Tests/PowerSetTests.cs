using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PowerSetTests
    {

        [Test]
        public void Put_Test()
        {
            PowerSet<string> set = new PowerSet<string>();
            set.Put("John");
            set.Put("ADA");
            set.Put("Mole");
            Assert.That(set.Size(), Is.EqualTo(3));
            set.Put("John");
            Assert.That(set.Size(), Is.EqualTo(3));
        }

        [Test]
        public void Remove_Test()
        {
            PowerSet<string> set = new PowerSet<string>();
            set.Put("John");
            set.Put("ADA");
            set.Put("Mole");
            Assert.That(set.Size(), Is.EqualTo(3));
            Assert.That(set.Remove("ADA"), Is.True);
            Assert.That(set.Remove("John"), Is.True);
            Assert.That(set.Remove("ADA"), Is.False);
            Assert.That(set.Remove("Mole"), Is.True);
            Assert.That(set.Size(), Is.EqualTo(0));
        }

        [Test]
        public void Remove_Empty()
        {
            PowerSet<string> set = new PowerSet<string>();
            Assert.That(set.Remove("ADA"), Is.False);
            Assert.That(set.Size(), Is.EqualTo(0));
        }

        [Test]
        public void Intersection_Test()
        {
            PowerSet<string> set1 = new PowerSet<string>();
            set1.Put("John");
            set1.Put("ADA");
            set1.Put("Mole");
            set1.Put("Barry");
            set1.Put("Jill");
            PowerSet<string> set2 = new PowerSet<string>();
            set2.Put("Chris");
            set2.Put("ADA");
            set2.Put("Walker");
            set2.Put("Barry");
            set2.Put("Jill");
            PowerSet<string> set3 = set1.Intersection(set2);
            Assert.That(set3.Size(), Is.EqualTo(3));
            Assert.That(set3.Get("Barry"), Is.True);
            Assert.That(set3.Get("ADA"), Is.True);
            Assert.That(set3.Get("Jill"), Is.True);
            Assert.That(set3.Get("John"), Is.False);
            Assert.That(set3.Get("Chris"), Is.False);
            Assert.That(set3.Get("Walker"), Is.False);
            Assert.That(set3.Get("Mole"), Is.False);
        }

        [Test]
        public void Intersection_Empty()
        {
            PowerSet<string> set1 = new PowerSet<string>();
            set1.Put("John");
            set1.Put("ADA");
            set1.Put("Mole");
            set1.Put("Barry");
            set1.Put("Jill");
            PowerSet<string> set2 = new PowerSet<string>();
            set2.Put("Chris");
            set2.Put("Walker");
            PowerSet<string> set3 = set1.Intersection(set2);
            Assert.That(set3.Size(), Is.EqualTo(0));
            Assert.That(set3.Get("Barry"), Is.False);
            Assert.That(set3.Get("ADA"), Is.False);
            Assert.That(set3.Get("Jill"), Is.False);
            Assert.That(set3.Get("John"), Is.False);
            Assert.That(set3.Get("Chris"), Is.False);
            Assert.That(set3.Get("Walker"), Is.False);
            Assert.That(set3.Get("Mole"), Is.False);
        }

        [Test]
        public void Union_Test()
        {
            PowerSet<string> set1 = new PowerSet<string>();
            set1.Put("John");
            set1.Put("ADA");
            set1.Put("Mole");
            set1.Put("Barry");
            set1.Put("Chris");
            set1.Put("Jill");
            PowerSet<string> set2 = new PowerSet<string>();
            set2.Put("Chris");
            set2.Put("Walker");
            set1.Put("Barry");

            PowerSet<string> set3 = set1.Union(set2);
            Assert.That(set3.Size(), Is.EqualTo(7));
            Assert.That(set3.Get("Barry"), Is.True);
            Assert.That(set3.Get("ADA"), Is.True);
            Assert.That(set3.Get("Jill"), Is.True);
            Assert.That(set3.Get("John"), Is.True);
            Assert.That(set3.Get("Chris"), Is.True);
            Assert.That(set3.Get("Walker"), Is.True);
            Assert.That(set3.Get("Mole"), Is.True);
        }

        [Test]
        public void Union_FirstEmpty()
        {
            PowerSet<string> set1 = new PowerSet<string>();
            PowerSet<string> set2 = new PowerSet<string>();
            set2.Put("Chris");
            set2.Put("Walker");

            PowerSet<string> set3 = set1.Union(set2);
            Assert.That(set3.Size(), Is.EqualTo(2));
            Assert.That(set3.Get("John"), Is.False);
            Assert.That(set3.Get("ADA"), Is.False);
            Assert.That(set3.Get("Mole"), Is.False);
            Assert.That(set3.Get("Chris"), Is.True);
            Assert.That(set3.Get("Walker"), Is.True);
        }

        [Test]
        public void Difference_Test()
        {
            PowerSet<string> set1 = new PowerSet<string>();
            set1.Put("Chris");
            set1.Put("Tyrant");
            set1.Put("Barry");
            PowerSet<string> set2 = new PowerSet<string>();
            set2.Put("Barry");
            set2.Put("John");
            set2.Put("ADA");
            set2.Put("Mole");
            set2.Put("Barry");
            set2.Put("Chris");
            set2.Put("Jill");

            PowerSet<string> set3 = set1.Difference(set2);
            Assert.That(set3.Size(), Is.EqualTo(1));
            Assert.That(set3.Get("Tyrant"), Is.True);
        }

        [Test]
        public void Difference_Empty()
        {
            PowerSet<string> set1 = new PowerSet<string>();
            set1.Put("Chris");
            set1.Put("John");
            set1.Put("Barry");
            PowerSet<string> set2 = new PowerSet<string>();
            set2.Put("Barry");
            set2.Put("John");
            set2.Put("ADA");
            set2.Put("Mole");
            set2.Put("Barry");
            set2.Put("Chris");
            set2.Put("Jill");

            PowerSet<string> set3 = set1.Difference(set2);
            Assert.That(set3.Size(), Is.EqualTo(0));
        }

        [Test]
        public void IsSubset_FalseBySize()
        {
            PowerSet<string> set1 = new PowerSet<string>();
            set1.Put("Chris");
            set1.Put("John");
            set1.Put("Barry");
            PowerSet<string> set2 = new PowerSet<string>();
            set2.Put("Barry");
            set2.Put("John");
            set2.Put("ADA");
            set2.Put("Mole");
            set2.Put("Barry");
            set2.Put("Chris");
            set2.Put("Jill");
            Assert.That(set1.IsSubset(set2), Is.False);
        }

        [Test]
        public void IsSubset_FalseByValues()
        {
            PowerSet<string> set1 = new PowerSet<string>();
            set1.Put("Chris");
            set1.Put("John");
            set1.Put("Barry");
            PowerSet<string> set2 = new PowerSet<string>();
            set2.Put("Barry");
            set2.Put("Chris");
            set2.Put("Jill");
            Assert.That(set1.IsSubset(set2), Is.False);
        }

        [Test]
        public void IsSubset_True()
        {
            PowerSet<string> set1 = new PowerSet<string>();
            set1.Put("Chris");
            set1.Put("Jill");
            set1.Put("Barry");
            set1.Put("Mole");
            set1.Put("ADA");
            PowerSet<string> set2 = new PowerSet<string>();
            set2.Put("Barry");
            set2.Put("Chris");
            set2.Put("Jill");
            Assert.That(set1.IsSubset(set2), Is.True);
        }
    }
}
