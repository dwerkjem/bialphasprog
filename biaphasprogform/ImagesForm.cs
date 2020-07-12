using System.Collections.Generic;
using System.Windows.Forms;

namespace biaphasprogform
{
	public partial class ImagesForm : Form
	{
		private List<string> _bialphas = new List<string>();

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
			SuspendLayout();
			foreach (string bialpha in BialphList)
			{
				// PictureBox is a IDispose class and needs to be cleaned up when you are done with it or you will run out of memory and resources
				PictureBox image = new PictureBox
				{
					// we really want to load the image named: biapha + ".png" but they don't exist here yet
					ImageLocation = @"Resources\untitled.png",
					SizeMode = PictureBoxSizeMode.AutoSize,
					Margin = new Padding(0),
					Padding = new Padding(0)
				};
				ImagesFlowLayoutPanel.Controls.Add(image);
			}
			ResumeLayout(true);
		}
	}
}
