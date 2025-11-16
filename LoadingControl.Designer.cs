namespace IDT_PARKING
{
    partial class LoadingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressIndicator = new Guna.UI2.WinForms.Guna2ProgressIndicator();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressIndicator
            // 
            this.progressIndicator.Location = new System.Drawing.Point(60, 15);
            this.progressIndicator.Name = "progressIndicator";
            this.progressIndicator.ProgressColor = System.Drawing.Color.DodgerBlue;
            this.progressIndicator.Size = new System.Drawing.Size(80, 80);
            this.progressIndicator.TabIndex = 0;
            this.progressIndicator.AnimationSpeed = 100;
            this.progressIndicator.CircleSize = 1F;
            this.progressIndicator.AutoStart = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblMessage.Location = new System.Drawing.Point(20, 100);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(165, 21);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Đang truy vấn dữ liệu...";
            // 
            // LoadingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.progressIndicator);
            this.Name = "LoadingControl";
            this.Size = new System.Drawing.Size(200, 140);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ProgressIndicator progressIndicator;
        private System.Windows.Forms.Label lblMessage;
    }
}
