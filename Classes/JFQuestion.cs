using JFlash.Classes;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace JFlash
{
    public partial class JFQuestion : QuestionEntries
    {
        /// <summary>
        /// The correct answer formatted cleaned up, if multi-answer, for display. 
        /// </summary>
        public string FormattedAnswer => Answer.Replace(",", ", ");

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
        public string Hint => BriefHint.Scrub();

        public bool HasMultipleAnswers => Answer.Contains(',') || Answer.Contains('，');

        /// <summary>
        /// TOP. This limit parsing to non-hint and non-extra data.
        /// </summary>
        const int LimitForQuestionDataTop = 7;

        /// <summary>
        /// BOTTOM. This limit parsing to non-hint and non-extra data.
        /// </summary>
        const int LimitForQuestionDataBottom = 2;

        private readonly List<string>? sourceParts;

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

        [GeneratedRegex("^[tT][oO] +")]
        private static partial Regex RegExTo();

        public JFQuestion(string sourceLine, int idxFrom, int idxTo) :
            base(sourceLine.Trim(), idxFrom, idxTo)
        {
            sourceParts = [.. sourceEntry.Select(x => x.Scrub())];
            UpdateQuestion();
        }

        public string ScrubbedAnswer(string userEntry) => Answer.Replace(userEntry, string.Empty).Scrub();

        public void UpdateQuestion()
        {
            if (sourceEntry.Length < 1) return;

            // Build the "Additional" which means all other
            // question-answer-related data MINUS then ones
            // actually being queried and answered.
            var extra = new List<string>();
            for (var i = LimitForQuestionDataBottom; i < Math.Min(sourceEntry.Length, LimitForQuestionDataTop); ++i)
            {
                if (i != indexFrom && i != indexTo)
                {
                    extra.Add(sourceEntry[i]);
                }
            }

            // Set Additional here.
            Additional = string.Join("  /  ", extra.Distinct());
        }

        public void UpdateQuestion(int idxFrom, int idxTo)
        {
            indexFrom = idxFrom;
            indexTo = idxTo;
            UpdateQuestion();
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
                if (indexTo == QuestionFields.English && Structure == "VERB")
                {
                    result |= string.Equals(RegExTo().Replace(ans, string.Empty), RegExTo().Replace(p, string.Empty), StringComparison.CurrentCultureIgnoreCase);
                }
                else
                {
                    result |= string.Equals(ans, p, StringComparison.CurrentCultureIgnoreCase);
                }
            }

            return result;
        }
    }
}
