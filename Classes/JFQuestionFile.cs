namespace JFlash.Classes;

public class JFQuestionFile(string filename) : QuestionFile(filename)
{
    public List<JFQuestion> JfQuestions = [];

    public void GenerateQuestions(int idxFrom, int idxTo)
    {
        foreach (string question in Questions)
        {
            JFQuestion? jfQuestion = new(question.Trim(), idxFrom, idxTo);

            // Make sure question is usable
            if (!string.IsNullOrEmpty(jfQuestion.Answer))
            {
                JfQuestions.Add(jfQuestion);
            }
        }
    }
}
