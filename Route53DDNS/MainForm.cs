using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Route53DDNS.type;

namespace Route53DDNS
{
    public partial class MainForm : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private Runner runner;
        private MenuItem runItem;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnOptions(object sender, EventArgs e)
        {
            // save and reload opts, restart runner
        }

        private void OnRun(object sender, EventArgs e)
        {
            if (runner == null)
            {
                runner = new Runner();
            }

            if (!runner.Running)
            {
                runner.start();
                runItem.Checked = runner.Running;
            }
            else
            {
                runner.stop();
                runItem.Checked = runner.Running;
            }
        }

        private void initializeTrayMenu() 
        {
            trayMenu = new ContextMenu();

            trayMenu.MenuItems.Add("Options", OnOptions);
            runItem = trayMenu.MenuItems.Add("Run", OnRun);
            trayMenu.MenuItems.Add("Exit", OnExit);
            
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Route53DDNS";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }
    }
}
