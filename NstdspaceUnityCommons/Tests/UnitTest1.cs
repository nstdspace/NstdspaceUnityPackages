using System;
using Nstdspace.Commons.Extensions;
using NUnit.Framework;

namespace Nstdspace.Commons.Tests
{
    public class Tests
    {
        [Test]
        [TestCaseSource(nameof(TrimIndentTestCases))]
        public void TestTrimIndent(string input, string expected)
        {
            string indentTrimmed = input.TrimIndent();
            Assert.AreEqual(expected, indentTrimmed);
        }

        private static readonly string[][] TrimIndentTestCases =
        {
            new[]
            {
                string.Join(
                    Environment.NewLine,
                    "                   ",
                    "           indented aewaf",
                    "               xxxyyyzzz",
                    "   weiwemoimg",
                    "                           QWERTZ",
                    "                   "
                ),
                string.Join(
                    Environment.NewLine,
                    "        indented aewaf",
                    "            xxxyyyzzz",
                    "weiwemoimg",
                    "                        QWERTZ"
                )
            },
            new[]
            {
                @"
                blabal
                        blabalab
                    weoigwoi
                  235
            ",
                @"blabal
        blabalab
    weoigwoi
  235"
            },
            new[]
            {
                "\n         a", "a"
            },
            new[]
            {
                @"
                    void GeneratedFunction() {{
                        DoSomething();
                    }}
                ",
                @"void GeneratedFunction() {{
    DoSomething();
}}"
            }
        };
    }
}