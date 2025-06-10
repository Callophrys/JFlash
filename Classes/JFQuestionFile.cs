namespace JFlash.Classes
{
    public class JFQuestionFile
    {
        static readonly int TYPE_ENTRY = 1;
        static readonly int TYPE_CHOICE = 2;

        public List<JFQuestion> Questions = [];

        public string FileName { get; set; } = string.Empty;

        public string Description = string.Empty;
        public string Prompt = string.Empty;

        public int m_iType;

        public JFQuestionFile(string filename, int idxFrom, int idxTo)
        {
            string? input;
            if (File.Exists(filename))
            {
                FileName = filename;

                using StreamReader sr = File.OpenText(filename);
                if ((input = sr.ReadLine()) != null && string.Compare(input, "JPFLASH") != 0)
                {
                    sr.Close();
                    return;
                }

                if ((input = sr.ReadLine()) != null && string.Compare(input, 0, "Desc", 0, 4, true) != 0)
                {
                    sr.Close();
                    return;
                }
                else if (!string.IsNullOrEmpty(input))
                {
                    Description = input[5..];
                }

                if ((input = sr.ReadLine()) != null && string.Compare(input, 0, "Prompt", 0, 6, true) != 0)
                {
                    sr.Close();
                    return;
                }
                else if (!string.IsNullOrEmpty(input))
                {
                    Prompt = string.Format(input[7..], JFlashForm.JpIntToChoiceString(idxFrom), JFlashForm.JpIntToChoiceString(idxTo));
                }

                if ((input = sr.ReadLine()) != null && string.Compare(input, 0, "Type", 0, 4) != 0)
                {
                    sr.Close();
                    return;
                }
                else
                {
                    if (string.Compare(input, 5, "Entry", 0, 5, StringComparison.Ordinal) == 0)
                    {
                        m_iType = TYPE_ENTRY;
                    }
                    else if (string.Compare(input, 5, "Choice", 0, 6, StringComparison.Ordinal) == 0)
                    {
                        m_iType = TYPE_CHOICE;
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

                string[] qss = input.Split('\n');
                string q;
                int i = qss.Length - 1;

                while (i > 0 && !string.Equals(qss[i].Trim(['\t', ' ', '\r']), "END", StringComparison.CurrentCultureIgnoreCase))
                { i--; }
                int m_iNumQuestions = i;

                // Error check on no questions
                if (i < 1 && !string.Equals(qss[0].Trim(['\t', ' ', '\r']), "END", StringComparison.CurrentCultureIgnoreCase))
                {
                    // END tag seems missing
                }

                for (i = 0; i < m_iNumQuestions; i++)
                {
                    q = qss[i].Trim(['\t', ' ', '\r']);
                    var question = new JFQuestion(q, idxFrom, idxTo);

                    // Make sure question is usable
                    if (!string.IsNullOrEmpty(question.Prompt) && !string.IsNullOrEmpty(question.Answer))
                    {
                        Questions.Add(new JFQuestion(q, idxFrom, idxTo));
                    }
                }

                sr.Close();
            }
        }
    }
}
