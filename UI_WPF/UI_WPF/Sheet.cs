using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
namespace XMLRead
{

    public class Sheet
    {
        //Elements

        public string path;
        public string id;
        public int elements, roll_digits, sub_code_dig, questions, choice, qp_code_digits;
        public List<ROLL> roll = new List<ROLL>(7 * 10);
        public List<SUBJECT> sub_code = new List<SUBJECT>(4 * 10);
        public List<QPCODE> qp_code = new List<QPCODE>(7 * 10);
        public List<CHOICE> choices = new List<CHOICE>(400);

        //Methods

        public Sheet(string path)
        {
            choice = 4;
            this.path = path;
            Process();
        }
        ~Sheet()
        {
            roll.Clear();
            sub_code.Clear();
            qp_code.Clear();
            choices.Clear();
        }
        public void Process()
        {
            string file = File.ReadAllText(this.path);
            XmlReader reader = XmlReader.Create(new StringReader(file));

            reader.ReadToFollowing("SHEET_ID");
            reader.MoveToFirstAttribute();
            this.id = reader.Value;

            reader.ReadToFollowing("ELEMENTS");
            reader.MoveToFirstAttribute();
            this.elements = Convert.ToInt32(reader.Value);

            //Read Question Paper Code.
            reader.ReadToFollowing("QP_CODE");
            reader.MoveToFirstAttribute();
            this.qp_code_digits = 5;
            for (int i = 1; i <= qp_code_digits; ++i)
            {
                reader.ReadToFollowing("PLACE");
                reader.MoveToFirstAttribute();
                int place = Convert.ToInt32(reader.Value);
                for (int j = 0; j < 10; ++j)
                {
                    reader.ReadToFollowing("NO");
                    reader.MoveToFirstAttribute();
                    int no = Convert.ToInt32(reader.Value);

                    reader.ReadToFollowing("X_COR");
                    reader.MoveToContent();
                    double x = Scanner_DPI.dpi_value * (Convert.ToDouble(reader.ReadString())) / 200;

                    reader.ReadToFollowing("Y_COR");
                    reader.MoveToContent();
                    double y = Scanner_DPI.dpi_value * (Convert.ToDouble(reader.ReadString())) / 200;

                    this.qp_code.Add(new QPCODE(place, no, new Coordinate(x, y)));
                }
            }

            //Read Subject Code.
            reader.ReadToFollowing("SUB_CODE");
            reader.MoveToFirstAttribute();
            this.sub_code_dig = 4;
            for (int i = 1; i <= sub_code_dig; ++i)
            {
                reader.ReadToFollowing("PLACE");
                reader.MoveToFirstAttribute();
                int place = Convert.ToInt32(reader.Value);

                for (int j = 0; j < 10; ++j)
                {
                    reader.ReadToFollowing("NO");
                    reader.MoveToFirstAttribute();
                    int no = Convert.ToInt32(reader.Value);

                    reader.ReadToFollowing("X_COR");
                    reader.MoveToContent();
                    double x = Scanner_DPI.dpi_value * (Convert.ToDouble(reader.ReadString())) / 200;

                    reader.ReadToFollowing("Y_COR");
                    reader.MoveToContent();
                    double y = Scanner_DPI.dpi_value * (Convert.ToDouble(reader.ReadString())) / 200;

                    sub_code.Add(new SUBJECT(place, no, new Coordinate(x, y)));
                }
            }

            // Read Roll Numbers.
            reader.ReadToFollowing("ROLL_NO");
            reader.MoveToFirstAttribute();
            this.roll_digits = 7;
            for (int i = 1; i <= roll_digits; ++i)
            {
                reader.ReadToFollowing("PLACE");
                reader.MoveToFirstAttribute();
                int place = Convert.ToInt32(reader.Value);

                for (int j = 0; j < 10; ++j)
                {
                    reader.ReadToFollowing("NO");
                    reader.MoveToFirstAttribute();
                    int no = Convert.ToInt32(reader.Value);

                    reader.ReadToFollowing("X_COR");
                    reader.MoveToContent();
                    double x = Scanner_DPI.dpi_value * (Convert.ToDouble(reader.ReadString())) / 200;

                    reader.ReadToFollowing("Y_COR");
                    reader.MoveToContent();
                    double y = Scanner_DPI.dpi_value * (Convert.ToDouble(reader.ReadString())) / 200;

                    roll.Add(new ROLL(place, no, new Coordinate(x, y)));
                }
            }


            // Read Choices

            reader.ReadToFollowing("QUESTION");
            reader.MoveToFirstAttribute();
            questions = Convert.ToInt32(reader.Value);
            choices = new List<CHOICE>(4 * questions);
            for (int i = 1; i <= questions; ++i)
            {
                reader.ReadToFollowing("Q_NO");
                reader.MoveToFirstAttribute();
                int q_no = Convert.ToInt32(reader.Value);

                for (int j = 0; j < 4; ++j)
                {
                    reader.ReadToFollowing("CHOICE");
                    reader.MoveToFirstAttribute();
                    int choice = Convert.ToInt32(reader.Value);

                    reader.ReadToFollowing("X_COR");
                    reader.MoveToContent();
                    double x_cor = Scanner_DPI.dpi_value * (Convert.ToDouble(reader.ReadString())) / 200;

                    reader.ReadToFollowing("Y_COR");
                    reader.MoveToContent();
                    double y_cor = Scanner_DPI.dpi_value * (Convert.ToDouble(reader.ReadString())) / 200;

                    choices.Add(new CHOICE(q_no, choice, new Coordinate(x_cor, y_cor)));
                }
            }

            reader.Close();
        }

    }
}
