using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JFlash
{
    public static class StringExtensions
    {
        public static string Scrub(this string item) => item.Replace(",,", ",").Trim([',', ' ']).Replace(",", ", ");
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
        public string Question = string.Empty;

        /// <summary>
        /// All remaining information to show and/or assist the user.
        /// </summary>
        public string Additional = string.Empty;

        public bool HasMultipleAnswers => Answer.Contains(',') || Answer.Contains('，');

        private readonly List<string> sourceParts;

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

        public bool IsEntryCorrect(String ans)
        {
            bool bCorrect = false;
            foreach (String p in Answer.Split([',', '，']))
            {
                bCorrect |= (String.Compare(ans, p, true) == 0);
            }
            return bCorrect;
        }
    }
}
