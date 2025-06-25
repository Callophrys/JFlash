namespace JFlash.Classes;

public class QuestionFile
{
    static readonly int TYPE_ENTRY = 1;
    static readonly int TYPE_CHOICE = 2;

    public int questionType;

    public List<string> Questions { get; } = [];
    public int QuestionCount => Questions.Count;

    public string Description { get; set; } = string.Empty;
    public string Prompt { get; set; } = string.Empty;
    public string SetName { get; } = string.Empty;

    public QuestionFile() { }

    public QuestionFile(string filename)
    {
        if (!File.Exists(filename))
        {
            return;
        }

        SetName = Path.GetFileNameWithoutExtension(filename);

        using StreamReader sr = File.OpenText(filename);

        if (string.Compare((sr.ReadLine() ?? string.Empty).ToUpperInvariant(), 0, "JPFLASH", 0, 7, true) != 0)
        {
            sr.Close();
            return;
        }

        string? input = sr.ReadLine() ?? string.Empty;
        if (string.Compare(input.ToUpperInvariant(), 0, "DESC", 0, 4, true) != 0)
        {
            sr.Close();
            return;
        }
        else if (input.Length > 4)
        {
            Description = input[5..];
        }

        input = sr.ReadLine() ?? string.Empty;
        if (string.Compare(input.ToUpperInvariant(), 0, "PROMPT", 0, 6, true) != 0)
        {
            sr.Close();
            return;
        }
        else if (input.Length > 6)
        {
            Prompt = input[7..];
        }

        input = (sr.ReadLine() ?? string.Empty).ToUpperInvariant();
        if (string.Compare(input, 0, "TYPE", 0, 4) != 0)
        {
            sr.Close();
            return;
        }
        else
        {
            if (string.Compare(input, 5, "ENTRY", 0, 5, StringComparison.Ordinal) == 0)
            {
                questionType = TYPE_ENTRY;
            }
            else if (string.Compare(input, 5, "CHOICE", 0, 6, StringComparison.Ordinal) == 0)
            {
                questionType = TYPE_CHOICE;
            }
            else
            {
                sr.Close();
                return;
            }
        }

        if ((input = sr.ReadToEnd()) == null)
        {
            sr.Close();
            return;
        }

        Questions.AddRange([.. input
            .Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries)
            .TakeWhile(x => !x.Equals("END", StringComparison.InvariantCultureIgnoreCase))]);

        sr.Close();
    }

    public Dictionary<string, List<string>> GenerateSubsets(int subsetSize)
    {
        Dictionary<string, List<string>> subsets = [];

        int i = 0;
        string key;
        List<string>? subset = null;
        while (i < QuestionCount)
        {
            if (i % subsetSize == 0 && (QuestionCount - i) > (subsetSize / 2))
            {
                key = $"{SetName}_{i:00}";
                subset = [];
                subsets.Add(key, subset);
            }

            subset!.Add(Questions[i]);

            ++i;
        }

        return subsets;
    }
}

