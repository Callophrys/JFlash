namespace JFlash.Classes
{
    class JfQuestionSet
    {
        public List<JfQuestion> Questions = [];
        public JfQuestion? CurrentQuestion;
        public int countAttempted, countCorrect, countWrong;
        public int questionNumber;
        public bool isFinished;
        public int Hours, Minutes, Seconds;

        private readonly Dictionary<string, JfQuestionFile> QuestionFiles;

        public JfQuestionSet(Dictionary<string, JfQuestionFile> questionFiles, int countQuestions, int countAttempted)
        {
            QuestionFiles = questionFiles;

            this.countAttempted = countAttempted;
            countCorrect = 0;
            countWrong = 0;

            questionNumber = 0;
            isFinished = false;
            Hours = Minutes = Seconds = 0;

            foreach (KeyValuePair<string, JfQuestionFile> qf in QuestionFiles)
            {
                foreach (JfQuestion question in qf.Value.JfQuestions)
                {
                    question.SetName = Path.GetFileNameWithoutExtension(qf.Key);
                    question.Title = qf.Value.Description;
                    Questions.Add(question);
                }
            }

            ShuffleElements(Questions, countQuestions);
        }

        static void ShuffleElements(IList<JfQuestion> questionsList, int size)
        {
            JfQuestion temporary;
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

        public JfQuestion? NextQuestion()
        {
            if (questionNumber < Questions.Count)
            {
                CurrentQuestion = Questions[questionNumber];
                isFinished = ++questionNumber >= countAttempted;
            }

            return CurrentQuestion;
        }

        public bool IsEntryCorrect(string ans)
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
