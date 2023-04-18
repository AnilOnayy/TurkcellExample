using Microsoft.AspNetCore.Razor.TagHelpers;
using TurkcellExample.Models;

namespace TurkcellExample.TagHelpers
{
    public class ProductShowTagHelper : TagHelper
    {
        public Product Product { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetHtmlContent(@$"
                  <ul class='list-group'>
                        <li class='list-group-item'>Id :{Product.Id}</li>
                        <li class='list-group-item'>Adı :{Product.Name}</li>
                        <li class='list-group-item'>Rengi : {Product.Color}</li>
                        <li class='list-group-item'>Yayın Durumu : {Product.IsPublish}</li>
                  </ul>
            ");
        }
    }
}
