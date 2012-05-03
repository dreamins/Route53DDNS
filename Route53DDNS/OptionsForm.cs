using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Route53DDNS.type;
using Route53DDNS.exception;

using log4net;

namespace Route53DDNS
{
    public partial class OptionsForm : Form
    {
        private Options opts;
        private bool saved;
        private bool itemSelectedToUpdate;
        private string urlSelectedToUpdate;
        private static readonly ILog logger = LogManager.GetLogger(typeof(OptionsForm).FullName);

        public OptionsForm()
        {
            InitializeComponent();
        }

        public bool Saved
        {
            get
            {
                return saved;
            }
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            //load the configuration! I am the modifier, so I don't care if anyone modifies it!
            opts = Options.loadFromConfig();

            // There should be a way to bind these GUI controls generically to values, this is just plain boring :(
            this.externalIPNeeded.Checked   = opts.GeneralOptions.ExternalIPNeeded;
            this.hasInitialDelay.Checked    = opts.GeneralOptions.HasInitialDelay;
            this.timerPeriodSec.Text        = opts.GeneralOptions.TimerPeriodSec.ToString();
            this.runOnStart.Checked         = opts.GeneralOptions.RunOnStart;
            this.awsAccessKey.Text          = opts.AWSOptions.AWSAccessKey;
            this.awsSecretKey.Text          = opts.AWSOptions.AWSSecretKey;
            this.hostedZoneId.Text          = opts.AWSOptions.HostedZoneId;
            foreach(IPProvider provider in opts.GeneralOptions.IPProviders) 
            {
                this.urlList.Items.Add(provider.URL);
            }

            resizeToPartial();
            logger.Info("Options form loaded");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                logger.Info("Saving configuration from GUI form.");
                opts.GeneralOptions.ExternalIPNeeded    = this.externalIPNeeded.Checked;
                opts.GeneralOptions.HasInitialDelay     = this.hasInitialDelay.Checked;
                opts.GeneralOptions.TimerPeriodSec      = long.Parse(this.timerPeriodSec.Text);
                opts.GeneralOptions.RunOnStart          = this.runOnStart.Checked;
                opts.AWSOptions.AWSAccessKey            = this.awsAccessKey.Text;
                opts.AWSOptions.AWSSecretKey            = this.awsSecretKey.Text;
                opts.AWSOptions.HostedZoneId            = this.hostedZoneId.Text;
                opts.writeToConfig();
            }
            catch (Exception ex)
            {
                logger.Error("Cannot save configuration.", ex);
                this.saved = false;
                return;
            }

            this.saved = true;
            this.Close();
            logger.Info("Success.");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            logger.Info("Save cancelled. Why did you woke me up?");
            this.saved = false;
            this.Close();
        }

        private void urlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.urlList.SelectedItem == null)
            {
                logger.Warn("Perhaps deleted item?");
                return;
            }
            string selectedURL = this.urlList.SelectedItem.ToString();
            IPProvider provider = this.opts.GeneralOptions.IPProviders.Find(delegate (IPProvider p) { return p.URL == selectedURL;});

            if (provider == null)
            {
                logger.Error("Selected something that is not an item?");
                return;
            }

            this.urlEnabled.Checked = provider.Enabled;
            this.urlValue.Text = provider.URL;
            this.pattern.Text = provider.Pattern;
            itemSelectedToUpdate = true;
            urlSelectedToUpdate = provider.URL;
            resizeToFull(); 
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TabControl.SelectedTab.Name != "Advanced")
            {
                resizeToPartial();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string urlToUpdate = this.urlValue.Text;
            IPProvider provider = this.opts.GeneralOptions.IPProviders.Find(delegate(IPProvider p) { return p.URL == urlToUpdate; });

            if (provider == null && itemSelectedToUpdate)
            {
                provider = this.opts.GeneralOptions.IPProviders.Find(delegate(IPProvider p) { return p.URL == urlSelectedToUpdate; });
            }

            if (provider == null)
            {
                // insert mode
                if (urlToUpdate == "[Fill here]")
                {
                    logger.Warn("Wat?");
                }
                else
                {
                    provider = new IPProvider(urlToUpdate, pattern.Text, this.urlEnabled.Checked);
                    this.opts.GeneralOptions.IPProviders.Add(provider);
                    this.urlList.Items.Add(urlToUpdate);
                }
            }
            else
            {
                provider.Pattern = pattern.Text;
                provider.Enabled = this.urlEnabled.Checked;
                provider.URL = urlToUpdate;
                this.urlList.Items.Remove(urlSelectedToUpdate);
                this.urlList.Items.Add(urlToUpdate);
            }

            resizeToPartial();
        }

        private void resizeToPartial()
        {
            this.ipProviderBox.Visible = false;
            this.TabControl.Size = new Size(311, 246);
            this.Size = new Size(358, 337);
        }

        private void resizeToFull()
        {
            this.ipProviderBox.Visible = true;
            this.TabControl.Size = new Size(549, 246);
            this.Size = new Size(601, 337);
        }

        private void cancelUpdateButton_Click(object sender, EventArgs e)
        {
            resizeToPartial();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.urlEnabled.Checked = true;
            this.urlValue.Text = "[Fill here]";
            this.pattern.Text = "[Fill here]";
            itemSelectedToUpdate = false;
            urlSelectedToUpdate = "";
            resizeToFull();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string urlToUpdate = this.urlValue.Text;
            IPProvider provider = this.opts.GeneralOptions.IPProviders.Find(delegate(IPProvider p) { return p.URL == urlToUpdate; });

            if (provider != null)
            {
                this.opts.GeneralOptions.IPProviders.Remove(provider);
            }

            this.urlList.Items.Remove(urlToUpdate);

            resizeToPartial();
        }
    }
}
