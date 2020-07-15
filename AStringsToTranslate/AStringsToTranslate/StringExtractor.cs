using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStringsToTranslate
{
	public class StringExtractor
	{
		private Options Options { get; }

		public StringExtractor(Options options)
		{
			Options = options ?? throw new ArgumentNullException(nameof(options));
		}

		public void Extract()
		{
			AXmlResource sourceRes;
			AXmlResource[] projResources = AXmlHelper.ReadAllFiles(this.Options.ProjectPath, this.Options.SourceLanguage, out sourceRes);

			if (sourceRes == null)
			{
				throw new Exception("Default resource not found");
			}

			for (int i = 0; i < projResources.Length; i++)
			{
				AXmlResource projResource = projResources[i];
				Console.WriteLine($"Processing {projResource.Language}");
				var targetResource = new AXmlResource() { FolderParts = projResource.FolderParts };
				foreach (var resString in sourceRes)
				{
					if (!projResource.Any(r => r.Name == resString.Name))
					{
						targetResource.Add(resString.Clone());
					}
				}

				if (targetResource.Count == 0)
				{
					continue;
				}

				Console.WriteLine($"Saving {projResource.Language}");

				AXmlHelper.SaveAXml(targetResource, Path.Combine(this.Options.TargetPath, String.Join("-", targetResource.FolderParts), "strings.xml"));
			}

			Console.WriteLine("Saving initial file (source.xml)");
			AXmlHelper.SaveAXml(sourceRes, Path.Combine(this.Options.TargetPath, "source.xml"));
		}
	}
}
