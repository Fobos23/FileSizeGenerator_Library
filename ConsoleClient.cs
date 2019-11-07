using System;
using FileSizeGenerator_Library.FufFactory;

namespace FileSizeGenerator_Library
{
	public class ConsoleClient
	{
		public void GetBigFuf()
		{
			Console.WriteLine("Введите команду запроса по следующему шаблону: \n{НазваниеФайла.СРасширением} {НазваниеЭлемента} {Размер(число)} {Размерность(KB,MB,GB)} {ТипДокумент}");
			var inputParams = Console.ReadLine();
			new ConsoleBigFufCreator(inputParams).CreateBigFuf();
		}
	}
}