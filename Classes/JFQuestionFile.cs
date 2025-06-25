namespace JFlash.Classes;

public class JfQuestionFile(string filename) : QuestionFile(filename)
{
    public List<JfQuestion> JfQuestions = [];

    public void DoIt(string prompt, string description)
    {
        Prompt = prompt;
        Description = description;
    }

    public void GenerateQuestions(int idxFrom, int idxTo)
    {
        foreach (string question in Questions)
        {
            JfQuestion? jfQuestion = new(question.Trim(), idxFrom, idxTo);

            // Make sure question is usable
            if (!string.IsNullOrEmpty(jfQuestion.Answer))
            {
                JfQuestions.Add(jfQuestion);
            }
        }
    }
}
