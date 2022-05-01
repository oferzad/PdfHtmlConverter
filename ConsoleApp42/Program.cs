using System;
using System.IO;
using System.Text;
using Spire.Pdf;
namespace ConsoleApp42
{
    class Program
    {
        
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
