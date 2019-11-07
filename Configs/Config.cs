using System;

namespace FileSizeGenerator_Library.Configs
{
	internal class Config
	{
		public static readonly string nameMode = $"{DateTime.Now:yyyyMMddhhmmss}";
		public static readonly string headerFile = $"header {nameMode}.xml";
		public static readonly string bodyFile = $"body {nameMode}.xml";
		public static readonly string footerFile = $"footer {nameMode}.xml";
	}
}