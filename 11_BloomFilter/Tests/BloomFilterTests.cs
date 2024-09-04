using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BloomFilterTests
    {
        static readonly int SIZE = 10;
        string str1 = "0123456789";
        string str2 = "9012345678";
        string str3 = "8901234567";
        string str4 = "7890123456";
        string str5 = "6789012345";
        string str6 = "5678901234";
        string str7 = "4567890123";
        string str8 = "3456789012";
        string str9 = "2345678901";
        string str10 = "1234567890";

        [Test]
        public void FilterTest()
        {
            BloomFilter filter = new BloomFilter(32);
            filter.Add(str1);
            filter.Add(str7);
            Assert.That(filter.IsValue(str2), Is.False);
            Assert.That(filter.IsValue(str7), Is.True);
        }

        [Test]
        public void FilterCompleteTest()
        {
            BloomFilter filter = new BloomFilter(32);
            filter.Add(str1);
            filter.Add("8452168998");
            filter.Add("8562145893");
            filter.Add("8412534568");
            filter.Add("8452153695");
            Assert.That(filter.IsValue(str2), Is.False);
        }

        [Test]
        public void Hash1AndHash2NotEqual()
        {
            BloomFilter bloomFilter = new BloomFilter(SIZE);
            int fhash1 = bloomFilter.Hash1(str1);
            int fhash2 = bloomFilter.Hash2(str1);
            Assert.That(fhash1, Is.Not.EqualTo(fhash2), "Hash codes are equal");

            int fhash3 = bloomFilter.Hash1(str2);
            int fhash4 = bloomFilter.Hash2(str2);
            Assert.That(fhash3, Is.Not.EqualTo(fhash4), "Hash codes are equal");
        }

        [Test]
        public void TestIsValue()
        {
            BloomFilter bloomFilter = new BloomFilter(SIZE);

            Assert.That(bloomFilter.IsValue(str1), Is.False);
            Assert.That(bloomFilter.IsValue(str2), Is.False);
            Assert.That(bloomFilter.IsValue(str3), Is.False);
            Assert.That(bloomFilter.IsValue(str4), Is.False);
            Assert.That(bloomFilter.IsValue(str5), Is.False);
            Assert.That(bloomFilter.IsValue(str6), Is.False);
            Assert.That(bloomFilter.IsValue(str7), Is.False);
            Assert.That(bloomFilter.IsValue(str8), Is.False);
            Assert.That(bloomFilter.IsValue(str9), Is.False);
            Assert.That(bloomFilter.IsValue(str10), Is.False);

            bloomFilter.Add(str1);
            Assert.That(bloomFilter.IsValue(str1), Is.True);
            Assert.That(bloomFilter.IsValue(str6), Is.True);

            bloomFilter.Add(str2);
            Assert.That(bloomFilter.IsValue(str1), Is.True);
            Assert.That(bloomFilter.IsValue(str2), Is.True);
            Assert.That(bloomFilter.IsValue(str7), Is.True);

            bloomFilter.Add(str3);
            Assert.That(bloomFilter.IsValue(str3), Is.True);
            Assert.That(bloomFilter.IsValue(str8), Is.True);

            bloomFilter.Add(str4);
            Assert.That(bloomFilter.IsValue(str4), Is.True);
            Assert.That(bloomFilter.IsValue(str5), Is.True);
            Assert.That(bloomFilter.IsValue(str9), Is.True);

            bloomFilter.Add(str5);
            Assert.That(bloomFilter.IsValue(str10), Is.True);
        }


    }
}
