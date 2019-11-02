using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Open_Lab_04._08
{
    [TestFixture]
    public class Tests
    {

        private StringTools tools;
        private bool shouldStop;

        private const int RandStrMinSize = 2;
        private const int RandStrMaxSize = 6;
        private const int RandStrCountMin = 1;
        private const int RandStrCountMax = 100;
        private const int RandSeed = 408408408;
        private const int RandTestCasesCount = 97;

        [OneTimeSetUp]
        public void Init()
        {
            tools = new StringTools();
            shouldStop = false;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure ||
                TestContext.CurrentContext.Result.Outcome == ResultState.Error)
                shouldStop = true;
        }

        [TestCase(new []{ "Tomato", "Potato", "Pair" }, new []{ "Pair" })]
        [TestCase(new []{ "Kangaroo", "Bear", "Fox" }, new []{ "Bear" })]
        [TestCase(new []{ "Ryan", "Kieran", "Jason", "Matt" }, new []{ "Ryan", "Matt" })]
        public void IsFourLettersTest(string[] strings, string[] expected) =>
            Assert.That(tools.IsFourLetters(strings), Is.EqualTo(expected));

        [TestCaseSource(nameof(GetRandom))]
        public void IsFourLettersTestRandom(string[] strings, string[] expected)
        {
            if (shouldStop)
                Assert.Ignore("Previous test failed!");

            Assert.That(tools.IsFourLetters(strings), Is.EqualTo(expected));
        }

        private static IEnumerable GetRandom()
        {
            var rand = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var arr = new string[rand.Next(RandStrCountMin, RandStrCountMax + 1)];

                for (var j = 0; j < arr.Length; j++)
                {
                    var chars = new char[rand.Next(RandStrMinSize, RandStrMaxSize + 1)];

                    for (var k = 0; k < chars.Length; k++)
                        chars[k] = (char) rand.Next('0', 'z' + 1);

                    arr[j] = new string(chars);
                }

                yield return new TestCaseData(arr, arr.Where(str => str.Length == 4).ToArray());
            }
        }

    }
}
