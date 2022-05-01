using System;
using System.IO;
using System.Text;
using Spire.Pdf;
namespace ConsoleApp42
{
    class Program
    {
        static string ConvertHtml(string html)
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
        static void Main(string[] args)
        {
			//<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" id="main1" width="100%" height="1121"
            //viewBox="0 0 793 1121" preserveaspectration="xMidYMid meet">
            string pdfresultFile = @"c:\kuku\kuku.pdf";
            PdfDocument pdf = new PdfDocument();

            pdf.LoadFromFile(pdfresultFile);
            MemoryStream stream = new MemoryStream();

            pdf.SaveToStream(stream, FileFormat.HTML);

            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            reader.BaseStream.Position = 0;
            string html = reader.ReadToEnd();

            //Manipulate html
            string newHtml = PdfHtmlConverter.ConvertHtml(html);
            
            File.WriteAllText(@"c:\kuku\kuku.html", newHtml);
        }
    }
}
