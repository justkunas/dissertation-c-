using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using Dissertation;
using Dissertation.Searching;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace Testing
{
    public partial class MainScreen : Form
    {
        public ProductView pv = new ProductView();
        public Search_View sv = new Search_View();
        public InformationView iv = new InformationView();
        public ReviewView rv = new ReviewView();
        public MiscView mv = new MiscView();
        public ImageView imgv = new ImageView();
        public VoiceRecognition vr;

        public MainScreen()
        {
            InitializeComponent();
            vr = new VoiceRecognition();
            pv.vr = vr;
            sv.vr = vr;
            iv.vr = vr;
            rv.vr = vr;
            mv.vr = vr;
            imgv.vr = vr;
            Master.Controls.Add(sv);
        }
        
        //*
        private void MainScreen_Load(object sender, EventArgs e)
        {
            
        }
        //*/
    }
}
