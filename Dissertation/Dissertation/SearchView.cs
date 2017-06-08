using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Dissertation
{
    public partial class Search_View : UserControl, IView
    {

        public VoiceRecognition vr;

        public Search_View()
        {
            InitializeComponent();
        }

        private void Search_View_Load(object sender, EventArgs e)
        {
            //AllocConsole();
            SaveLabel.Hide();
            quantityLabel.Hide();
            filterTree.ExpandAll();
            Console.WriteLine("Loaded");
            vr.CurrentView = this;
            vr.viewLoaded();
            vr.startKeyWordRecogniser();
        }

        private void debugButton_Click(object sender, EventArgs e)
        {
            FileChecking.imageCount();
            
            /*
            string file = @"C:\Users\Justkunas\Documents\Amazon Books\xml\716\1435260716.xml";

            Book book = Book.parseXML(XElement.Load(file));

            Console.WriteLine(book.Creators.Count);
            /*
            string file = @"C:\Users\Justkunas\Documents\Amazon Books\xml\476\0787964476.xml";
            string file2 = @"C:\Users\Justkunas\Documents\Amazon Books\xml\999\0030639999.xml";
            string file3 = @"C:\Users\Justkunas\Documents\Amazon Books\xml\999\0312427999.xml";
            string file4 = @"C:\Users\Justkunas\Documents\Amazon Books\xml\999\0006351999.xml";

            Book book = Book.parseXML(XElement.Load(file4));

            Testing.Program.ms.mv.Book = book;

            Testing.Program.ms.mv.loadBlurbers();
            Testing.Program.ms.Master.Controls.Remove(Testing.Program.ms.sv);
            Testing.Program.ms.Master.Controls.Add(Testing.Program.ms.mv);
            //*/
            //FileChecking.imageCount();

            /*
            foreach(TreeNode v in filterTree.Nodes)
            {
                Console.WriteLine(v.Name);
            }

            filterTree.Nodes["PagesNode"].BackColor = SystemColors.ActiveCaption;
            */

            /*
            XElement doc = XElement.Load(file);

            Console.WriteLine(doc.Element("dewey"));

            Book book = Book.parseXML(doc);

            if (doc.Element("dewey") != null)
                book.Dewey = doc.Element("dewey").Value;

            Testing.Program.ms.iv.loadBook(book);

            Testing.Program.ms.Master.Controls.Remove(Testing.Program.ms.sv);
            Testing.Program.ms.Master.Controls.Add(Testing.Program.ms.iv);
            //*/
            /*
            XElement parenetEle = XElement.Load(file);
            Book book = Book.parseXML(parenetEle);

            foreach(Image i in book.Images)
            {
                Console.WriteLine(i.Url);
            }

            Console.WriteLine(book.Images.Count);
            //*/

        }

        public TextBox getSearchBox()
        {
            return searchBox;
        }

        public TreeView getTreeView()
        {
            return filterTree;
        }

        public Dictionary<string, object> getItem()
        {
            Dictionary<string, object> returnDictionary = new Dictionary<string, object>();
            returnDictionary.Add("SaveLabel", SaveLabel);
            returnDictionary.Add("quantityLabel", quantityLabel);
            return returnDictionary;
        }

        public Label getSaveLabel()
        {
            return SaveLabel;
        }

        public Label getQuantityLabel()
        {
            return quantityLabel;
        }

        private void search_Click(object sender, EventArgs e)
        {
            vr.search();
        }

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();
    }
}
