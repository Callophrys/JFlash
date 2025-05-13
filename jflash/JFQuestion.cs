using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JFlash
{
    public class JFQuestion
    {
        /// <summary>
        /// Correct answer. This is the value to be entered by the user.
        /// </summary>
        public String Answer;

        /// <summary>
        /// Source question. This is read by the user and requires a response.
        /// </summary>
        public String Question;

        /// <summary>
        /// All remaining information to show and/or assist the user.
        /// </summary>
        public String Additional;

        public Boolean HasMultipleAnswers => Answer.Contains(',') || Answer.Contains('，');
        public IList<string> sourceParts;

        public JFQuestion(String SourceLine, JFQuestionFile Parent, int idxFrom, int idxTo)
        {
            // Divide line into q & a, separated by semicolon
            //Prompt = Parent.Prompt;
            sourceParts = SourceLine.Split(new char[]{';', '；' }, StringSplitOptions.None).ToList();

            UpdateQuestion(idxFrom, idxTo);
        }

        public void UpdateQuestion(int idxFrom, int idxTo)
        {
            Question = sourceParts[idxFrom].Trim();
            Answer = sourceParts[idxTo].Trim();

            var extra = new List<string>();
            for (var i = 0; i < sourceParts.Count; ++i)
            {
                if (i != idxFrom && i != idxTo)
                {
                    extra.Add(sourceParts[i].Trim());
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
