using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;

namespace biaphasprogform
{
	public partial class Form1 : Form
	
	{int tick = 0;
		public Form1()
		{
			InitializeComponent();

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void Form1_Load_1(object sender, EventArgs e)
		{

		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			string text = textBox1.Text;
			
			{
				string[] charactersToRemove = { "@", "_", "-", "(", ")", "+", "=", ",", "\"", "'", ";", "`", "\\" };

				foreach (string character in charactersToRemove)
				{
					text = text.Replace(character, "");
				}
			}


			{
				text = text
					.Replace("0", "ZERO_")
					.Replace("1", "ONE_")
					.Replace("2", "TWO_")
					.Replace("3", "THREE_")
					.Replace("4", "FOUR_")
					.Replace("5", "FIVE_")
					.Replace("6", "SIX_")
					.Replace("7", "SEVEN_")
					.Replace("8", "EIGHT_")
					.Replace("9", "NINE_");
			}


			{
				text = text
					.Replace(".", "END_SENTENCE_")
					.Replace(" ", "_")
					.Replace("!", "END_EXCLAMATION_")
					.Replace("?", "END_Question_");
			}


			{
				text = text.ToUpper();
			}


			{
				// make sure the text length is a multiple of 2
				if ((text.Length % 2) > 0)
				{
					text += "_";
				}

				// store off the length because it is going to change as we add characters
				int length = text.Length;
				for (int i = 2; i < length; i += 2)
				{
					text = text.Insert(i, " ");

					// skip over the character we just added and increase the length by 1
					++i;
					++length;
				}

				// make sure the text length is a multiple of 2
				if ((text.Length % 2) > 0)
				{
					text += "_";
				}
			}


			{
				// Convert Unicode to Bytes

				byte[] uni = Encoding.Unicode.GetBytes(text);

				// Convert to ASCII

				string textAscii = Encoding.ASCII.GetString(uni);
				// go through each pair of characters and convert them to digits
				// it should be an even number of characters at this point
				int length = textAscii.Length;
				int test = length;
				for (int i = 0; i < length; i += 5) // + 5 for '0000 ' we want to get to the next place where there is a letter
				{
					if (i < length - 2)
					{
						for (int ii = 0; ii < 2; ++ii)
						{
							int index = i + (ii * 2);

							if (textAscii[index] == '_')
							{
								textAscii = textAscii.Insert(index, "00");
							}
							else
							{
								// - 64 gets 'A' to 1, B to 2, etc.
								// + 26 gets us to the next bigger number after Z

								int character = (int)textAscii[index];
								int transformedCharacter = character - 64 + (ii > 0 ? 26 : 0);

								// each letter was one character, each number we are inserting is from 1 to 2 character, let's 0 pad them all to 2 characters
								// and remove the letter or symbol we just converted

								textAscii = textAscii.Insert(index, transformedCharacter.ToString().PadLeft(2, '0'));
							}

							textAscii = textAscii.Remove(index + 2, 1);
						}

						// we have added a 2 characters and then removed 1 so we need to update length
						length = textAscii.Length;
						textBox1.Text = text;
					}
				}
			}
           
		}

        private void progressBar1_Click(object sender, EventArgs e)
        {
			SoundPlayer sound;
			sound = new SoundPlayer(@"C:\Users\Owner\source\repos\bialphasprog\bialphasprog\biaphasprogform\obj\Debug\Windows Background.wav");
			sound.Play();

		}

        private void timer1_Tick(object sender, EventArgs e)
        {
			tick = tick + 1;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
		
	}
}

		
	

