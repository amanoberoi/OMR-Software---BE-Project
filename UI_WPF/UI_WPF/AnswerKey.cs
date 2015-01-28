using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace OMRSoft
{
    public class AnswerKey
    {
        public char[] answer;
        public AnswerKey(string filename)
        {
            using (StreamReader sr = File.OpenText(filename))
            {
                string t = sr.ReadLine();
                int total = Convert.ToInt16(t);
                answer = new char[total];
                for (int i = 0; i < total; ++i)
                {
                    string ans = sr.ReadLine();
                    answer[i] = Convert.ToChar(ans);
                }
            }
        }
        
    }
}
