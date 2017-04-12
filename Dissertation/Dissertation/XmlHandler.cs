using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dissertation;
using System.Xml;
using System.Xml.Linq;

namespace Dissertation
{
    public class XmlHandler
    {
        private HashSet<Book> books;

        public XmlHandler()
        {
            books = new HashSet<Book>();
        }

    }
}
