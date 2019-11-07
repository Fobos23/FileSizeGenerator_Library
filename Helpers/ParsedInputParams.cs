using System;
using System.Collections.Generic;
using FileSizeGenerator_Library.Configs;

namespace FileSizeGenerator_Library.Helpers
{
	internal class ParsedInputParams
	{
		internal string pathToFile;
		internal string element;
		internal int number;
		internal Units units;
		internal string docType;

		internal ParsedInputParams(string inputParams)
		{
			var parsedParams = inputParams.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			pathToFile = parsedParams[0];
			element = parsedParams[1];
			number = int.Parse(parsedParams[2]);
			units = UnitsAdapter[parsedParams[3]];
			docType = parsedParams[4];
		}

		private Dictionary<string, Units> UnitsAdapter = new Dictionary<string, Units>
		{
			["KB"] = Units.KB,
			["MB"] = Units.MB,
			["GB"] = Units.GB
		};
	}
}