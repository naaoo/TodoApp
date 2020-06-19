namespace CloseTodos
{
    partial class CloseTodos
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
            this.lBoxOverdue = new System.Windows.Forms.ListBox();
            this.lBoxClose = new System.Windows.Forms.ListBox();
            this.lblOverdue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lBoxOverdue
            // 
            this.lBoxOverdue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBoxOverdue.FormattingEnabled = true;
            this.lBoxOverdue.ItemHeight = 20;
            this.lBoxOverdue.Location = new System.Drawing.Point(51, 67);
            this.lBoxOverdue.Name = "lBoxOverdue";
            this.lBoxOverdue.Size = new System.Drawing.Size(433, 144);
            this.lBoxOverdue.TabIndex = 0;
            // 
            // lBoxClose
            // 
            this.lBoxClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBoxClose.FormattingEnabled = true;
            this.lBoxClose.ItemHeight = 20;
            this.lBoxClose.Location = new System.Drawing.Point(51, 274);
            this.lBoxClose.Name = "lBoxClose";
            this.lBoxClose.Size = new System.Drawing.Size(433, 144);
            this.lBoxClose.TabIndex = 1;
            // 
            // lblOverdue
            // 
            this.lblOverdue.AutoSize = true;
            this.lblOverdue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverdue.Location = new System.Drawing.Point(181, 33);
            this.lblOverdue.Name = "lblOverdue";
            this.lblOverdue.Size = new System.Drawing.Size(147, 25);
            this.lblOverdue.TabIndex = 2;
            this.lblOverdue.Text = "Overdue Tasks";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Due within 24h";
            // 
            // CloseTodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOverdue);
            this.Controls.Add(this.lBoxClose);
            this.Controls.Add(this.lBoxOverdue);
            this.Name = "CloseTodos";
            this.Text = "Todos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lBoxOverdue;
        private System.Windows.Forms.ListBox lBoxClose;
        private System.Windows.Forms.Label lblOverdue;
        private System.Windows.Forms.Label label1;
    }
}

