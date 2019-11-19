using System.IO;
using System.Text;
using FileSizeGenerator_Library.Configs;
using FileSizeGenerator_Library.Writer;

namespace FileSizeGenerator_Library.Helpers
{
	public class FilePreparator
	{
		private AbstractWriter writer;
		private AbstractWriter cloner;
		internal FilePreparator(AbstractWriter writer, AbstractWriter cloner)
		{
			this.writer = writer;
			this.cloner = cloner;
		}

		internal void GetFileAfterClone()
		{
			var nameOfNewFile = Config.newFileName;
			var header = Read(Config.headerFile);
			var body = Read(Config.bodyFile);
			var footer = Read(Config.footerFile);

			writer.Write(nameOfNewFile, header);
			cloner.Write(nameOfNewFile, body);
			writer.Write(nameOfNewFile, footer);
		}

		private static string Read(string pathToFile)
		{
			using (var sr = new StreamReader(pathToFile, Encoding.Default))
			{
				return sr.ReadToEnd();
			}
		}
	}
}