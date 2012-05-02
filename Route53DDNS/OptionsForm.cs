using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Route53DDNS.type;
using log4net;

namespace Route53DDNS
{
    public partial class OptionsForm : Form
    {
        private Options opts;
        private bool saved;
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
            this.externalIPNeeded.CheckState= opts.GeneralOptions.ExternalIPNeeded ? CheckState.Checked: CheckState.Unchecked;
            this.hasInitialDelay.CheckState = opts.GeneralOptions.HasInitialDelay ? CheckState.Checked : CheckState.Unchecked;
            this.timerPeriodSec.Text        = opts.GeneralOptions.TimerPeriodSec.ToString();
            this.awsAccessKey.Text          = opts.AWSOptions.AWSAccessKey;
            this.awsSecretKey.Text          = opts.AWSOptions.AWSSecretKey;
            this.hostedZoneId.Text          = opts.AWSOptions.HostedZoneId;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                logger.Info("Saving configuration from GUI form.");
                opts.GeneralOptions.ExternalIPNeeded    = this.externalIPNeeded.CheckState == CheckState.Checked;
                opts.GeneralOptions.HasInitialDelay     = this.hasInitialDelay.CheckState == CheckState.Checked;
                opts.GeneralOptions.TimerPeriodSec      = long.Parse(this.timerPeriodSec.Text);
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
    }
}
