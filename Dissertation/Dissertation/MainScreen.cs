using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.IO;

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

            string[] xmlToCheck = {"blurbers", "dedications", "epigraphs", "firstword", "lastword", "quotations", "series", "awards", "characters", "placestags", "similar products"};

            Dictionary<string,bool> doesContain = new Dictionary<string,bool>();
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Justin\\Documents\\amazon_ex.xml");
            
            foreach(string xml in xmlToCheck)
            {
                doesContain.Add(xml, false);
            }

            string[] folders = Directory.GetDirectories("C:\\Users\\Justin\\Documents\\Amazon Books\\xml");
            string[] files;

            foreach (string folder in folders)
            {
                files = Directory.GetFiles(folder);
                foreach (string file in files)
                {
                    doc.Load(file);

                    for (int i = 0; i < doc.ChildNodes.Item(3).ChildNodes.Count; i++)
                    {
                        XmlNode item = doc.ChildNodes.Item(3).ChildNodes.Item(i);
                        if (xmlToCheck.Contains(item.Name.ToString()))
                        {
                            if (item.InnerText.Equals(null) || item.InnerText.Equals(""))
                            {

                            }
                            else
                            {
                                doesContain[item.InnerText] = true;
                            }
                        }
                    }
                }
            }

            foreach(KeyValuePair<string,bool> obj in doesContain)
            {
                if (obj.Value)
                {
                    Console.WriteLine(obj.Key);
                }
            }
            
            //XmlElement images = doc.GetElementById("Images");

            //img.Load();

            //string data = title[0].InnerText + "\n" + isbn[0].InnerText + "\n" + price[0].InnerText;
            display.Text = "";

        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
