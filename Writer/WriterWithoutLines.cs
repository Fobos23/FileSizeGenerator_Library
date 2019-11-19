using System.IO;
using System.Text;

namespace FileSizeGenerator_Library.Writer
{
	internal class WriterWithoutLines : AbstractWriter
	{
		internal override void Write(string pathOrFileName, string file)
		{
			using (var sw = new StreamWriter(Path.GetFullPath(pathOrFileName), true, Encoding.Default))
			{
				sw.Write(file);
			}
		}
	}
}