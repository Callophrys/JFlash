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
        /// The correct answer formatted cleaned up, if multi-answer, for display. 
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
        /// This basically is all the answers minus those being used.
        /// </summary>
        public string Additional = string.Empty;

        /// <summary>
        /// The additional with commas formatted for display. 
        /// </summary>
        public string FormattedAdditional => Additional.Replace(",", ", ");

        /// <summary>
        /// Name of the set. Taken from basename of respective source file.
        /// </summary>
        public string SetName = string.Empty;

        /// <summary>
        /// Pointer to meaning of desired word. E.g. provide help when there is
        /// the same answer for more than one kanji.
        /// </summary>
        public string Hint = string.Empty;

        public bool HasMultipleAnswers => Answer.Contains(',') || Answer.Contains('，');

        /// <summary>
        /// This limits parsing to non-hint and non-extra data.
        /// </summary>
        const int LimitForQuestionData = 5;

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
            // Set the prompt/query to the user.
            Prompt = sourceParts[idxFrom];

            // Set the correct answer.
            Answer = sourceParts[idxTo];

            // If hints are present. Set them.
            if (sourceParts.Count > LimitForQuestionData)
            {
                Hint = sourceParts[5];
            }

            // Build the "Additional" which means all other
            // question-answer-related data MINUS then ones
            // actually being queried and answered.
            var extra = new List<string>();
            for (var i = 0; i < Math.Min(sourceParts.Count, LimitForQuestionData); ++i)
            {
                if (i != idxFrom && i != idxTo)
                {
                    extra.Add(sourceParts[i]);
                }
            }

            // Set Additional here.
            Additional = string.Join("  /  ", extra.Distinct());
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
