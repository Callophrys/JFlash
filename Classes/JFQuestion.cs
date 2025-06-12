using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace JFlash
{
    public partial class JFQuestion
    {
        /// <summary>
        /// Correct answer. This is the value to be entered by the user.
        /// </summary>
        public string Answer = string.Empty;

        /// <summary>
        /// The correct multi-answer formatted for display. 
        /// </summary>
        public string FormattedAnswer => Answer.Replace(",", ", ");

        /// <summary>
        /// Source question. This is read by the user and requires a response.
        /// </summary>
        public string Prompt = string.Empty;

        /// <summary>
        /// Description heading of current question file.
        /// </summary>
        public string Title = string.Empty;

        /// <summary>
        /// All remaining information to show and/or assist the user.
        /// </summary>
        public string Additional = string.Empty;

        /// <summary>
        /// The additional with commas formatted for display. 
        /// </summary>
        public string FormattedAdditional => Answer.Replace(",", ", ");

        /// <summary>
        /// Pointer to meaning of desired word. E.g. provide help when there is
        /// the same answer for more than one kanji.
        /// </summary>
        public string Hint = string.Empty;

        public bool HasMultipleAnswers => Answer.Contains(',') || Answer.Contains('，');

        private readonly List<string> sourceParts;

        /// <summary>
        /// Regular expression for a comma or JP comma flanked by any number of spaces.
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex(" *[,，] *")]
        private static partial Regex RegExCommas();

        /// <summary>
        /// Regular expression for two or more spaces.
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex("  +")]
        private static partial Regex RegExSpaces();

        public JFQuestion(string sourceLine, int idxFrom, int idxTo)
        {
            sourceParts = [.. sourceLine.Split([';', '；'], StringSplitOptions.None).Select(x => x.Scrub())];
            if (idxFrom < sourceParts.Count && idxTo < sourceParts.Count)
            {
                UpdateQuestion(idxFrom, idxTo);
            }
        }

        public string ScrubbedAnswer(string userEntry) => Answer.Replace(userEntry, string.Empty).Scrub();

        public void UpdateQuestion(int idxFrom, int idxTo)
        {
            Prompt = sourceParts[idxFrom];
            Answer = sourceParts[idxTo];

            if (sourceParts.Count > 5)
            {
                Hint = sourceParts[5];
            }

            var extra = new List<string>();
            for (var i = 0; i < sourceParts.Count; ++i)
            {
                if (i != idxFrom && i != idxTo)
                {
                    extra.Add(sourceParts[i]);
                }
            }

            Additional = string.Join("  /  ", extra);
        }

        public bool IsEntryCorrect(string ans)
        {
            if (string.IsNullOrWhiteSpace(ans)) return false;

            // Condition here since commas should be rare if at all.
            ans = ans.IndexOfAny([',', '，']) > -1 ? RegExCommas().Replace(ans, ", ") : ans;

            ans = RegExSpaces().Replace(ans, " ");
            ans = ans.Trim([' ', ',', '，']);

            bool result = false;
            foreach (string p in Answer.Split([',', '，'], StringSplitOptions.TrimEntries))
            {
                result |= string.Equals(ans, p, StringComparison.CurrentCultureIgnoreCase);
            }

            return result;
        }
    }
}
