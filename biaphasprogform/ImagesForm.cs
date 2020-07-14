using System.Collections.Generic;
using System.Windows.Forms;

namespace biaphasprogform
{
	public partial class ImagesForm : Form
	{
		private List<string> _bialphas = new List<string>();
		private PictureBox[] _images;

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

			_images = new PictureBox[BialphList.Count];
				
			for (int i = 0; i < BialphList.Count; ++i)
			{
				PictureBox image = new PictureBox
				{
					// we really want to load the image named: BialphList[i] + ".png" but they don't exist here yet
					ImageLocation = @"Resources\untitled.png",
					SizeMode = PictureBoxSizeMode.AutoSize,
					Margin = new Padding(0),
					Padding = new Padding(0)
				};
				_images[i] = image;
			}

			ImagesFlowLayoutPanel.Controls.AddRange(_images);
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
			ImagesFlowLayoutPanel.Controls.Clear();
			// PictureBox is an IDispose class and needs to be cleaned up when you are done with it or you will run out of memory and resources
			if (_images != null)
			{
				for (int i = 0; i < _images.Length; ++i)
				{
					_images[i].Dispose();
					_images[i] = null;
				}
			}
		}

		private void CloseButton_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
