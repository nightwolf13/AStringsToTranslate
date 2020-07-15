# AStringsToTranslate
Extracts strings which should be translated from the android project.
Produces strings.xml to output folder (--targetPath) contains of not translated strings got from source language (--source) strings.xml file.
Also put source.xml to output folder - full source resource file.

Warning source language must have full translation. By default used language located in 'values' folder.

Version 1.1

  -p, --projectPath    Android project path (where src folder is located) (required).

  -t, --targetPath     Where to copy resource files (required).

  -s, --source         Source language (optional).

  --help               Display help.

  --version            Display version information.