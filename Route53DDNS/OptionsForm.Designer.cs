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
            this.addButton = new System.Windows.Forms.Button();
            this.ipProviderBox = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pattern = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.urlValue = new System.Windows.Forms.TextBox();
            this.urlEnabled = new System.Windows.Forms.CheckBox();
            this.cancelUpdateButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.urlList = new System.Windows.Forms.ListBox();
            this.runOnStart = new System.Windows.Forms.CheckBox();
            this.TabControl.SuspendLayout();
            this.tabGeneralPage.SuspendLayout();
            this.tabAWSPage.SuspendLayout();
            this.tabAdvancedPage.SuspendLayout();
            this.ipProviderBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // externalIPNeeded
            // 
            this.externalIPNeeded.AutoSize = true;
            this.externalIPNeeded.Location = new System.Drawing.Point(26, 23);
            this.externalIPNeeded.Name = "externalIPNeeded";
            this.externalIPNeeded.Size = new System.Drawing.Size(182, 17);
            this.externalIPNeeded.TabIndex = 0;
            this.externalIPNeeded.Text = "Use external IP provider to get IP";
            this.externalIPNeeded.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(77, 264);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(180, 264);
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
            this.hasInitialDelay.Location = new System.Drawing.Point(26, 62);
            this.hasInitialDelay.Name = "hasInitialDelay";
            this.hasInitialDelay.Size = new System.Drawing.Size(232, 17);
            this.hasInitialDelay.TabIndex = 3;
            this.hasInitialDelay.Text = "Use randomized initial delay (recommended)";
            this.hasInitialDelay.UseVisualStyleBackColor = true;
            // 
            // timerPeriodSec
            // 
            this.timerPeriodSec.Location = new System.Drawing.Point(26, 140);
            this.timerPeriodSec.Name = "timerPeriodSec";
            this.timerPeriodSec.Size = new System.Drawing.Size(34, 20);
            this.timerPeriodSec.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 143);
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
            this.TabControl.Size = new System.Drawing.Size(755, 246);
            this.TabControl.TabIndex = 12;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabGeneralPage
            // 
            this.tabGeneralPage.Controls.Add(this.runOnStart);
            this.tabGeneralPage.Controls.Add(this.externalIPNeeded);
            this.tabGeneralPage.Controls.Add(this.label1);
            this.tabGeneralPage.Controls.Add(this.timerPeriodSec);
            this.tabGeneralPage.Controls.Add(this.hasInitialDelay);
            this.tabGeneralPage.Location = new System.Drawing.Point(4, 22);
            this.tabGeneralPage.Name = "tabGeneralPage";
            this.tabGeneralPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneralPage.Size = new System.Drawing.Size(747, 220);
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
            this.tabAWSPage.Size = new System.Drawing.Size(747, 220);
            this.tabAWSPage.TabIndex = 1;
            this.tabAWSPage.Text = "AWS";
            this.tabAWSPage.UseVisualStyleBackColor = true;
            // 
            // tabAdvancedPage
            // 
            this.tabAdvancedPage.Controls.Add(this.addButton);
            this.tabAdvancedPage.Controls.Add(this.ipProviderBox);
            this.tabAdvancedPage.Controls.Add(this.urlList);
            this.tabAdvancedPage.Location = new System.Drawing.Point(4, 22);
            this.tabAdvancedPage.Name = "tabAdvancedPage";
            this.tabAdvancedPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdvancedPage.Size = new System.Drawing.Size(747, 220);
            this.tabAdvancedPage.TabIndex = 2;
            this.tabAdvancedPage.Text = "Advanced";
            this.tabAdvancedPage.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(15, 192);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add new";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // ipProviderBox
            // 
            this.ipProviderBox.Controls.Add(this.deleteButton);
            this.ipProviderBox.Controls.Add(this.label6);
            this.ipProviderBox.Controls.Add(this.pattern);
            this.ipProviderBox.Controls.Add(this.label5);
            this.ipProviderBox.Controls.Add(this.urlValue);
            this.ipProviderBox.Controls.Add(this.urlEnabled);
            this.ipProviderBox.Controls.Add(this.cancelUpdateButton);
            this.ipProviderBox.Controls.Add(this.updateButton);
            this.ipProviderBox.Location = new System.Drawing.Point(217, 13);
            this.ipProviderBox.Name = "ipProviderBox";
            this.ipProviderBox.Size = new System.Drawing.Size(309, 172);
            this.ipProviderBox.TabIndex = 1;
            this.ipProviderBox.TabStop = false;
            this.ipProviderBox.Text = "URL options";
            this.ipProviderBox.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(183, 143);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Extraction regex";
            // 
            // pattern
            // 
            this.pattern.Location = new System.Drawing.Point(23, 115);
            this.pattern.Name = "pattern";
            this.pattern.Size = new System.Drawing.Size(265, 20);
            this.pattern.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "URL";
            // 
            // urlValue
            // 
            this.urlValue.Location = new System.Drawing.Point(23, 68);
            this.urlValue.Name = "urlValue";
            this.urlValue.Size = new System.Drawing.Size(265, 20);
            this.urlValue.TabIndex = 3;
            // 
            // urlEnabled
            // 
            this.urlEnabled.AutoSize = true;
            this.urlEnabled.Location = new System.Drawing.Point(23, 24);
            this.urlEnabled.Name = "urlEnabled";
            this.urlEnabled.Size = new System.Drawing.Size(91, 17);
            this.urlEnabled.TabIndex = 2;
            this.urlEnabled.Text = "enable polling";
            this.urlEnabled.UseVisualStyleBackColor = true;
            // 
            // cancelUpdateButton
            // 
            this.cancelUpdateButton.Location = new System.Drawing.Point(102, 143);
            this.cancelUpdateButton.Name = "cancelUpdateButton";
            this.cancelUpdateButton.Size = new System.Drawing.Size(75, 23);
            this.cancelUpdateButton.TabIndex = 1;
            this.cancelUpdateButton.Text = "Cancel";
            this.cancelUpdateButton.UseVisualStyleBackColor = true;
            this.cancelUpdateButton.Click += new System.EventHandler(this.cancelUpdateButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(21, 143);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 0;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // urlList
            // 
            this.urlList.FormattingEnabled = true;
            this.urlList.Location = new System.Drawing.Point(15, 13);
            this.urlList.Name = "urlList";
            this.urlList.Size = new System.Drawing.Size(180, 173);
            this.urlList.TabIndex = 0;
            this.urlList.Click += new System.EventHandler(this.urlList_SelectedIndexChanged);
            this.urlList.SelectedIndexChanged += new System.EventHandler(this.urlList_SelectedIndexChanged);
            // 
            // runOnStart
            // 
            this.runOnStart.AutoSize = true;
            this.runOnStart.Location = new System.Drawing.Point(26, 101);
            this.runOnStart.Name = "runOnStart";
            this.runOnStart.Size = new System.Drawing.Size(166, 17);
            this.runOnStart.TabIndex = 6;
            this.runOnStart.Text = "Launch on start of application";
            this.runOnStart.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 314);
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
            this.tabAdvancedPage.ResumeLayout(false);
            this.ipProviderBox.ResumeLayout(false);
            this.ipProviderBox.PerformLayout();
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
        private System.Windows.Forms.ListBox urlList;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.GroupBox ipProviderBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pattern;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox urlValue;
        private System.Windows.Forms.CheckBox urlEnabled;
        private System.Windows.Forms.Button cancelUpdateButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.CheckBox runOnStart;
    }
}