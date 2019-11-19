using System;
using System.IO;

namespace FileSizeGenerator_Library.Configs
{
	internal class Config
	{
		public static string fileDirectory;
		public static string nameMode;
		public static string headerFile;
		public static string bodyFile;
		public static string footerFile;
		public static string newFileName;

		internal static void SetConfig(string pathToXml)
		{
			fileDirectory = $"{Path.GetDirectoryName(Path.GetFullPath(pathToXml))}\\";
			nameMode = $"{DateTime.Now:yyyyMMddhhmmss}";
			headerFile = $"{fileDirectory}header {nameMode}.xml";
			bodyFile = $"{fileDirectory}body {nameMode}.xml";
			footerFile = $"{fileDirectory}footer {nameMode}.xml";
			newFileName = $"{fileDirectory}FileAfterCloning {nameMode}.xml";
		}
	}
}