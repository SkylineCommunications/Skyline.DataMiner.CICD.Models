namespace Protocol.Generator
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml.Schema;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static class Tools
	{
		/// <summary>
		/// Converts a string to PascalCase
		/// </summary>
		/// <param name="str">String to convert</param>
		public static string ToPascalCase(this string str)
		{
			StringBuilder sbOutput = new StringBuilder();

			bool bIsNewWord = true;

			for (int i = 0; i < str.Length; i++)
			{
				char cCurrentChar = str[i];

				if (!Char.IsLetterOrDigit(cCurrentChar))
				{
					bIsNewWord = true;
					continue;
				}

				sbOutput.Append(bIsNewWord ? Char.ToUpper(cCurrentChar) : cCurrentChar);
				bIsNewWord = false;
			}

			return sbOutput.ToString();
		}

		public static string WithLowercaseFirstLetter(this string str)
		{
			if (String.IsNullOrEmpty(str))
			{
				return str;
			}

			return Char.ToLowerInvariant(str[0]) + str.Substring(1);
		}

		public static string TryGetDocumentation(this XmlSchemaAnnotation annotation)
		{
			var doc = annotation?.Items.OfType<XmlSchemaDocumentation>().FirstOrDefault();
			if (doc == null)
			{
				return null;
			}

			string text = String.Join("", doc.Markup.Select(m => m.InnerText));
			text = text.Replace("<br />", "\n");
			text = text.Replace("<br/>", "\n");

			return text;
		}

		public static SyntaxTrivia CreateDocumentationTrivia(this string docText)
		{
			string[] lines = docText.Split(
				new[] { "\r\n", "\r", "\n" },
				StringSplitOptions.RemoveEmptyEntries
			);

			var tokens = lines
				.Select(line => SyntaxFactory.XmlTextLiteral(" " + line.Trim()))
				.ToList();
			for (int i = 0; i <= tokens.Count; i += 2)
			{
				tokens.Insert(i, SyntaxFactory.XmlTextNewLine("\n"));
			}

			var summary = SyntaxFactory.XmlElement("summary",
				SyntaxFactory.SingletonList<XmlNodeSyntax>(SyntaxFactory.XmlText(SyntaxFactory.TokenList(tokens))));

			var doc = SyntaxFactory.DocumentationComment(summary, SyntaxFactory.XmlText("\n"));

			return SyntaxFactory.Trivia(doc);
		}
	}
}
