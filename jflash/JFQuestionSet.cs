using System;
using System.Collections.Generic;
using System.Text;

namespace jflash
{
    class JFQuestionSet
    {
        public JFQuestion[] Questions;
        public JFQuestion m_CurrentQuestion;
        public int m_iCtDesired, m_iNumRight, m_iNumWrong;
        public int m_iQuestionNo;
        public Boolean m_bFinished;
        public int Hours, Minutes, Seconds;

        private JFQuestionFile[] QuestionFiles;

        public JFQuestionSet(JFQuestionFile[] Files, int TotQs, int NumQs)
        {
            int k;

            QuestionFiles = Files;
            m_iCtDesired = NumQs;
            m_iNumRight = 0;
            m_iNumWrong = 0;

            m_iQuestionNo = 0;
            m_bFinished = false;
            Hours = Minutes = Seconds = 0;

            Questions = new JFQuestion[TotQs];

            k=0;
            for (int i = 0; i < Files.Length; i++)
            {
                for (int j = 0; j < Files[i].m_iNumQuestions; j++)
                {
                    Questions[k] = Files[i].m_Questions[j];
                    k++;
                }
            }
            shuffleElements(Questions, TotQs);
        }

        void shuffleElements(JFQuestion[] theArr, int size)
        {
            JFQuestion temporary;
            int randomNum, last;
            Random rnd = new Random();

            for (last = size; last > 1; last--)
            {
              randomNum = rnd.Next(size) % last;
              temporary = theArr[randomNum];
              theArr[randomNum] = theArr[last - 1];
              theArr[last - 1] = temporary;
            }
        }// end shuffleElements( )

        public JFQuestion NextQuestion()
        {
            m_CurrentQuestion = Questions[m_iQuestionNo];
            m_bFinished = (++m_iQuestionNo >= m_iCtDesired);
            return m_CurrentQuestion;
        }

        public Boolean IsEntryCorrect (String ans)
        {
            Boolean r;
            r = m_CurrentQuestion.IsEntryCorrect(ans);
            if (r)
                m_iNumRight++;
            else
                m_iNumWrong++;
            return r;
        }
    }
}
