namespace Route53DDNS
{
    partial class OptionsForm
    {
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
            this.externalIPNeeded = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.hasInitialDelay = new System.Windows.Forms.CheckBox();
            this.timerPeriodSec = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.awsAccessKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.awsSecretKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hostedZoneId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabGeneralPage = new System.Windows.Forms.TabPage();
            this.tabAWSPage = new System.Windows.Forms.TabPage();
            this.tabAdvancedPage = new System.Windows.Forms.TabPage();
            this.TabControl.SuspendLayout();
            this.tabGeneralPage.SuspendLayout();
            this.tabAWSPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // externalIPNeeded
            // 
            this.externalIPNeeded.AutoSize = true;
            this.externalIPNeeded.Location = new System.Drawing.Point(32, 23);
            this.externalIPNeeded.Name = "externalIPNeeded";
            this.externalIPNeeded.Size = new System.Drawing.Size(182, 17);
            this.externalIPNeeded.TabIndex = 0;
            this.externalIPNeeded.Text = "Use external IP provider to get IP";
            this.externalIPNeeded.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(91, 206);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(186, 206);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // hasInitialDelay
            // 
            this.hasInitialDelay.AutoSize = true;
            this.hasInitialDelay.Location = new System.Drawing.Point(32, 54);
            this.hasInitialDelay.Name = "hasInitialDelay";
            this.hasInitialDelay.Size = new System.Drawing.Size(232, 17);
            this.hasInitialDelay.TabIndex = 3;
            this.hasInitialDelay.Text = "Use randomized initial delay (recommended)";
            this.hasInitialDelay.UseVisualStyleBackColor = true;
            // 
            // timerPeriodSec
            // 
            this.timerPeriodSec.Location = new System.Drawing.Point(32, 88);
            this.timerPeriodSec.Name = "timerPeriodSec";
            this.timerPeriodSec.Size = new System.Drawing.Size(34, 20);
            this.timerPeriodSec.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Route53 update period in seconds.";
            // 
            // awsAccessKey
            // 
            this.awsAccessKey.Location = new System.Drawing.Point(6, 20);
            this.awsAccessKey.Name = "awsAccessKey";
            this.awsAccessKey.Size = new System.Drawing.Size(171, 20);
            this.awsAccessKey.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "AWS access key";
            // 
            // awsSecretKey
            // 
            this.awsSecretKey.Location = new System.Drawing.Point(6, 51);
            this.awsSecretKey.Name = "awsSecretKey";
            this.awsSecretKey.Size = new System.Drawing.Size(171, 20);
            this.awsSecretKey.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "AWS secret key";
            // 
            // hostedZoneId
            // 
            this.hostedZoneId.Location = new System.Drawing.Point(6, 82);
            this.hostedZoneId.Name = "hostedZoneId";
            this.hostedZoneId.Size = new System.Drawing.Size(171, 20);
            this.hostedZoneId.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "AWS HostedZoneID";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabGeneralPage);
            this.TabControl.Controls.Add(this.tabAWSPage);
            this.TabControl.Controls.Add(this.tabAdvancedPage);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(303, 178);
            this.TabControl.TabIndex = 12;
            // 
            // tabGeneralPage
            // 
            this.tabGeneralPage.Controls.Add(this.externalIPNeeded);
            this.tabGeneralPage.Controls.Add(this.label1);
            this.tabGeneralPage.Controls.Add(this.timerPeriodSec);
            this.tabGeneralPage.Controls.Add(this.hasInitialDelay);
            this.tabGeneralPage.Location = new System.Drawing.Point(4, 22);
            this.tabGeneralPage.Name = "tabGeneralPage";
            this.tabGeneralPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneralPage.Size = new System.Drawing.Size(295, 152);
            this.tabGeneralPage.TabIndex = 0;
            this.tabGeneralPage.Text = "General";
            this.tabGeneralPage.UseVisualStyleBackColor = true;
            // 
            // tabAWSPage
            // 
            this.tabAWSPage.Controls.Add(this.awsAccessKey);
            this.tabAWSPage.Controls.Add(this.hostedZoneId);
            this.tabAWSPage.Controls.Add(this.label4);
            this.tabAWSPage.Controls.Add(this.awsSecretKey);
            this.tabAWSPage.Controls.Add(this.label2);
            this.tabAWSPage.Controls.Add(this.label3);
            this.tabAWSPage.Location = new System.Drawing.Point(4, 22);
            this.tabAWSPage.Name = "tabAWSPage";
            this.tabAWSPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabAWSPage.Size = new System.Drawing.Size(295, 152);
            this.tabAWSPage.TabIndex = 1;
            this.tabAWSPage.Text = "AWS";
            this.tabAWSPage.UseVisualStyleBackColor = true;
            // 
            // tabAdvancedPage
            // 
            this.tabAdvancedPage.Location = new System.Drawing.Point(4, 22);
            this.tabAdvancedPage.Name = "tabAdvancedPage";
            this.tabAdvancedPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdvancedPage.Size = new System.Drawing.Size(295, 152);
            this.tabAdvancedPage.TabIndex = 2;
            this.tabAdvancedPage.Text = "Advanced";
            this.tabAdvancedPage.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 256);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.TabControl.ResumeLayout(false);
            this.tabGeneralPage.ResumeLayout(false);
            this.tabGeneralPage.PerformLayout();
            this.tabAWSPage.ResumeLayout(false);
            this.tabAWSPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox externalIPNeeded;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox hasInitialDelay;
        private System.Windows.Forms.TextBox timerPeriodSec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox awsAccessKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox awsSecretKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hostedZoneId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabGeneralPage;
        private System.Windows.Forms.TabPage tabAWSPage;
        private System.Windows.Forms.TabPage tabAdvancedPage;
    }
}