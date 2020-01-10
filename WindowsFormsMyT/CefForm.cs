using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using  CefSharp;
using CefSharp.WinForms;
namespace WindowsFormsMyT
{
    public partial class CefForm : Form
    {

      
        public CefForm()
        {
            InitializeComponent();
            Cef.Initialize(new CefSettings());

            ChromiumWebBrowser webBro = new ChromiumWebBrowser("https://www.baidu.com");

            this.Controls.Add(webBro);

            webBro.Dock = DockStyle.Fill;
        }

        
    }
}
