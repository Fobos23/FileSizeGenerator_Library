using System;
using FileSizeGenerator_Library.FileCreators;

namespace FileSizeGenerator_Library
{
	public class ConsoleClient
	{
		/// <summary>
		/// Увеличивает переданный файл до заданного размера:
		/// НазваниеФайла.СРасширением - название файла с расширением, если он лежит в дефолтной директории. Или путь до файла из другой директории
		/// НазваниеЭлемента - название элемента xml, который будет клонироваться
		/// Размер(число) - требуемый размер (число)
		/// Размерность - требуемая размерность (KB, MB, GB)
		/// ТипДокумент - тип документа из xml. Обычно это вторая строка в xml (например: Файл)
		/// </summary>
		public void GetBigFile()
		{
			Console.WriteLine("Введите команду запроса по следующему шаблону:\n{НазваниеФайла.СРасширением} {НазваниеЭлемента} {Размер(число)} {Размерность(KB,MB,GB)} {ТипДокумент}");
			var inputParams = Console.ReadLine();
			new ConsoleBigFileCreator(inputParams).CreateBigFile();
		}
	}
}