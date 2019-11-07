using System;
using System.IO;
using FileSizeGenerator_Library.Configs;

namespace FileSizeGenerator_Library.Helpers
{
	internal class IterationsFinder
	{
		internal long GetIterationsToNeededSize(int number, Units units)
		{
			var headersSize = GetFileLength(Config.headerFile);
			var bodysSize = GetFileLength(Config.bodyFile);
			var footerSize = GetFileLength(Config.footerFile);

			var modePow = units == Units.KB ? 1 : units == Units.MB ? 2 : 3;

			var neededSizeInBytes = (long)(number * Math.Pow(2, 10 * modePow));
			var iterations = ((neededSizeInBytes - headersSize - footerSize) / bodysSize);

			return iterations;
		}

		private long GetFileLength(string fileName)
		{
			return new FileInfo(Path.GetFullPath(fileName)).Length;
		}
	}
}