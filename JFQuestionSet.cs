namespace JFlash
{
    class JFQuestionSet
    {
        public JFQuestion[] Questions;
        public JFQuestion? CurrentQuestion;
        public int countAttempted, countCorrect, countWrong;
        public int questionNumber;
        public bool isFinished;
        public int Hours, Minutes, Seconds;

        private readonly JFQuestionFile[] QuestionFiles;

        public JFQuestionSet(IList<JFQuestionFile> Files, int TotQs, int NumQs)
        {
            int k;

            QuestionFiles = [.. Files];
            countAttempted = NumQs;
            countCorrect = 0;
            countWrong = 0;

            questionNumber = 0;
            isFinished = false;
            Hours = Minutes = Seconds = 0;

            Questions = new JFQuestion[TotQs];

            k=0;
            for (int i = 0; i < Files.Count; i++)
            {
                for (int j = 0; j < Files[i].Questions.Count; j++)
                {
                    Questions[k] = Files[i].Questions[j];
                    k++;
                }
            }

            ShuffleElements(Questions, TotQs);
        }

        static void ShuffleElements(JFQuestion[] theArr, int size)
        {
            JFQuestion temporary;
            int randomNum, last;
            Random rnd = new(DateTime.UtcNow.Millisecond);

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
            CurrentQuestion = Questions[questionNumber];
            isFinished = (++questionNumber >= countAttempted);
            return CurrentQuestion;
        }

        public bool IsEntryCorrect (string ans)
        {
            bool result = CurrentQuestion?.IsEntryCorrect(ans) ?? false;
            if (result)
                countCorrect++;
            else
                countWrong++;
            return result;
        }
    }
}
