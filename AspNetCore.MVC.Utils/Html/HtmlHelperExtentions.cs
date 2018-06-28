using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microsoft.AspNetCore.Mvc.Rendering
{

    /// <summary>
    /// ASP.NET MVC 扩展 Html.分页
    /// </summary>
    public static class HtmlHelperExtentions
    {
        public static HtmlString PaginationBar(this IHtmlHelper helper, int pageIndex, int pageSize, int totalCount, string url, int centSize = 5)
        {
            //计算页数
            if (totalCount < 1 || pageSize < 1)
            {
                return new HtmlString("");
            }
            int pageCount = totalCount / pageSize;
            if (pageCount < 1)
            {
                return new HtmlString("");
            }
            if (totalCount % pageSize > 0)
            {
                pageCount += 1;
            }
            if (pageCount <= 1)
            {
                return new HtmlString("");
            }
            StringBuilder pageStr = new StringBuilder();
            string pageId = "{__id__}";
            pageStr.Append("<ul class=\"pagination pagination-sm no-margin \">");
            string firstBtn = "<li><a href=\"" + ReplaceStr(url, pageId, (pageIndex - 1).ToString()) + "\">«</a></li>";
            string lastBtn = "<li><a href=\"" + ReplaceStr(url, pageId, (pageIndex + 1).ToString()) + "\">»</a></li>";
            string firstStr = "<li><a href=\"" + ReplaceStr(url, pageId, "1") + "\">1</a></li>";
            string lastStr = "<li><a href=\"" + ReplaceStr(url, pageId, pageCount.ToString()) + "\">" + pageCount.ToString() + "</a></li>";

            if (pageIndex <= 1)
            {
                firstBtn = "<li class='disabled'><a href='javascript:void(0)'>«</a></li>";
            }
            if (pageIndex >= pageCount)
            {
                lastBtn = "<li class='disabled'><a href='javascript:void(0)'>»</a></li>";
            }
            if (pageIndex == 1)
            {
                firstStr = "<li class='active'><a href='javascript:void(0)'>1</a><li>";
            }
            if (pageIndex == pageCount)
            {
                lastStr = "<li class='active'><a href='javascript:void(0)'>" + pageCount.ToString() + "</a></li>";
            }
            int firstNum = pageIndex - (centSize / 2); //中间开始的页码
            if (pageIndex < centSize)
                firstNum = 2;
            int lastNum = pageIndex + centSize - ((centSize / 2) + 1); //中间结束的页码
            if (lastNum >= pageCount)
                lastNum = pageCount - 1;
            pageStr.Append("<li><a href='javascript:void(0)'>共" + totalCount + "记录</a></li>");
            pageStr.Append(firstBtn + firstStr);
            if (pageIndex >= centSize)
            {
                pageStr.Append("<li><a href='javascript:void(0)'>...</a></li>\n");
            }
            for (int i = firstNum; i <= lastNum; i++)
            {
                if (i == pageIndex)
                {
                    pageStr.Append("<li class='active'><a href='javascript:void(0)'>" + i + "</a></li>");
                }
                else
                {
                    pageStr.Append("<li><a href=\"" + ReplaceStr(url, pageId, i.ToString()) + "\">" + i + "</a></li>");
                }
            }
            if (pageCount - pageIndex > centSize - ((centSize / 2)))
            {
                pageStr.Append("<li><a href='javascript:void(0)'>...</a></li>");
            }
            pageStr.Append(lastStr + lastBtn);
            pageStr.Append("</ul>");
            return new HtmlString(pageStr.ToString());
        }

        #region 替换指定的字符串
        /// <summary>
        /// 替换指定的字符串
        /// </summary>
        /// <param name="originalStr">原字符串</param>
        /// <param name="oldStr">旧字符串</param>
        /// <param name="newStr">新字符串</param>
        /// <returns></returns>
        public static string ReplaceStr(string originalStr, string oldStr, string newStr)
        {
            if (string.IsNullOrEmpty(oldStr))
            {
                return "";
            }
            return originalStr.Replace(oldStr, newStr);
        }
        #endregion
    }
}
