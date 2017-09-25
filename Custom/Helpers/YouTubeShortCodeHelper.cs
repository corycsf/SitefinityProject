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
                var videoID = match.Value.Substring(9, match.Value.Length - 9 - 1).Split(',')[0].Replace("ID=", "");
                var splitValues = match.Value.Split(',');
                var autoplay = splitValues[1].Split('=')[1];
                var controls = splitValues[2].Split('=')[1];
                var loop = splitValues[3].Split('=')[1];
                var info = splitValues[4].Split('=')[1].Replace("]", "");

                // replace shortcode text with YouTube embed HTML
                string playerResult = $@"<iframe width=""560"" height=""315"" autoplay=""{autoplay}"" controls=""{controls}"" loop=""{loop}"" showinfo=""{info}"" src=""http://www.youtube.com/embed/{videoID}"" frameborder=""0"" allowfullscreen></iframe>";

                //string player = string.Format(@"<iframe width=""560"" height=""315"" src=""http://www.youtube.com/embed/{0}"" frameborder=""0"" allowfullscreen></iframe>", videoID);

                result = result.Replace(match.Value, playerResult);
            }

            return result;
        }
    }
}