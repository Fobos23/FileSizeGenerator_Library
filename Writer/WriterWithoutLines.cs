using System.IO;
using System.Text;

namespace FileSizeGenerator_Library.Writer
{
	internal class WriterWithoutLines : AbstractWriter
	{
		internal override void Write(string fileName, string file)
		{
			using (var sw = new StreamWriter(Path.GetFullPath(fileName), true, Encoding.Default))
			{
				sw.Write(file);
			}
		}
	}
}