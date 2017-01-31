using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Testing
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("amazon_ex.xml");

            XmlNodeList title = doc.GetElementsByTagName("title");
            XmlNodeList isbn = doc.GetElementsByTagName("isbn");
            XmlNodeList price = doc.GetElementsByTagName("listprice");
            //XmlElement images = doc.GetElementById("Images");

            //img.Load();

                           //string data = title[0].InnerText + "\n" + isbn[0].InnerText + "\n" + price[0].InnerText;
            display.Text = "";
        }
    }
}
