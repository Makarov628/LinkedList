using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class NativeCashTests
    {
        [Test]
        public void FillAndReplaceByMinHits()
        {
            var cash = new NativeCash<int>(10);

            var oneIndex = cash.SeekSlot("one");
            var twoIndex = cash.SeekSlot("two");
            var threeIndex = cash.SeekSlot("three");
            var fourIndex = cash.SeekSlot("four");
            var fiveIndex = cash.SeekSlot("five");
            var sixIndex = cash.SeekSlot("six");
            var sevenIndex = cash.SeekSlot("seven");
            var eightIndex = cash.SeekSlot("eight");
            var nineIndex = cash.SeekSlot("nine");
            var tenIndex = cash.SeekSlot("ten");

            Assert.That(oneIndex, Is.EqualTo(2));
            Assert.That(twoIndex, Is.EqualTo(6));
            Assert.That(threeIndex, Is.EqualTo(6));
            Assert.That(fourIndex, Is.EqualTo(4));
            Assert.That(fiveIndex, Is.EqualTo(6));
            Assert.That(sixIndex, Is.EqualTo(0));
            Assert.That(sevenIndex, Is.EqualTo(5));
            Assert.That(eightIndex, Is.EqualTo(9));
            Assert.That(nineIndex, Is.EqualTo(6));
            Assert.That(tenIndex, Is.EqualTo(7));

            oneIndex = cash.FindIndex(cash.HashFun("one"), null);
            Assert.That(oneIndex, Is.EqualTo(2));
            cash.Put("one", 1);
            Assert.That(cash.values[oneIndex], Is.EqualTo(cash.Get("one")));

            twoIndex = cash.FindIndex(cash.HashFun("two"), null);
            Assert.That(twoIndex, Is.EqualTo(6));
            cash.Put("two", 2);
            Assert.That(cash.values[twoIndex], Is.EqualTo(cash.Get("two")));

            threeIndex = cash.FindIndex(cash.HashFun("three"), null);
            Assert.That(threeIndex, Is.EqualTo(7));
            cash.Put("three", 3);
            Assert.That(cash.values[threeIndex], Is.EqualTo(cash.Get("three")));

            fourIndex = cash.FindIndex(cash.HashFun("four"), null);
            Assert.That(fourIndex, Is.EqualTo(4));
            cash.Put("four", 4);
            Assert.That(cash.values[fourIndex], Is.EqualTo(cash.Get("four")));

            fiveIndex = cash.FindIndex(cash.HashFun("five"), null);
            Assert.That(fiveIndex, Is.EqualTo(8));
            cash.Put("five", 5);
            Assert.That(cash.values[fiveIndex], Is.EqualTo(cash.Get("five")));

            sixIndex = cash.FindIndex(cash.HashFun("six"), null);
            Assert.That(sixIndex, Is.EqualTo(0));
            cash.Put("six", 6);
            Assert.That(cash.values[sixIndex], Is.EqualTo(cash.Get("six")));

            sevenIndex = cash.FindIndex(cash.HashFun("seven"), null);
            Assert.That(sevenIndex, Is.EqualTo(5));
            cash.Put("seven", 7);
            Assert.That(cash.values[sevenIndex], Is.EqualTo(cash.Get("seven")));

            eightIndex = cash.FindIndex(cash.HashFun("eight"), null);
            Assert.That(eightIndex, Is.EqualTo(9));
            cash.Put("eight", 8);
            Assert.That(cash.values[eightIndex], Is.EqualTo(cash.Get("eight")));

            nineIndex = cash.FindIndex(cash.HashFun("nine"), null);
            Assert.That(nineIndex, Is.EqualTo(1));
            cash.Put("nine", 9);
            Assert.That(cash.values[nineIndex], Is.EqualTo(cash.Get("nine")));

            tenIndex = cash.FindIndex(cash.HashFun("ten"), null);
            Assert.That(tenIndex, Is.EqualTo(3));
            cash.Put("ten", 10);
            Assert.That(cash.values[tenIndex], Is.EqualTo(cash.Get("ten")));

            cash.Get("one");
            cash.Get("two");
            cash.Get("three");
            cash.Get("four");
            cash.Get("five");
            cash.Get("six");
            cash.Get("seven");
            cash.Get("eight");
            cash.Get("ten");

            Assert.That(cash.hits[nineIndex], Is.EqualTo(1));
            Assert.That(cash.MinHintsIndex(), Is.EqualTo(nineIndex));

            var elevenIndex = cash.SeekSlot("eleven");
            Assert.That(elevenIndex, Is.EqualTo(nineIndex));
            cash.Put("eleven", 11);
            Assert.That(cash.values[elevenIndex], Is.EqualTo(cash.Get("eleven")));

            elevenIndex = cash.SeekSlot("eleven");
            Assert.That(elevenIndex, Is.EqualTo(nineIndex));
            cash.Put("eleven", 11);
            Assert.That(cash.values[elevenIndex], Is.EqualTo(cash.Get("eleven")));

        }

        [Test]
        public void isKey()
        {
            var cash = new NativeCash<int>(10);
            cash.Put("one", 1);

            Assert.That(cash.IsKey("one"), Is.True);
            Assert.That(cash.IsKey("ten"), Is.False);
        }

        [Test]
        public void Remove()
        {
            var cash = new NativeCash<int>(10);
            cash.Put("one", 1);
            cash.Put("one", 1);
            cash.Put("one", 1);
            cash.Put("one", 1);

            Assert.That(cash.IsKey("one"), Is.True);
            Assert.That(cash.IsKey("ten"), Is.False);

            cash.Remove("one");
            Assert.That(cash.IsKey("one"), Is.False);
        }
    }
}
