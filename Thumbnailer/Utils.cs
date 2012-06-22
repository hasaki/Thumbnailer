using System;
using System.Globalization;
using System.IO;
using Thumbnailer.Properties;

namespace Thumbnailer
{
	static internal class Utils
	{
		public static string GetNewFilenameForThumbnail(string path)
		{
			var extension = Path.GetExtension(path).Remove(0, 1);
			var filename = Path.GetFileNameWithoutExtension(path);
			var rootAndDir = Path.Combine(Path.GetPathRoot(path), Path.GetDirectoryName(path));

			var newPath = "";

			var filenamePattern = Settings.Default.DefaultFilenamePattern;

			if (filenamePattern.IndexOf("{2}", System.StringComparison.InvariantCulture) >= 0)
			{
				var duplicateIndexStr = "";
				var duplicateIndex = 0;

				do
				{
					var newFilename = String.Format(Settings.Default.DefaultFilenamePattern, filename, extension,
					                                duplicateIndexStr);

					duplicateIndex++;
					duplicateIndexStr = duplicateIndex.ToString(CultureInfo.InvariantCulture);

					newPath = Path.Combine(rootAndDir, newFilename);
				} while (File.Exists(newPath));
			}
			else
			{
				var newFilename = String.Format(Settings.Default.DefaultFilenamePattern, filename, extension);
				newPath = Path.Combine(rootAndDir, newFilename);
			}

			return newPath;
		}
	}
}