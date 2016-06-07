using demo.taghelpers.Configuration;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace demo.taghelpers.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        private EmailConfiguration _configuration;

        public EmailTagHelper(IOptions<EmailConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var address = content.GetContent() + "@" + _configuration.Domain;
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent(address);
        }
    }
}