using FileSizeGenerator_Library.Configs;
using FileSizeGenerator_Library.FileCreators;

namespace FileSizeGenerator_Library
{
	public class ApiClient
	{
		/// <summary>
		/// Увеличивает переданный файл до заданного размера
		/// </summary>
		/// <param name="pathToFile"> Название файла с расширением, если он лежит в дефолтной директории. Или путь до файла из другой директории. </param>
		/// <param name="element"> Название элемента xml, который будет клонироваться. </param>
		/// <param name="number"> Требуемый размер (число). </param>
		/// <param name="units"> Требуемая размерность (KB, MB, GB). </param>
		/// <param name="docType"> Тип документа из xml. Обычно это вторая строка в xml (например: Файл)</param>
		public void GetBigFile(string pathToFile, string element, int number, Units units, string docType)
		{
			new ApiBigFileCreator(pathToFile, element, number, units, docType).CreateBigFile();
		}
	}
}