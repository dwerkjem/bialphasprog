﻿namespace biaphasprogform
{
	partial class ImagesForm
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
			this.ImagesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// ImagesFlowLayoutPanel
			// 
			this.ImagesFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ImagesFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.ImagesFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.ImagesFlowLayoutPanel.Name = "ImagesFlowLayoutPanel";
			this.ImagesFlowLayoutPanel.Size = new System.Drawing.Size(800, 450);
			this.ImagesFlowLayoutPanel.TabIndex = 0;
			// 
			// ImagesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.ImagesFlowLayoutPanel);
			this.Name = "ImagesForm";
			this.Text = "Images Form";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel ImagesFlowLayoutPanel;
	}
}