An application that can take an Android project's string.xml file and automatically translate it for multiple languages.

Version 2.0 was just released and it adds support for multiple translator sources. The most comprehensive is Microsoft Translator.

Supported Languages
-------------------
  * Arabic
  * Bulgarian
  * Chinese (Simplified and Traditional)
  * Czech
  * Danish
  * Dutch
  * Estonian
  * Finnish
  * French
  * German
  * Greek (Modern)
  * Haitian Creole
  * Hebrew
  * Hungarian
  * Japanese
  * Korean
  * Italian
  * Latvian
  * Lithuanian
  * Norwegian
  * Polish
  * Portuguese
  * Romanian
  * Russian
  * Slovak
  * Spanish
  * Swedish
  * Thai
  * Turkish

Instructions
------------
 1. Make sure you have a res/values/string.xml file in your Android Project and it has all the string resources you want to translate.
 1. Download the zip file.
 1. Extract the zip file and run {{{AndroidStringResourceTranslator.exe}}}
 1. Select the base directory of your Android project.
   1. The directory should contain {{{AndroidManifest.xml}}}
 1. Select the {{{Translation Provider}}}. The default is the best one.
 1. Select the {{{Original Language}}} The list is abbreviated with ISO639 lettering. En is english. (I'll fix that later)
 1. Click the Run button and wait. You'll see the text "Completed" when it is finished.

*It is important that you backup your project before you run this utility against it. I am not liable for damages to your project.

This application requires .NET Framework 4.0 to use.*
