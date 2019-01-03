namespace Twitter
{
    partial class Form1
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
            this.GetTimeline = new System.Windows.Forms.Button();
            this.BearerToken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ObtainToken = new System.Windows.Forms.Button();
            this.ResponseText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GetTimeline
            // 
            this.GetTimeline.Location = new System.Drawing.Point(375, 59);
            this.GetTimeline.Name = "GetTimeline";
            this.GetTimeline.Size = new System.Drawing.Size(155, 40);
            this.GetTimeline.TabIndex = 17;
            this.GetTimeline.Text = "Get Timeline";
            this.GetTimeline.UseVisualStyleBackColor = true;
            this.GetTimeline.Click += new System.EventHandler(this.GetTimeline_Click);
            // 
            // BearerToken
            // 
            this.BearerToken.Location = new System.Drawing.Point(15, 25);
            this.BearerToken.Multiline = true;
            this.BearerToken.Name = "BearerToken";
            this.BearerToken.ReadOnly = true;
            this.BearerToken.Size = new System.Drawing.Size(303, 74);
            this.BearerToken.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Bearer Token:";
            // 
            // ObtainToken
            // 
            this.ObtainToken.Location = new System.Drawing.Point(375, 9);
            this.ObtainToken.Name = "ObtainToken";
            this.ObtainToken.Size = new System.Drawing.Size(155, 40);
            this.ObtainToken.TabIndex = 14;
            this.ObtainToken.Text = "Obtain Token";
            this.ObtainToken.UseVisualStyleBackColor = true;
            this.ObtainToken.Click += new System.EventHandler(this.ObtainToken_Click);
            // 
            // ResponseText
            // 
            this.ResponseText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResponseText.Location = new System.Drawing.Point(12, 111);
            this.ResponseText.Multiline = true;
            this.ResponseText.Name = "ResponseText";
            this.ResponseText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ResponseText.Size = new System.Drawing.Size(518, 227);
            this.ResponseText.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 350);
            this.Controls.Add(this.GetTimeline);
            this.Controls.Add(this.BearerToken);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ObtainToken);
            this.Controls.Add(this.ResponseText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetTimeline;
        private System.Windows.Forms.TextBox BearerToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ObtainToken;
        private System.Windows.Forms.TextBox ResponseText;
    }
}