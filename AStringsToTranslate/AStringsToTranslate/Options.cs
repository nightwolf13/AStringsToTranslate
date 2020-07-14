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
		[Option('p', "projectPath", Required = false, HelpText = "Android project path (where src folder is located).")]
		public string ProjectPath { get; set; }
		[Option('t', "targetPath", Required = false, HelpText = "Where to copy resource files")]
		public string TargetPath { get; set; }
	}
}
