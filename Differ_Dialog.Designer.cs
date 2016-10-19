using System.Windows.Forms;
namespace Test
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
            this.label1 = new System.Windows.Forms.Label();
            this.label_file2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.file1_button = new System.Windows.Forms.Button();
            this.file2_button = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.diff_start_button = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File 1";
            // 
            // label_file2
            // 
            this.label_file2.AutoSize = true;
            this.label_file2.Location = new System.Drawing.Point(9, 88);
            this.label_file2.Name = "label_file2";
            this.label_file2.Size = new System.Drawing.Size(32, 13);
            this.label_file2.TabIndex = 1;
            this.label_file2.Text = "File 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Output Directory";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(277, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(98, 86);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(277, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(98, 129);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(277, 20);
            this.textBox3.TabIndex = 5;
            // 
            // file1_button
            // 
            this.file1_button.BackColor = System.Drawing.Color.Transparent;
            this.file1_button.ForeColor = System.Drawing.Color.Black;
            this.file1_button.Location = new System.Drawing.Point(404, 45);
            this.file1_button.Name = "file1_button";
            this.file1_button.Size = new System.Drawing.Size(75, 23);
            this.file1_button.TabIndex = 6;
            this.file1_button.Text = "Browse";
            this.file1_button.UseVisualStyleBackColor = false;
            this.file1_button.Click += new System.EventHandler(this.file1_Browse);
            // 
            // file2_button
            // 
            this.file2_button.Location = new System.Drawing.Point(404, 84);
            this.file2_button.Name = "file2_button";
            this.file2_button.Size = new System.Drawing.Size(75, 23);
            this.file2_button.TabIndex = 7;
            this.file2_button.Text = "Browse";
            this.file2_button.UseVisualStyleBackColor = true;
            this.file2_button.Click += new System.EventHandler(this.file2_Browse);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(404, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // diff_start_button
            // 
            this.diff_start_button.Location = new System.Drawing.Point(148, 176);
            this.diff_start_button.Name = "diff_start_button";
            this.diff_start_button.Size = new System.Drawing.Size(194, 23);
            this.diff_start_button.TabIndex = 9;
            this.diff_start_button.Text = "Start Diff";
            this.diff_start_button.UseVisualStyleBackColor = true;
            this.diff_start_button.Click += new System.EventHandler(this.StartDiff);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 218);
            this.Controls.Add(this.diff_start_button);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.file2_button);
            this.Controls.Add(this.file1_button);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_file2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Differ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_file2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button file1_button;
        private System.Windows.Forms.Button file2_button;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button diff_start_button;
    }
}

