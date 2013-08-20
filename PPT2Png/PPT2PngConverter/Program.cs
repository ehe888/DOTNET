using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPT2PngConverter
{
    
    using POWERPOINT = Microsoft.Office.Interop.PowerPoint;
    using Microsoft.Office.Core;
    using Microsoft.Office.Interop.PowerPoint;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            POWERPOINT.Application App = new Microsoft.Office.Interop.PowerPoint.Application();

            POWERPOINT.Presentation pptPresentation =
                App.Presentations.Open2007("D:\\DOWNLOADS\\2573000-sap-sd-overview-110510113251-phpapp01.ppt", 
                MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);

            Presentation presentation = new Presentation();
            presentation.Title = pptPresentation.Name;

            foreach (POWERPOINT.Slide pptSlide in pptPresentation.Slides)
            {
                Comments comments = pptSlide.Comments;
                Page page = new Page();
                page.PageNumber = pptSlide.SlideNumber;

                foreach (Microsoft.Office.Interop.PowerPoint.Comment comment in comments) { 
                    Comment cmt = new Comment();
                    cmt.Author = comment.Author;
                    cmt.DateTime = comment.DateTime;
                    cmt.Text = comment.Text;
                    page.Comments.Add(cmt);
                }

                presentation.Pages.Add(page);

                pptSlide.Export(String.Format("D:\\TEMP\\{0}.png", pptSlide.SlideNumber), "PNG", 2048, 1536);
            }

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(Presentation));
            FileStream xmlOutput = File.Create("D:\\TEMP\\index.xml");
            x.Serialize(xmlOutput, presentation);

        }
    }

    public class Presentation
    {

        public Presentation() {
            Pages = new List<Page>();
        }

        public string Title { get; set; }

        public List<Page> Pages { get; set; }
    }

    public class Page {
        public Page() {
            Comments = new List<Comment>();
        }

        public int PageNumber { get; set; }

        public List<Comment> Comments { get; set; }
    }

    public class Comment {
        public string Author { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }
    }
}
