using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dissertation
{
    public partial class MiscView : UserControl, IPagedView
    {

        public VoiceRecognition vr;
        Book book;
        bool blurbsLoaded;

        public MiscView()
        {
            InitializeComponent();
        }

        public void loadBlurbers()
        {
            data.Text = "";
            title.Text = "Blurbers";

            int test = 0;

            foreach(string s in Book.Blurbers)
            {
                data.Text += s + "\r\n\r\n";
            }

            foreach(char c in data.Text)
            {
                if (c == '\n')
                    test++;
            }

            Console.WriteLine("\\n count: " + test + ", blurbers count: " + Book.Blurbers.Count);
        }

        public void loadCreators()
        {
            data.Text = "";
            title.Text = "Creators";
            foreach (KeyValuePair<string,string> kv in Book.Creators)
            {
                data.Text += kv.Value + ": " + kv.Key + "\r\n";

                Console.WriteLine(kv.Value + " | " + kv.Key);
            }
        }

        public Book Book
        {
            get
            {
                return book;
            }
            set
            {
                book = value;
            }
        }

        private void debugButton_Click(object sender, EventArgs e)
        {
            if (blurbsLoaded)
                loadCreators();
            else
                loadBlurbers();

            blurbsLoaded = !blurbsLoaded;
        }

        public void loadNextPage() { }

        public void loadPreviousPage() { }
    }
}
