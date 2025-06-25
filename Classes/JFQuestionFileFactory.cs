namespace JFlash.Classes;

public static class JFQuestionFileFactory
{
    public static JfQuestionFile GenerateQuestionFile(
        string filename,
        int idxFrom,
        int idxTo,
        string prompt,
        string description)
    {
        var qf = new JfQuestionFile(filename);
        qf.GenerateQuestions(idxFrom, idxTo);
        return qf;
    }

    public static JfQuestionFile GenerateQuestionFile(
        List<string> questions,
        int idxFrom,
        int idxTo,
        string prompt,
        string description)
    {
        var qf = new JfQuestionFile("");
        qf.Prompt = prompt;
        qf.Description = description;
        qf.Questions.AddRange(questions);
        qf.GenerateQuestions(idxFrom, idxTo);
        return qf;
    }

    public static Dictionary<string, JfQuestionFile> GenerateQuestionFiles(
        Dictionary<string, List<string>> source,
        int idxFrom,
        int idxTo,
        string prompt,
        string description)
    {
        Dictionary<string, JfQuestionFile> result = [];
        foreach (string key in source.Keys)
        {
            result.Add(key, GenerateQuestionFile(source[key], idxFrom, idxTo, prompt, description));
        }

        return result;
    }
}
