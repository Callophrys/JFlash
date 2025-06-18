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

public static class JFQuestionFileFactory
{
    public static JFQuestionFile GenerateQuestionFile(
        string filename,
        int idxFrom,
        int idxTo)
    {
        var qf = new JFQuestionFile(filename);
        qf.GenerateQuestions(idxFrom, idxTo);
        return qf;
    }

    public static JFQuestionFile GenerateQuestionFile(
        List<string> questions,
        int idxFrom,
        int idxTo)
    {
        var qf = new JFQuestionFile("");
        qf.Questions.AddRange(questions);
        qf.GenerateQuestions(idxFrom, idxTo);
        return qf;
    }

    public static Dictionary<string, JFQuestionFile> GenerateQuestionFiles(
        Dictionary<string, List<string>> source,
        int idxFrom,
        int idxTo)
    {
        Dictionary<string, JFQuestionFile> result = [];
        foreach (string key in source.Keys)
        {
            result.Add(key, GenerateQuestionFile(source[key], idxFrom, idxTo));
        }

        return result;
    }
}
