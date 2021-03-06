using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace uLearn
{
	public static class StringExtensions
	{

		public static string ExcludeLinesWith(this string s, params string[] args)
		{
			return string.Join(
				Environment.NewLine,
				s.SplitToLines().Where(line => !args.Any(line.Contains)));
		}
		public static string WithArgs(this string s, params object[] args)
		{
			return string.Format(s, args);
		}

		public static string RemoveBom(this string text)
		{
			return text.TrimStart(new[] { '\uFEFF', '\u200B' });
		}

		public static string AsUtf8(this byte[] bytes)
		{
			return Encoding.UTF8.GetString(bytes).RemoveBom();
		}

		public static string[] SplitToLines(this string text)
		{
			return Regex.Split(text, @"\r?\n");
		}

		public static string[] SplitToLinesWithEoln(this string text)
		{
			return Regex.Split(text, @"(?<=\r?\n)").Where(s => !string.IsNullOrEmpty(s)).ToArray();
		}

		public static string RemoveCommonNesting(this string text)
		{
			var lines = text.SplitToLines();
			var newLines = lines.RemoveCommonNesting();
			return string.Join("\r\n", newLines);
		}

		public static string LineEndingsToUnixStyle(this string text)
		{
			return string.Join("\n", text.SplitToLines());
		}

		public static string NormalizeEoln(this string str)
		{
			return str.LineEndingsToUnixStyle().Trim();
		}

		public static string EnsureEnoughLines(this string text, int minLinesCount)
		{
			var lines = text.SplitToLines();
			return string.Join("\n", lines.Concat(Enumerable.Repeat("", Math.Max(0, minLinesCount - lines.Length))));
		}

		public static IEnumerable<string> RemoveCommonNesting(this IList<string> lines)
		{
			var nonEmptyLines = lines.Where(line => line.Trim().Length > 0).ToList();
			if (nonEmptyLines.Any())
			{
				var nesting = nonEmptyLines.Min(line => line.TakeWhile(char.IsWhiteSpace).Count());
				var newLines = lines.Select(line => line.Length > nesting ? line.Substring(nesting) : line);
				return newLines;
			}
			else
			{
				return Enumerable.Repeat("", lines.Count());
			}
		}

		public static string FixExtraEolns(this string arg)
		{
			return Regex.Replace(arg.Trim(), "(\t*\r?\n){3,}", "\r\n\r\n");
		}
	}
}