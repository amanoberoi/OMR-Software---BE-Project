using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace UI_WPF
{
    public static class Worker
    {
        public static string connection_string = @"data source=D:\OMRSoft\Database\OMRSoft.s3db; Version=3;";
        public static SQLiteConnection database_connection = new SQLiteConnection (connection_string);
        public static OMRSoft.AnswerKey answer_key = null;
        public static string answer_key_dir;
        public static string scanned_img_dir;
        public static string templates_dir;
        public static int scanned_image_index;
        public static string db_path;
        public static string answer_key_path;
        public static char[] set_answer_key = null;
        public static void GetInfo()
        {

            string path = @"D:\OMRSoft\FileInfo";
            using (StreamReader sr = new StreamReader(path))
            {
                string line = "";
                line = sr.ReadLine();
                scanned_image_index = Convert.ToInt16(line);
                
                line = sr.ReadLine();
                scanned_img_dir = line;
                
                line = sr.ReadLine();
                answer_key_dir = line;
                
                line = sr.ReadLine();
                templates_dir = line;

                line = sr.ReadLine();
                db_path = line;
            }

            
        }
        public static void Cleanup()
        {
            string path = @"D:\OMRSoft\FileInfo";
            File.Delete(path);

            FileStream fs = new FileStream(@"D:\FileInfo", FileMode.Create);
            fs.Close();

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(scanned_image_index.ToString());
            sw.WriteLine(scanned_img_dir);
            sw.WriteLine(answer_key_dir);
            sw.WriteLine(templates_dir);
            sw.WriteLine(db_path);
            sw.Close();

            database_connection.Close();
        }
        public static int marks_scored(char[] marked, char[] ans)
        {
            int total = ans.Length;
            int marks = 0;
            for (int i = 0; i < total; ++i)
                if (Char.ToLower(marked[i]) == Char.ToLower(ans[i]))
                    marks++;

            return marks;
        }
        public static int marks_scored(string marked, char[] ans)
        {
            int total = ans.Length;
            int marks = 0;
            for (int i = 0; i < total; ++i)
                if (Char.ToLower(marked[i]) == Char.ToLower(ans[i]))
                    marks++;

            return marks;
        }
        public static int marks_scored(char[] marked, string ans)
        {
            int total = ans.Length;
            int marks = 0;
            for (int i = 0; i < total; ++i)
                if (Char.ToLower(marked[i]) == Char.ToLower(ans[i]))
                    marks++;

            return marks;
        }
        public static int marks_scored(string marked, string ans)
        {
            int total = ans.Length;
            int marks = 0;
            for (int i = 0; i < total; ++i)
                if (Char.ToLower(marked[i]) == Char.ToLower(ans[i]))
                    marks++;

            return marks;
        }
    }
}
