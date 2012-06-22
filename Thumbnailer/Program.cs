using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Thumbnailer.Properties;

namespace Thumbnailer
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if (args.Length > 0)
			{
				CreateThumbnailForImage(args[0]);
			}
			else
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new ThumbnailerWindow());
			}
		}

		private static void CreateThumbnailForImage(string path)
		{
			var pathInfo = new FileInfo(path);
			path = pathInfo.FullName;

			var thumb = new Thumbnail(path);

			var thumbWidth = Settings.Default.DefaultWidth;
			var thumbHeight = Settings.Default.DefaultHeight;

			var size = new Size(thumbWidth, thumbHeight);
			var image = thumb.GetThumbnail(size);

			var newPath = Utils.GetNewFilenameForThumbnail(path);
			image.Save(newPath);
		}
	}
}
