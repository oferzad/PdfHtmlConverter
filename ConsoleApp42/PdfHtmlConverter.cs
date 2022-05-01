using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp42
{
    class PdfHtmlConverter
    {
        public static string ConvertHtml(string html)
        {
            //Manipulate html
            int widthStartIndex = html.IndexOf("width=\"");
            int heightStartIndex = html.IndexOf("height=\"");
            int widthEndIndex = html.IndexOf("\"", widthStartIndex + 7);
            int heightEndIndex = html.IndexOf("\"", heightStartIndex + 8);
            string width = html.Substring(widthStartIndex + 7, widthEndIndex - widthStartIndex - 7);
            string height = html.Substring(heightStartIndex + 8, heightEndIndex - heightStartIndex - 8);
            int continueIndex = html.IndexOf(">", heightEndIndex);

            string newHtml = html.Substring(0, widthStartIndex - 1);
            newHtml += $" width=\"100%\" height=\"{height}\" viewBox=\"0 0 {width} {height}\" preserveaspectration=\"xMidYMid meet\"";
            newHtml += html.Substring(continueIndex);
            return newHtml;
        }

    }
}
