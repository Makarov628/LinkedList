using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class NativeDictionaryTests
    {
        [Test]
        public void IsKey_True()
        {
            NativeDictionary<int> dict = new NativeDictionary<int>(19);
            dict.slots[17] = "Magenta";
            dict.values[17] = 255_000_255;
            Assert.That(dict.IsKey("Magenta"), Is.True);
        }

        [Test]
        public void IsKey_False()
        {
            NativeDictionary<int> dict = new NativeDictionary<int>(19);
            dict.slots[10] = "Magenta";
            dict.values[10] = 255_000_255;
            Assert.That(dict.IsKey("Yellow"), Is.False);
        }

        [Test]
        public void Put_Test()
        {
            NativeDictionary<int> dict = new NativeDictionary<int>(19);
            dict.slots[17] = "Black";
            dict.values[17] = 0;
            Assert.That(dict.slots[17], Is.EqualTo("Black"));
            Assert.That(dict.values[17], Is.EqualTo(0));

            dict.Put("Magenta", 255_0_255);
            Assert.That(dict.slots[17], Is.EqualTo("Magenta"));
            Assert.That(dict.values[17], Is.EqualTo(255_0_255));
        }

        [Test]
        public void Get_Null()
        {
            NativeDictionary<int> dict = new NativeDictionary<int>(5);
            Assert.That(dict.Get("Yellow"), Is.Zero);
            Assert.That(dict.Get("Black"), Is.Zero);
        }

        [Test]
        public void Get_Test()
        {
            NativeDictionary<int> dict = new NativeDictionary<int>(3);
            dict.Put("Magenta", 255_0_255);
            dict.Put("Yellow", 255_255_000);
            dict.Put("Cian", 000_255_255);
            Assert.That(dict.Get("Yellow"), Is.EqualTo(255_255_000));
            Assert.That(dict.Get("Black"), Is.Zero);
        }

        [Test]
        public void Regression_Test()
        {
            NativeDictionary<int> dict = new NativeDictionary<int>(19);
            dict.Put("Magenta", 255_000_255);
            dict.Put("Yellow", 255_255_000);
            dict.Put("Cian", 000_255_255);

            Assert.That(dict.IsKey("Magenta"), Is.True);
            Assert.That(dict.IsKey("Yellow"), Is.True);
            Assert.That(dict.IsKey("Cian"), Is.True);
            Assert.That(dict.IsKey("Black"), Is.False);

            Assert.That(dict.Get("Magenta"), Is.EqualTo(255_000_255));
            Assert.That(dict.Get("Yellow"), Is.EqualTo(255_255_000));
            Assert.That(dict.Get("Cian"), Is.EqualTo(000_255_255));

            dict.Put("Magenta", 255_0_255);
            dict.Put("Yellow", 255_255_0);

            Assert.That(dict.Get("Magenta"), Is.EqualTo(255_0_255));
            Assert.That(dict.Get("Yellow"), Is.EqualTo(255_255_0));
            Assert.That(dict.Get("Cian"), Is.EqualTo(000_255_255));
        }
    }
}
