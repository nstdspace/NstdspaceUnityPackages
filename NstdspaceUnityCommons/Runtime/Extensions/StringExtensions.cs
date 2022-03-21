using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nstdspace.Commons.Extensions
{
    public static class StringExtensions
    {
        public static String TrimIndent(this String str)
        {
            List<string> lines = str.Lines();
            int minIndent = lines
                .WhereNot(string.IsNullOrWhiteSpace)
                .Select(GetIndentWidth)
                .Min();

            var reindentedLines = lines
                .WhereNot((line, index) => (index == 0 || index == lines.Count - 1) && string.IsNullOrWhiteSpace(line))
                .Select(line => line.Substring(Mathf.Clamp(minIndent, 0, line.Length)));

            return string.Join(
                Environment.NewLine,
                reindentedLines
            );
        }

        public static List<String> Lines(this String str) =>
            str.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            ).ToList();

        private static int GetIndentWidth(this String str) =>
            str.Length - str.Trim().Length;
    }
}