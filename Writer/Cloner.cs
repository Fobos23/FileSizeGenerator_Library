﻿using System.IO;
using System.Text;

namespace FileSizeGenerator_Library.Writer
{
	internal class Cloner : AbstractWriter
	{
		private long iterations;

		internal Cloner(long iterations)
		{
			this.iterations = iterations;
		}

		internal override void Write(string pathOrFileName, string file)
		{
			using (var sw = new StreamWriter(Path.GetFullPath(pathOrFileName), true, Encoding.Default))
			{
				for (var i = iterations; i > 0; i--)
					sw.WriteLine(file);
			}
		}
	}
}