using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JFlash
{
    public static class StringExtensions
    {
        public static string Scrub(this string item) => item.Replace(",,", ",").Trim(new char[]{',', ' '}).Replace(",", ", ");
    }

    public class JFQuestion
    {
        /// <summary>
        /// Correct answer. This is the value to be entered by the user.
        /// </summary>
        public string Answer = string.Empty;

        /// <summary>
        /// Source question. This is read by the user and requires a response.
        /// </summary>
        public String Question = string.Empty;

        /// <summary>
        /// All remaining information to show and/or assist the user.
        /// </summary>
        public String Additional = string.Empty;

        public Boolean HasMultipleAnswers => Answer.Contains(',') || Answer.Contains('，');

        private IList<string> sourceParts;

        public JFQuestion(String SourceLine, JFQuestionFile Parent, int idxFrom, int idxTo)
        {
            sourceParts = SourceLine.Split(new char[]{';', '；' }, StringSplitOptions.None).Select(x => x.Scrub()).ToList();

            UpdateQuestion(idxFrom, idxTo);
        }

        public string ScrubbedAnswer(string userEntry) => Answer.Replace(userEntry, string.Empty).Scrub();

        public void UpdateQuestion(int idxFrom, int idxTo)
        {
            Question = sourceParts[idxFrom];
            Answer = sourceParts[idxTo];

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

        public Boolean IsEntryCorrect(String ans)
        {
            Boolean bCorrect = false;
            foreach (String p in Answer.Split(new char[] { ',', '，'}))
            {
                bCorrect |= (String.Compare(ans, p, true) == 0);
            }
            return bCorrect;
        }
    }
}
