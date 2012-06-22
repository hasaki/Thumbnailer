using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Thumbnailer
{
	sealed class Thumbnail
	{
		public Thumbnail(string path)
		{
			File = new FileInfo(path);
			OriginalImage = Image.FromFile(File.FullName);
		}

		public FileInfo File { get; private set; }
		public Image OriginalImage { get; private set; }
		
		public Image GetThumbnail(Size size)
		{
			if (OriginalImage == null)
				return null;

			var widthProportion = size.Width / ((float)OriginalImage.Width);
			var heightProportion = size.Height / ((float)OriginalImage.Height);

			var ratio = Math.Min(widthProportion, heightProportion);

			var newSize = new Size((int)(ratio * OriginalImage.Width), (int)(ratio * OriginalImage.Height));

			var thumbnail = new Bitmap(OriginalImage, newSize);

			return thumbnail;
		}
	}
}
