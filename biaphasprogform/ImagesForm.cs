using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace biaphasprogform
{
	public partial class ImagesForm : Form
	{
		private List<string> _bialphas = new List<string>();
		private List<PictureBox> _images = new List<PictureBox>();

		public ImagesForm()
		{
			InitializeComponent();
			ImagesFlowLayoutPanel.AutoSize = true;
		}

		public List<string> BialphList
		{
			get
			{
				return _bialphas;
			}
			set
			{
				// should probably clear current list before building and displaying a new list
				_bialphas = value;
				if (_bialphas != null && _bialphas.Count > 0)
				{
					LoadImages();
				}
			}
		}

		public void LoadImages()
		{
			CleanupImages();

			foreach (string bialpha in BialphList)
			{
				PictureBox image = new PictureBox
				{
					// we really want to load the image named: biapha + ".png" but they don't exist here yet
					ImageLocation = @"Resources\untitled.png",
					SizeMode = PictureBoxSizeMode.AutoSize,
					Margin = new Padding(0),
					Padding = new Padding(0)
				};
				_images.Add(image);
			}
			
			SuspendLayout();
			ImagesFlowLayoutPanel.Controls.AddRange(_images.ToArray());
			ResumeLayout(true);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			CleanupImages();

			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void CleanupImages()
		{
			// PictureBox is a IDispose class and needs to be cleaned up when you are done with it or you will run out of memory and resources
			while (ImagesFlowLayoutPanel.Controls.Count > 0)
			{
				Control control = ImagesFlowLayoutPanel.Controls[0];
				ImagesFlowLayoutPanel.Controls.RemoveAt(0);
				control.Dispose();
			}
		}

		private void CloseButton_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
