using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Custom.Helpers
{
    public static class ShortcodeProcessor
    {
        /// <summary>
        /// Expands all shortcodes within the specified text.
        /// </summary>
        /// <param name="textToProcess">The text to process.</param>
        /// <returns></returns>
        public static string Execute(string textToProcess)
        {
            textToProcess = YouTubeShortCodeHelper.Expand(textToProcess);

            return textToProcess;
        }
    }
}