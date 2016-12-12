using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using NUnit.Framework;

namespace AsciiDocNet.Tests
{
	public class AsciiDocAssert
	{
		private static readonly Regex MultiReturn = new Regex("\r{2,}", RegexOptions.Compiled | RegexOptions.Multiline);
		private static readonly Regex NewLine = new Regex("(?<!\r)\n", RegexOptions.Compiled | RegexOptions.Multiline);

		public static void AreEqual(string asciidoc, Document document)
		{
			var directoryAttribute = document.Attributes.FirstOrDefault(a => a.Name == "docdir");
			if (directoryAttribute != null)
			{
				document.Attributes.Remove(directoryAttribute);
			}

			var builder = new StringBuilder();
			using (var visitor = new AsciiDocVisitor(new StringWriter(builder)))
			{
				document.Accept(visitor);
			}

			var expected = MultiReturn.Replace(NewLine.Replace(asciidoc, "\r\n"), "\r").TrimEnd('\r', '\n');
			var actual = builder.ToString().TrimEnd('\r', '\n');

			Assert.AreEqual(expected, actual, Diff(expected, actual));
		}

		public static string Diff(string expected, string actual)
		{
			var d = new Differ();
			var inlineBuilder = new InlineDiffBuilder(d);
			var result = inlineBuilder.BuildDiffModel(expected, actual);
			var hasChanges = result.Lines.Any(l => l.Type != ChangeType.Unchanged);
			if (!hasChanges) return string.Empty;

			var diff = result.Lines.Aggregate(new StringBuilder(), (sb, line) =>
			{
				if (line.Type == ChangeType.Inserted)
					sb.Append("+ ");
				else if (line.Type == ChangeType.Deleted)
					sb.Append("- ");
				else
					sb.Append("  ");
				sb.AppendLine(line.Text);
				return sb;
			}, sb => sb.ToString());

			return diff;
		}
	}
}