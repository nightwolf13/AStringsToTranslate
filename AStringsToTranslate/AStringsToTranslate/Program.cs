using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStringsToTranslate
{
	class Program
	{
		
		static void Main(string[] args)
		{
			Parser parser = new Parser((s) =>
			{
				s.AutoHelp = true;
				s.HelpWriter = Console.Out;
				s.IgnoreUnknownArguments = true;
			});

			parser.ParseArguments<Options>(args)
				.WithParsed<Options>((o) =>
				{
					new StringExtractor(o).Extract();
				});
		}
	}
}
