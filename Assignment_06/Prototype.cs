using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
   //EXAMPLE 1
   //Prototype: Document
   public interface IDocument
    {
        IDocument Clone();
    }
    //concrete prototype: pdfDocument
    public class pdfDocument : IDocument
    {
        public string content { get; set; }
        public IDocument Clone()
        {
            return new pdfDocument { content = this.content };
        }
    }
    //concrete prototype: wordDocument
    public class wordDocument : IDocument
    {
        public string content { get; set; }
        public IDocument Clone()
        {
            return new wordDocument { content = this.content };
        }
    }


    //EXAMPLE 2
    //Prototype: Document
    public interface IColor
    {
        IColor Clone();
    }
    //concrete prototype: pdfDocument
    public class Red : IColor
    {
        public int colorCode { get; set; }
        public IColor Clone()
        {
            return new Red { colorCode = this.colorCode };
        }
    }
    //concrete prototype: wordDocument
    public class Blue : IColor
    {
        public int colorCode { get; set; }
        public IColor Clone()
        {
            return new Blue { colorCode = this.colorCode };
        }
    }

}
