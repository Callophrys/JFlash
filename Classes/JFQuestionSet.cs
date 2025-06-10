namespace JFlash.Classes
{
    class JFQuestionSet
    {
        public List<JFQuestion> Questions = [];
        public JFQuestion? CurrentQuestion;
        public int countAttempted, countCorrect, countWrong;
        public int questionNumber;
        public bool isFinished;
        public int Hours, Minutes, Seconds;

        private readonly Dictionary<string, JFQuestionFile> QuestionFiles;

        public JFQuestionSet(Dictionary<string, JFQuestionFile> questionFiles, int countQuestions, int countAttempted)
        {
            QuestionFiles = questionFiles;

            this.countAttempted = countAttempted;
            countCorrect = 0;
            countWrong = 0;

            questionNumber = 0;
            isFinished = false;
            Hours = Minutes = Seconds = 0;

            foreach (var qf in QuestionFiles)
            {
                foreach (var q in qf.Value.Questions)
                {
                    q.Title = qf.Value.Description;
                    Questions.Add(q);
                }
            }

            ShuffleElements(Questions, countQuestions);
        }

        static void ShuffleElements(IList<JFQuestion> questionsList, int size)
        {
            JFQuestion temporary;
            int randomNum, last;
            Random rnd = new(DateTime.UtcNow.Millisecond);

            for (last = size; last > 1; last--)
            {
              randomNum = rnd.Next(size) % last;
              temporary = questionsList[randomNum];
              questionsList[randomNum] = questionsList[last - 1];
              questionsList[last - 1] = temporary;
            }
        }

        public JFQuestion? NextQuestion()
        {
            if (questionNumber < Questions.Count)
            {
                CurrentQuestion = Questions[questionNumber];
                isFinished = ++questionNumber >= countAttempted;
            }

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
