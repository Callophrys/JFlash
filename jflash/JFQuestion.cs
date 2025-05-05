using System;
using System.Collections.Generic;
using System.Text;

namespace jflash
{
    public class JFQuestion
    {
        public String m_strAnswer;
        public String m_strQuestion;
        public String m_strPrompt;
        private Boolean m_bMulipleAnswers;

        public JFQuestion(String SourceLine, JFQuestionFile Parent)
        {
            // Divide line into q & a, separated by semicolon
            m_strPrompt = Parent.m_strPrompt;

            m_strAnswer = SourceLine.Substring(SourceLine.IndexOf(';')+1);
            m_strQuestion = SourceLine.Substring(0, SourceLine.IndexOfAny(new char[] { ';', (char)0xff1b }));
            if (String.IsNullOrEmpty(m_strAnswer))
            {
                // No answer
            }
            if (String.IsNullOrEmpty(m_strQuestion))
            {
                // No question
            }
            m_bMulipleAnswers = m_strAnswer.Contains(",");
        }

        public Boolean HasMultipleAnswers()
        {
            return m_bMulipleAnswers;
        }

        public Boolean IsEntryCorrect(String ans)
        {
            Boolean bCorrect = false;
            foreach (String p in m_strAnswer.Split(','))
            {
                bCorrect |= (String.Compare(ans, p, true) == 0);
            }
            return bCorrect;
        }
    }
}
