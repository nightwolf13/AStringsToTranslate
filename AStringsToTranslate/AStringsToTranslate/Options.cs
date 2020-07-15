using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStringsToTranslate
{
	public class Options
	{
		[Option('p', "projectPath", Required = true, HelpText = "Android project path (where src folder is located).")]
		public string ProjectPath { get; set; }
		[Option('t', "targetPath", Required = true, HelpText = "Where to copy resource files")]
		public string TargetPath { get; set; }
		[Option('s', "source", Required = false, HelpText = "Source language")]
		public string SourceLanguage { get; set; }
	}
}
