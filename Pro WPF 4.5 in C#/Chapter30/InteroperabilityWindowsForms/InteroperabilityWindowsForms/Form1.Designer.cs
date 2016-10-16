namespace InteroperabilityWindowsForms
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
            this.cmdShowWrong = new System.Windows.Forms.Button();
            this.cmdShowRight = new System.Windows.Forms.Button();
            this.cmdShowMixedForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdShowWrong
            // 
            this.cmdShowWrong.Location = new System.Drawing.Point(47, 25);
            this.cmdShowWrong.Name = "cmdShowWrong";
            this.cmdShowWrong.Size = new System.Drawing.Size(178, 45);
            this.cmdShowWrong.TabIndex = 0;
            this.cmdShowWrong.Text = "Show a modeless WPF Window (the wrong way)";
            this.cmdShowWrong.UseVisualStyleBackColor = true;
            this.cmdShowWrong.Click += new System.EventHandler(this.cmdShowWrong_Click);
            // 
            // cmdShowRight
            // 
            this.cmdShowRight.Location = new System.Drawing.Point(47, 87);
            this.cmdShowRight.Name = "cmdShowRight";
            this.cmdShowRight.Size = new System.Drawing.Size(178, 45);
            this.cmdShowRight.TabIndex = 1;
            this.cmdShowRight.Text = "Show a modeless WPF Window (the right way)";
            this.cmdShowRight.UseVisualStyleBackColor = true;
            this.cmdShowRight.Click += new System.EventHandler(this.cmdShowRight_Click);
            // 
            // cmdShowMixedForm
            // 
            this.cmdShowMixedForm.Location = new System.Drawing.Point(47, 150);
            this.cmdShowMixedForm.Name = "cmdShowMixedForm";
            this.cmdShowMixedForm.Size = new System.Drawing.Size(178, 45);
            this.cmdShowMixedForm.TabIndex = 2;
            this.cmdShowMixedForm.Text = "Show a form with mixed content";
            this.cmdShowMixedForm.UseVisualStyleBackColor = true;
            this.cmdShowMixedForm.Click += new System.EventHandler(this.cmdShowMixedForm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 359);
            this.Controls.Add(this.cmdShowMixedForm);
            this.Controls.Add(this.cmdShowRight);
            this.Controls.Add(this.cmdShowWrong);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdShowWrong;
        private System.Windows.Forms.Button cmdShowRight;
        private System.Windows.Forms.Button cmdShowMixedForm;
    }
}

