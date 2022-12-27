using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp.OffScreen;
using System.Windows.Forms;

using CefSharp;
using System.Threading;
using System.IO;
using System.Diagnostics;
using CefSharp.Internals;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CarsScreening.Main;
using System.CodeDom;
using System.Reflection.Emit;
using HtmlAgilityPack;
using System.Security.Policy;

namespace CarsScreening
{
    public partial class frmMain : Form
    {
        //ChromiumWebBrowser browserMain;
        CefSharp.WinForms.ChromiumWebBrowser browserContainer;
        CommandSender commandSender;
        public frmMain()
        {
            InitializeComponent();
            //browserMain = new ChromiumWebBrowser(urlTxbx.Text);
            browserContainer = new CefSharp.WinForms.ChromiumWebBrowser("https://www.cars.com/");
            commandSender = new CommandSender();

        }

        private void urlBttn_Click(object sender, EventArgs e)
        {
            if (FixedVariables.statusOfPage==CommandStatus.StatusOfPage.PageIsLoaded)
            {
                commandSender.SendLoginCommands(browserContainer, "johngerson808@gmail.com", "test8008", ref FixedVariables.ErrorMessage, ref FixedVariables.statusOfCommands);

                browserContainer.AddressChanged += OnBrowserAddressChanged;
                browserContainer.LoadingStateChanged += OnLoadhanged;


                //commandSender.SendSelectCommands(browserContainer, ref FixedVariables.ErrorMessage, ref FixedVariables.statusOfCommands);

                //commandSender.ScrapCarList(browserContainer, ref FixedVariables.ErrorMessage, ref FixedVariables.statusOfCommands);
            }
            else
            {
                MessageBox.Show("Please wait for the page load.");
            }
            
        }
        private void OnLoadhanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    commandSender.GetHtml(browserContainer);
                }));
            }
        }
        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                commandSender.GetHtml(browserContainer);
            }));
              
        }
        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false)
            {
                FixedVariables.statusOfPage = CommandStatus.StatusOfPage.PageIsLoaded;
                panelStatus.BackColor = Color.GreenYellow;
                statusLabel.Invoke((MethodInvoker)(() => statusLabel.Text = "Page is loaded. You can start."));
                urlBttn.Invoke((MethodInvoker)(() => urlBttn.Enabled = true));
                
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            panelStatus.BackColor= Color.IndianRed;
            statusLabel.Text = "Page is loading please wait..";
            urlBttn.Enabled = false;
            browserContainer.Dock= DockStyle.Fill;
           
            pContainer.Controls.Add(browserContainer);
            
            browserContainer.LoadingStateChanged += Browser_LoadingStateChanged;

        }

        private void btnParse_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

           


        }
    }
}
