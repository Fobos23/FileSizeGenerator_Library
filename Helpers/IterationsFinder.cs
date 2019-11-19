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

			var neededSizeInBytes = (long)(number * Math.Pow(2, 10 * (int)units));
			var iterations = ((neededSizeInBytes - headersSize - footerSize) / bodysSize);

			return iterations;
		}

		private long GetFileLength(string fileName)
		{
			return new FileInfo(Path.GetFullPath(fileName)).Length;
		}
	}
}