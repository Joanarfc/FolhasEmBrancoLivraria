using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace FolhasEmBrancoLivraria.App.Extensions
{
    public class EmailTagHelper : TagHelper
    {
        public string EmailDomain { get; set; } = "folhasembranco.com";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var emailTo = content.GetContent() + "livraria@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:" + emailTo);
            output.Content.SetContent(emailTo);
        }
    }
}
