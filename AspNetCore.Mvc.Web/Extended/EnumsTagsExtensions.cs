using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Razor.TagHelpers
{
    [HtmlTargetElement("enums")]
    /// <summary>
    /// 扩展Enums-Select 选中
    /// </summary>
    public class EnumsTagsExtensions : TagHelper
    {
        [HtmlAttributeName("asp-enum")]
        /// <summary>
        /// 绑定的枚举值
        /// </summary>
        public Enum Value { get; set; }

        [HtmlAttributeName("asp-value")]
        /// <summary>
        /// 默认选中的值
        /// </summary>
        public string SelectValue { get; set; }

        [HtmlAttributeName("asp-id")]
        /// <summary>
        /// 绑定ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 索引
        /// </summary>
        public int ValueIsIndex { get; set; } = 2;

        private List<SelectListItem> GetEnumSelectListItem()
        {
            var list = new List<SelectListItem>();
            var typeOf = Value.GetType().GetTypeInfo();
            var enumValues = typeOf.GetEnumValues();
            foreach (var value in enumValues)
            {
                MemberInfo memberInfo = typeOf.GetMember(value.ToString()).First();
                var descriptionAttribute = memberInfo.GetCustomAttribute<DescriptionAttribute>();
                list.Add(new SelectListItem() {
                    Text=descriptionAttribute.Description,
                    Value=(ValueIsIndex==1)?((int)value).ToString():value.ToString()
                });
            }
            return list;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var list = GetEnumSelectListItem();
            output.TagName = "select";
            output.Attributes.SetAttribute("id",Id);
            var content = output.GetChildContentAsync();
            output.Content.AppendHtml(content.Result);
            foreach (var item in list)
            {
                if (item.Value != null)
                {
                    if (item.Value == SelectValue)
                    {
                        output.Content.AppendHtml($"<option  value='{item.Value}' selected='selected'>{item.Text}</option>");
                    }
                    else
                    {
                        output.Content.AppendHtml($"<option value='{item.Value}' >{item.Text}</option>");
                    }
                }
                else
                {
                    if (item.Text == SelectValue)
                    {
                        output.Content.AppendHtml($"<option  selected='selected'>{item.Text}</option>");
                    }
                    else
                    {
                        output.Content.AppendHtml($"<option>{item.Text}</option>");
                    }
                }
            }
        }
    }
}
