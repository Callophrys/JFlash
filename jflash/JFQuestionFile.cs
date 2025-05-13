using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace JFlash
{
    public class JFQuestionFile
    {
        static int TYPE_ENTRY = 1;
        static int TYPE_CHOICE = 2;

        public string Filename;
        public List<JFQuestion> Questions = new List<JFQuestion>();

        public string m_Description;
        public string Prompt;

        public int m_iType;

        public JFQuestionFile(string filename, int idxFrom, int idxTo)
        {
            string input;
            Filename = $"..\\JFlash\\Questions\\{filename}";
            if (File.Exists(Filename))
            {
                using (StreamReader sr = File.OpenText(Filename))
                {
                    if ((input = sr.ReadLine()) != null && string.Compare(input, "JPFLASH") !=0 )
                    {
                        sr.Close();
                        return;
                    }
                    
                    if ((input = sr.ReadLine()) != null && string.Compare(input, 0, "Desc", 0, 4, true) != 0)
                    {
                        sr.Close();
                        return;
                    }
                    else
                    {
                        m_Description = input.Substring(5);
                    }

                    if ((input = sr.ReadLine()) != null && string.Compare(input, 0, "Prompt", 0, 6, true) != 0)
                    {
                        sr.Close();
                        return;
                    }
                    else
                    {
                        Prompt = string.Format(input.Substring(7), JFlashForm.JpIntToChoiceString(idxFrom), JFlashForm.JpIntToChoiceString(idxTo));
                    }

                    if ((input = sr.ReadLine()) != null && string.Compare(input, 0, "Type", 0, 4 ) != 0)
                    {
                        sr.Close();
                        return;
                    }
                    else
                    {
                        if (string.Compare(input, 5, "Entry", 0, 5) == 0)
                        {
                            m_iType = TYPE_ENTRY;
                        }
                        else if (string.Compare(input, 5, "Choice", 0, 6) == 0)
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

                    string[] qss = input.Split( '\n' );
                    string q;
                    int i = qss.Length - 1;

                    while( i > 0 && string.Compare( qss[i].Trim(new Char[]{'\t',' ','\r'}), "END", true ) != 0 )
                    { i--; }
                    int m_iNumQuestions = i;

                    // Error check on no questions
                    if (i < 1 && string.Compare(qss[0].Trim(new Char[] { '\t', ' ', '\r' }), "END", true) != 0)
                    {
                        // END tag seems missing
                    }

                    for (i = 0; i < m_iNumQuestions; i++)
                    {
                        q = string.Copy(qss[i].Trim(new Char[] { '\t', ' ', '\r' }));
                        var question = new JFQuestion(q, this, idxFrom, idxTo);

                        // Make sure question is usable
                        if (!string.IsNullOrEmpty(question.Question) && !string.IsNullOrEmpty(question.Answer))
                        {
                            Questions.Add(new JFQuestion(q, this, idxFrom, idxTo));
                        }
                    }

                    sr.Close();
                }
            }
        }
    }
}
