using System.Diagnostics.CodeAnalysis;

namespace WebApplication.Api.Areas.HelpPage.ModelDescriptions
{
    [ExcludeFromCodeCoverage]
    public class EnumValueDescription
    {
        public string Documentation { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}