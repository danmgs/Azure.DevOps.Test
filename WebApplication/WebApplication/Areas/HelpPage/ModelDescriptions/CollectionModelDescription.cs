using System.Diagnostics.CodeAnalysis;

namespace WebApplication.Areas.HelpPage.ModelDescriptions
{
    [ExcludeFromCodeCoverage]
    public class CollectionModelDescription : ModelDescription
    {
        public ModelDescription ElementDescription { get; set; }
    }
}