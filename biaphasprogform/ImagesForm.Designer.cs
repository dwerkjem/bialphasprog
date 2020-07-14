namespace biaphasprogform
{
	partial class ImagesForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagesForm));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.CloseButton = new System.Windows.Forms.Button();
			this.ImagesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.CloseButton, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.ImagesFlowLayoutPanel, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// CloseButton
			// 
			this.CloseButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CloseButton.Location = new System.Drawing.Point(3, 424);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(75, 23);
			this.CloseButton.TabIndex = 0;
			this.CloseButton.Text = "&Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// ImagesFlowLayoutPanel
			// 
			this.ImagesFlowLayoutPanel.AutoScroll = true;
			this.tableLayoutPanel1.SetColumnSpan(this.ImagesFlowLayoutPanel, 2);
			this.ImagesFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ImagesFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.ImagesFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.ImagesFlowLayoutPanel.Name = "ImagesFlowLayoutPanel";
			this.ImagesFlowLayoutPanel.Size = new System.Drawing.Size(800, 421);
			this.ImagesFlowLayoutPanel.TabIndex = 1;
			// 
			// ImagesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ImagesForm";
			this.Text = "Images";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.FlowLayoutPanel ImagesFlowLayoutPanel;
	}
}