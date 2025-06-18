using System.Diagnostics;

namespace JFlash.Classes
{
    public class JFQuestionFile
    {
        static readonly int TYPE_ENTRY = 1;
        static readonly int TYPE_CHOICE = 2;

        public List<JFQuestion> Questions = [];

        public string Description = string.Empty;
        public string Prompt = string.Empty;
        public string SetName = string.Empty;

        public int questionType;

        public JFQuestionFile(string filename, int idxFrom, int idxTo, int subsetSize)
        {
            /* TODO if idxTo is type NUM then say Numeral instead of English */

            if (!File.Exists(filename))
            {
                return;
            }

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
                Prompt = string.Format(input[7..], QuestionTypes.JfIntToChoiceString(idxFrom), QuestionTypes.JfIntToChoiceString(idxTo));
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

            IEnumerable<string> qss = input
                .Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries)
                .TakeWhile(x => x.ToUpperInvariant() != "END");
            foreach (string question in qss)
            {
                JFQuestion? jfQuestion = new(question.Trim(), idxFrom, idxTo);

                // Make sure question is usable
                if (!string.IsNullOrEmpty(jfQuestion.Answer))
                {
                    Questions.Add(jfQuestion);
                }
            }

            sr.Close();

            SetName = Path.GetFileNameWithoutExtension(filename);
        }
    }
}
