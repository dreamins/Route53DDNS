using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Route53DDNSLib.type;
using Route53DDNSLib;

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
            if (!Options.isReady())
            {
                OnOptions(this, e);
            }
            Options opts = Options.loadFromConfig();
            if (opts.GeneralOptions.RunOnStart)
            {
                run();
            }
        }

        private void OnOptions(object sender, EventArgs e)
        {
            // save and reload opts, restart runner
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.ShowDialog();
            if (optionsForm.Saved)
            {
                logger.Info("Looks like something was saved. Restarting");
                if (runner != null && runner.Running)
                {
                    runner.start(); // restart actually :)
                }
            }
            else
            {
                logger.Info("Nothing saved?");
            }
        }

        private void OnRun(object sender, EventArgs e)
        {
            run();
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

        private void run()
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

    }
}
