using System.IO;
using FileSizeGenerator_Library.Configs;

namespace FileSizeGenerator_Library.Helpers
{
	internal class Cleaner
	{
		internal void CleaningAfterCreatedFuf()
		{
			File.Delete(Path.GetFullPath(Config.headerFile));
			File.Delete(Path.GetFullPath(Config.bodyFile));
			File.Delete(Path.GetFullPath(Config.footerFile));
		}
	}
}