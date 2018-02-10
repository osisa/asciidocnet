using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AsciiDocNet
{
    public class SingleLineCommentParser : ProcessBufferParserBase
    {
        public override bool IsMatch(IDocumentReader reader, Container container, AttributeList attributes) =>
            PatternMatcher.CommentLine.IsMatch(reader.Line.AsString());

        public override void InternalParse(Container container, IDocumentReader reader, Regex delimiterRegex, ref List<string> buffer,
            ref AttributeList attributes)
        {
            var comment = new Comment(reader.Line.AsString().Substring(2));
            container.Add(comment);

            reader.ReadLine();
        }
    }
}