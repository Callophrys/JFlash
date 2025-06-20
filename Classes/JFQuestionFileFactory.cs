namespace JFlash.Classes;

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
