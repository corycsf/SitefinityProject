using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SitefinityWebApp.Custom.Helpers
{
    public static class YouTubeShortCodeHelper
    {
        /// <summary>
        /// Expands all YouTube shortcodes in the specified text
        /// </summary>
        /// <param name="inputText">The input text.</param>
        /// <returns></returns>
        public static string Expand(object inputText)
        {
            if (inputText == null) return string.Empty;
            var result = inputText.ToString();

            // use regex to find matches
            string regex__1 = @"\[youtube:.*?\]";
            MatchCollection matches = Regex.Matches(result, regex__1);

            foreach (Match match in matches)
            {
                // strip out the video id
                var videoID = match.Value.Substring(9, match.Value.Length - 9 - 1);

                // replace shortcode text with YouTube embed HTML
                string player = string.Format(@"<iframe width=""560"" height=""315"" src=""http://www.youtube.com/embed/{0}"" frameborder=""0"" allowfullscreen></iframe>", videoID);
                result = result.Replace(match.Value, player);
            }

            return result;
        }
    }
}