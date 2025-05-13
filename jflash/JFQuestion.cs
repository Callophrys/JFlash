using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JFlash
{
    public class JFQuestion
    {
        public String Answer;
        public String Question;
        public String Additional;
        //public String Prompt;
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
                    extra.Prepend(sourceParts[i].Trim());
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
