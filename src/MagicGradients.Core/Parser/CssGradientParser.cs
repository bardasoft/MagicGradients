using MagicGradients.Builder;
using MagicGradients.Parser.TokenDefinitions;
using System.Collections.Generic;
using System.Linq;

namespace MagicGradients.Parser
{
    public class CssGradientParser
    {
        private readonly ITokenDefinition[] _definitions;

        public CssGradientParser()
        {
            _definitions = new ITokenDefinition[]
            {
                new LinearGradientDefinition(),
                new RadialGradientDefinition(), 
                new ColorHexDefinition(),
                new ColorChannelDefinition(),
                new ColorNameDefinition()
            };
        }
        
        public List<IGradient> Parse(string css)
        {
            var builder = new GradientBuilder();

            if (string.IsNullOrWhiteSpace(css))
                return builder.Build();

            var reader = new CssReader(css);

            while (reader.CanRead)
            {
                var token = reader.Read().Trim();

                var definition = _definitions.FirstOrDefault(x => x.IsMatch(token));
                definition?.Parse(reader, builder);

                reader.MoveNext();
            }

            return builder.BuildReversed();
        }
    }
}
