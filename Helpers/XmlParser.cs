using System.IO;
using System.Text;
using System.Xml;
using FileSizeGenerator_Library.Configs;
using FileSizeGenerator_Library.Writer;

namespace FileSizeGenerator_Library.Helpers
{
	internal class XmlParser
	{
		private AbstractWriter writer;
		internal XmlParser(AbstractWriter writer)
		{
			this.writer = writer;
		}

		internal void GetFilesWithPartsOfXml(string neededNode, string pathToXml, string typeDoc)
		{
			var path = Path.GetFullPath(pathToXml);
			var startNode = GetLineNumberForNeededElement(neededNode, path);
			var endNode = GetLineNumberForNeededElement(neededNode, path, false);
			var endFIle = GetLineNumberForNeededElement(typeDoc, path, false);

			ReadAndParsXml(path, startNode, endNode, endFIle, out var header, out var body, out var footer);

			writer.Write(Config.headerFile, header);
			writer.Write(Config.bodyFile, body);
			writer.Write(Config.footerFile, footer);
		}

		private void ReadAndParsXml(string pathToFile, int startNode, int endNode, int endFIle, out string header, out string body, out string footer)
		{
			header = string.Empty;
			body = string.Empty;
			footer = string.Empty;

			endNode = endNode != 0 ? endNode : startNode;

			using (var sr = new StreamReader(pathToFile, Encoding.Default))
			{
				for (var i = 1; i < endFIle + 1; i++)
				{
					if (i < startNode)
						header = header == "" ? sr.ReadLine() : header + "\n" + sr.ReadLine();
					else if (i >= startNode && i <= endNode)
						body = body == "" ? sr.ReadLine() : body + "\n" + sr.ReadLine();
					else
						footer = footer == "" ? sr.ReadLine() : footer + "\n" + sr.ReadLine();
				}
			}
		}

		private int GetLineNumberForNeededElement(string neededElement, string pathToXml, bool isStartElement = true)
		{
			var xmlReader = new XmlTextReader(pathToXml);
			var lineNumber = int.MaxValue;

			if (isStartElement)
			{
				while (xmlReader.Read() && xmlReader.LineNumber < lineNumber)
					if (xmlReader.Name == neededElement)
						lineNumber = xmlReader.LineNumber;
				return lineNumber;
			}

			while (xmlReader.Read())
				if (xmlReader.Name == neededElement && xmlReader.NodeType == XmlNodeType.EndElement)
					lineNumber = xmlReader.LineNumber;

			return lineNumber;
		}

	}
}