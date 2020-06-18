namespace TodoApp
{
    partial class MainApp
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
            this.lblActiveTasks = new System.Windows.Forms.Label();
            this.lblDoneTasks = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.LBoxActive = new System.Windows.Forms.ListBox();
            this.LBoxDone = new System.Windows.Forms.ListBox();
            this.CBDone = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblActiveTasks
            // 
            this.lblActiveTasks.AutoSize = true;
            this.lblActiveTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveTasks.Location = new System.Drawing.Point(255, 35);
            this.lblActiveTasks.Name = "lblActiveTasks";
            this.lblActiveTasks.Size = new System.Drawing.Size(117, 25);
            this.lblActiveTasks.TabIndex = 1;
            this.lblActiveTasks.Text = "Active tasks";
            // 
            // lblDoneTasks
            // 
            this.lblDoneTasks.AutoSize = true;
            this.lblDoneTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoneTasks.Location = new System.Drawing.Point(231, 441);
            this.lblDoneTasks.Name = "lblDoneTasks";
            this.lblDoneTasks.Size = new System.Drawing.Size(145, 25);
            this.lblDoneTasks.TabIndex = 3;
            this.lblDoneTasks.Text = "Finished Tasks";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(209, 727);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(186, 50);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add new Todo";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // LBoxActive
            // 
            this.LBoxActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBoxActive.FormattingEnabled = true;
            this.LBoxActive.ItemHeight = 20;
            this.LBoxActive.Location = new System.Drawing.Point(37, 85);
            this.LBoxActive.Name = "LBoxActive";
            this.LBoxActive.Size = new System.Drawing.Size(560, 244);
            this.LBoxActive.TabIndex = 7;
            // 
            // LBoxDone
            // 
            this.LBoxDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBoxDone.FormattingEnabled = true;
            this.LBoxDone.ItemHeight = 20;
            this.LBoxDone.Location = new System.Drawing.Point(37, 490);
            this.LBoxDone.Name = "LBoxDone";
            this.LBoxDone.Size = new System.Drawing.Size(560, 184);
            this.LBoxDone.TabIndex = 8;
            // 
            // CBDone
            // 
            this.CBDone.AutoSize = true;
            this.CBDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBDone.Location = new System.Drawing.Point(37, 353);
            this.CBDone.Name = "CBDone";
            this.CBDone.Size = new System.Drawing.Size(132, 24);
            this.CBDone.TabIndex = 5;
            this.CBDone.Text = "mark as done";
            this.CBDone.UseVisualStyleBackColor = true;
            this.CBDone.Click += new System.EventHandler(this.CBDone_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 808);
            this.Controls.Add(this.LBoxDone);
            this.Controls.Add(this.LBoxActive);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.CBDone);
            this.Controls.Add(this.lblDoneTasks);
            this.Controls.Add(this.lblActiveTasks);
            this.Name = "MainApp";
            this.Text = "MyToDos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblActiveTasks;
        private System.Windows.Forms.Label lblDoneTasks;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox LBoxActive;
        private System.Windows.Forms.ListBox LBoxDone;
        private System.Windows.Forms.CheckBox CBDone;
    }
}

