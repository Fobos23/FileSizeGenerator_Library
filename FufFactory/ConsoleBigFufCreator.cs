using FileSizeGenerator_Library.Configs;
using FileSizeGenerator_Library.Helpers;
using FileSizeGenerator_Library.Writer;

namespace FileSizeGenerator_Library.FufFactory
{
	internal class ConsoleBigFufCreator : AbstractFufFactory
	{
		private ParsedInputParams _params;
		internal ConsoleBigFufCreator(string inputParams)
		{
			_params = new ParsedInputParams(inputParams);
		}

		internal override void CreateBigFuf()
		{
			Config.SetConfig(_params.pathToFile);

			var xmlParser = new XmlParser(new WriterWithoutLines());
			xmlParser.GetFilesWithPartsOfXml(_params.element, _params.pathToFile, _params.docType);

			var iterations = new IterationsFinder().GetIterationsToNeededSize(_params.number, _params.units);
			var filePreparator = new FilePreparator(new WriterLines(), new ClonerWithLoader(iterations));
			filePreparator.GetFileAfterClone();

			new Cleaner().CleaningAfterCreatedFuf();
		}
	}
}