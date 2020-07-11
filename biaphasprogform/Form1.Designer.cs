using System;
using System.IO;

namespace biaphasprogform
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
			this.phraseTextBox = new System.Windows.Forms.TextBox();
			this.EncryptionProgressBar = new System.Windows.Forms.ProgressBar();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.GoButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// phraseTextBox
			// 
			this.phraseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.phraseTextBox, 2);
			this.phraseTextBox.Location = new System.Drawing.Point(0, 31);
			this.phraseTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.phraseTextBox.MaxLength = 99999;
			this.phraseTextBox.Multiline = true;
			this.phraseTextBox.Name = "phraseTextBox";
			this.phraseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.phraseTextBox.Size = new System.Drawing.Size(729, 306);
			this.phraseTextBox.TabIndex = 0;
			// 
			// EncryptionProgressBar
			// 
			this.EncryptionProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.EncryptionProgressBar, 2);
			this.EncryptionProgressBar.Location = new System.Drawing.Point(3, 3);
			this.EncryptionProgressBar.Name = "EncryptionProgressBar";
			this.EncryptionProgressBar.Size = new System.Drawing.Size(723, 25);
			this.EncryptionProgressBar.TabIndex = 2;
			this.EncryptionProgressBar.UseWaitCursor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.phraseTextBox, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.EncryptionProgressBar, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.GoButton, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(729, 366);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// GoButton
			// 
			this.GoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GoButton.Location = new System.Drawing.Point(3, 340);
			this.GoButton.Name = "GoButton";
			this.GoButton.Size = new System.Drawing.Size(75, 23);
			this.GoButton.TabIndex = 3;
			this.GoButton.Text = "Encrypt";
			this.GoButton.UseVisualStyleBackColor = true;
			this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(729, 366);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Bialpha Encryption";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox phraseTextBox;
		private System.Windows.Forms.ProgressBar EncryptionProgressBar;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button GoButton;
	}
}

