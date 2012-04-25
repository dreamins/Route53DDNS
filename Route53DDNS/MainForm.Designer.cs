using log4net;

namespace Route53DDNS
{
    partial class MainForm
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(MainForm).FullName);
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Options form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "Route53DDNS";
            this.Text = "Route53DDNS";
            this.ResumeLayout(false);
            
            // Initialize log and write hello
            logger.Info("Application is starting up");

            // Initialize tray menu
            initializeTrayMenu();
        }

        #endregion
    }
}

