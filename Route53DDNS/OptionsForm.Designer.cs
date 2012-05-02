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
            this.SuspendLayout();
            // 
            // externalIPNeeded
            // 
            this.externalIPNeeded.AutoSize = true;
            this.externalIPNeeded.Location = new System.Drawing.Point(12, 12);
            this.externalIPNeeded.Name = "externalIPNeeded";
            this.externalIPNeeded.Size = new System.Drawing.Size(182, 17);
            this.externalIPNeeded.TabIndex = 0;
            this.externalIPNeeded.Text = "Use external IP provider to get IP";
            this.externalIPNeeded.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(193, 206);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(313, 206);
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
            this.hasInitialDelay.Location = new System.Drawing.Point(12, 35);
            this.hasInitialDelay.Name = "hasInitialDelay";
            this.hasInitialDelay.Size = new System.Drawing.Size(232, 17);
            this.hasInitialDelay.TabIndex = 3;
            this.hasInitialDelay.Text = "Use randomized initial delay (recommended)";
            this.hasInitialDelay.UseVisualStyleBackColor = true;
            // 
            // timerPeriodSec
            // 
            this.timerPeriodSec.Location = new System.Drawing.Point(12, 57);
            this.timerPeriodSec.Name = "timerPeriodSec";
            this.timerPeriodSec.Size = new System.Drawing.Size(26, 20);
            this.timerPeriodSec.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Route53 update period in seconds.";
            // 
            // awsAccessKey
            // 
            this.awsAccessKey.Location = new System.Drawing.Point(313, 12);
            this.awsAccessKey.Name = "awsAccessKey";
            this.awsAccessKey.Size = new System.Drawing.Size(173, 20);
            this.awsAccessKey.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(492, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "AWS access key";
            // 
            // awsSecretKey
            // 
            this.awsSecretKey.Location = new System.Drawing.Point(313, 35);
            this.awsSecretKey.Name = "awsSecretKey";
            this.awsSecretKey.Size = new System.Drawing.Size(173, 20);
            this.awsSecretKey.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "AWS secret key";
            // 
            // hostedZoneId
            // 
            this.hostedZoneId.Location = new System.Drawing.Point(313, 58);
            this.hostedZoneId.Name = "hostedZoneId";
            this.hostedZoneId.Size = new System.Drawing.Size(173, 20);
            this.hostedZoneId.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "AWS HostedZoneID";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 241);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hostedZoneId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.awsSecretKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.awsAccessKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timerPeriodSec);
            this.Controls.Add(this.hasInitialDelay);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.externalIPNeeded);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}