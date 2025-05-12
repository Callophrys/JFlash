using System;
using System.Collections.Generic;
using System.Text;

namespace jflash
{
    public class JFQuestion
    {
        public String Answer;
        public String Question;
        public String Additional;
        public String Prompt;
        public Boolean HasMultipleAnswers => Answer.Contains(",");

        public JFQuestion(String SourceLine, JFQuestionFile Parent)
        {
            // Divide line into q & a, separated by semicolon
            Prompt = Parent.Prompt;

            var sourceParts = SourceLine.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            Answer = sourceParts[1].Trim();
            Question = sourceParts[0].Trim();

            if (sourceParts.Length > 2)
            {
                Additional = sourceParts[2].Trim();
            }
        }

        public Boolean IsEntryCorrect(String ans)
        {
            Boolean bCorrect = false;
            foreach (String p in Answer.Split(','))
            {
                bCorrect |= (String.Compare(ans, p, true) == 0);
            }
            return bCorrect;
        }
    }
}
