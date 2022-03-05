using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    /// <summary>
    /// Summary description for PdfDemo
    /// </summary>
    public class PdfDemo : IHttpHandler
    {

        public static string FONT = HttpContext.Current.Server.MapPath("~/fonts/thsarabunnew.woff");
        public void ProcessRequest(HttpContext context)
        {
            var file = CreatePdf();
            context.Response.Clear();
            context.Response.ContentType = "application/pdf";
            context.Response.BinaryWrite(file.ToArray());
            context.Response.End();
        }

        public byte[] CreatePdf()
        {
            var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);
            PdfFont font = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H);

            // ค่าเริ่มต้น Font
            document.SetFont(font).SetFontSize(10);

            document.Add(new Paragraph("บันทึกข้อความ").SetFontSize(12).SetTextAlignment(TextAlignment.CENTER));

            document.Close();
            return stream.ToArray();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}