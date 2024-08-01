using System;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class StringAnalyzerTests
    {
        [Test]
        public void AnalyzerTrue()
        {
            Assert.IsTrue(StringAnalyzer.AnalyzeBracketsUsingStack("(()((())()))"));
            Assert.IsTrue(StringAnalyzer.AnalyzeBracketsUsingStack("(()()(()))"));

            Assert.IsTrue(StringAnalyzer.AnalyzeBracketsUsingMultiTypeStack("(()((())()))"));
            Assert.IsTrue(StringAnalyzer.AnalyzeBracketsUsingMultiTypeStack("(()()(()))"));
        }

        [Test]
        public void AnalyzerFalse()
        {
            Assert.IsFalse(StringAnalyzer.AnalyzeBracketsUsingStack("())("));
            Assert.IsFalse(StringAnalyzer.AnalyzeBracketsUsingStack("))(("));
            Assert.IsFalse(StringAnalyzer.AnalyzeBracketsUsingStack("((())"));

            Assert.IsFalse(StringAnalyzer.AnalyzeBracketsUsingMultiTypeStack("())("));
            Assert.IsFalse(StringAnalyzer.AnalyzeBracketsUsingMultiTypeStack("))(("));
            Assert.IsFalse(StringAnalyzer.AnalyzeBracketsUsingMultiTypeStack("((())"));
        }

    }
}
