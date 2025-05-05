using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace jflash
{
    public class JFQuestionFile
    {
        static int TYPE_ENTRY = 1;
        static int TYPE_CHOICE = 2;

        public String m_Description;
        public String m_Filename;
        public String m_strPrompt;
        public int m_iNumQuestions, m_iType;
        public JFQuestion[] m_Questions;

        public JFQuestionFile(String filename)
        {
            String input;
            if (File.Exists(filename))
            {
                m_Filename = String.Copy(filename);
                using (StreamReader sr = File.OpenText(m_Filename))
                {
                    if ((input = sr.ReadLine()) != null && String.Compare(input, "JPFLASH") !=0 )
                    {
                        sr.Close();
                        return;
                    }
                    
                    if ((input = sr.ReadLine()) != null && String.Compare(input, 0, "Desc", 0, 4, true) != 0)
                    {
                        sr.Close();
                        return;
                    }
                    else
                    {
                        m_Description = input.Substring(5);
                    }

                    if ((input = sr.ReadLine()) != null && String.Compare(input, 0, "Prompt", 0, 6, true) != 0)
                    {
                        sr.Close();
                        return;
                    }
                    else
                    {
                        m_strPrompt = input.Substring(7);
                    }

                    if ((input = sr.ReadLine()) != null && String.Compare(input, 0, "Type", 0, 4 ) != 0)
                    {
                        sr.Close();
                        return;
                    }
                    else
                    {
                        if( String.Compare( input, 5, "Entry", 0, 5 )==0)
                            m_iType = TYPE_ENTRY;
                        else if( String.Compare( input, 5, "Choice", 0, 6 )==0)
                            m_iType = TYPE_CHOICE;
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

                    String[] qss = input.Split( '\n' );
                    String q;
                    int i = qss.Length - 1;

                    while( i > 0 && String.Compare( qss[i].Trim(new Char[]{'\t',' ','\r'}), "END", true ) != 0 )
                    { i--; }
                    m_iNumQuestions = i;

                    // Error check on no questions
                    if (i < 1 && String.Compare(qss[0].Trim(new Char[] { '\t', ' ', '\r' }), "END", true) != 0)
                    {
                        // END tag seems missing
                    }

                    m_Questions = new JFQuestion[m_iNumQuestions];
                    for (i = 0; i < m_iNumQuestions; i++)
                    {
                        q = String.Copy(qss[i].Trim(new Char[] { '\t', ' ', '\r' }));
                        m_Questions[i] = new JFQuestion(q, this);
                    }

                    sr.Close();
                }
            }
        }
    }
}
