using FileSizeGenerator_Library.Configs;
using FileSizeGenerator_Library.Helpers;
using FileSizeGenerator_Library.Writer;

namespace FileSizeGenerator_Library.FileCreators
{
	internal class ApiBigFileCreator : AbstractBigFileCreator
	{
		private string pathToFile;
		private string element;
		private int number;
		private Units units;
		private string docType;

		internal ApiBigFileCreator(string pathToFile, string element, int number, Units units, string docType)
		{
			this.pathToFile = pathToFile;
			this.element = element;
			this.number = number;
			this.units = units;
			this.docType = docType;
		}

		internal override void CreateBigFile()
		{
			Config.SetConfig(pathToFile);

			var xmlParser = new XmlParser(new WriterWithoutLines());
			xmlParser.GetFilesWithPartsOfXml(element, pathToFile, docType);

			var iterations = new IterationsFinder().GetIterationsToNeededSize(number, units);
			var filePreparator = new FilePreparator(new WriterLines(), new Cloner(iterations));
			filePreparator.GetFileAfterClone();

			new Cleaner().CleaningAfterCreatedFuf();
		}
	}
}