using System;
using System.IO;
using System.Text;

namespace FileSizeGenerator_Library.Writer
{
	internal class ClonerWithLoader : AbstractWriter
	{
		private long iterations;

		internal ClonerWithLoader(long iterations)
		{
			this.iterations = iterations;
		}

		internal override void Write(string pathOrFileName, string file)
		{
			using (var sw = new StreamWriter(Path.GetFullPath(pathOrFileName), true, Encoding.Default))
			{
				int integerPercent = 0;
				long actualPercent = 0;

				for (var i = 0; i <= iterations; i++)
				{
					sw.WriteLine(file);
					actualPercent = i * 100 / iterations;
					if (actualPercent <= integerPercent) continue;
					Console.Write($"Загрузка... {actualPercent}%\r");
					integerPercent++;
				}
				Console.WriteLine("Загрузка завершена!");
			}
		}
	}
}