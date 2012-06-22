using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Thumbnailer
{
	partial class ThumbnailerWindow : Form
	{
		private bool needsRefresh;
		public ThumbnailerWindow()
		{
			InitializeComponent();
		}

		private Thumbnail thumbnail;
		public Thumbnail Thumbnail
		{
			get { return thumbnail; }
			set
			{
				if (thumbnail != value)
				{
					thumbnail = value;
					needsRefresh = true;
				}
			}
		}
	}
}
