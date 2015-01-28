using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLRead
{
    public static class Coordinate_match
    {

        public static bool check_validity(char ch)
        {
            if (ch == 'A' || ch == 'B' || ch == 'C' || ch == 'D')
                return false;
            else
                return true;
        }
        /// <summary>
        /// Basic implementation of checking the coordinates falling within the circle.
        /// It generates a square around the center to check the bounding of the given coordinate.
        /// </summary>
        /// <param name="given"></param>
        /// <param name="marked"></param>
        /// <returns></returns>
        public static bool check_mark(Coordinate given, BLOB marked)
        {
            double radius = marked.radius;
            double new_x_right, new_x_left, new_y_top, new_y_bottom;
            new_x_right = marked.x + radius;
            new_y_top = marked.y - radius;
            new_x_left = marked.x - radius;
            new_y_bottom = marked.y + radius;
            
            bool result = false;

            if (given.x <= new_x_right && given.x >= new_x_left && given.y <= new_y_bottom && given.y >= new_y_top)
                result = true;

            return result;
        }

        /// <summary>
        /// Iterates through the List<> of BLOBS to check if any of them fit. 
        /// </summary>
        /// <param name="given"></param>
        /// <param name="blobs"></param>
        /// <returns></returns>
        public static bool scan_blobs (Coordinate given, List<BLOB> blobs)
        {
            for (int i = 0; i < blobs.Count; ++i)
            {
                if (check_mark(given, blobs[i]))
                    return true;
            }
            return false;
        }


        /// <summary>
        /// Get Roll Number.
        /// Roll Number Scanning.
        /// Reverse the 'roll_no' string.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="blobs"></param>
        /// <returns></returns>
        public static string get_rollno(Sheet sheet, List<BLOB> blobs)
        {
            string roll_no = "";
            int roll_validity = 0;
            int roll_index = 0;
            for (int i = 0; i < 7; ++i)
            {
                int digit_index = 0;
                Coordinate[] coor = new Coordinate[10];

                coor[digit_index++] = sheet.roll[roll_index++].coordinate;
                coor[digit_index++] = sheet.roll[roll_index++].coordinate;
                coor[digit_index++] = sheet.roll[roll_index++].coordinate;
                coor[digit_index++] = sheet.roll[roll_index++].coordinate;
                coor[digit_index++] = sheet.roll[roll_index++].coordinate;
                coor[digit_index++] = sheet.roll[roll_index++].coordinate;
                coor[digit_index++] = sheet.roll[roll_index++].coordinate;
                coor[digit_index++] = sheet.roll[roll_index++].coordinate;
                coor[digit_index++] = sheet.roll[roll_index++].coordinate;
                coor[digit_index++] = sheet.roll[roll_index++].coordinate;

                for (int a = 0; a < 10; ++a)
                {
                    if (scan_blobs(coor[a], blobs))
                    {
                        roll_validity++;
                        roll_no += Convert.ToString(a);
                    }
                }
                if (roll_validity > 1 || roll_validity == 0)
                {
                    roll_no = "NOT_VALID";
                    continue;
                }
                roll_validity = 0;
            }

            char[] array = roll_no.ToCharArray();
            Array.Reverse(array);

            return new string(array);
 
        }


        /// <summary>
        /// Subject Code Scanning.
        /// Reverse the string as usual.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="blobs"></param>
        /// <returns></returns>
        public static string get_subject_code (Sheet sheet, List<BLOB> blobs)
        {
            string subject_code = "";
            int sub_validity = 0;
            int sub_index = 0;
            for (int i = 0; i < 4; ++i)
            {
                int digit_index = 0;
                Coordinate[] coor = new Coordinate[10];

                coor[digit_index++] = sheet.sub_code[sub_index++].coordinate;
                coor[digit_index++] = sheet.sub_code[sub_index++].coordinate;
                coor[digit_index++] = sheet.sub_code[sub_index++].coordinate;
                coor[digit_index++] = sheet.sub_code[sub_index++].coordinate;
                coor[digit_index++] = sheet.sub_code[sub_index++].coordinate;
                coor[digit_index++] = sheet.sub_code[sub_index++].coordinate;
                coor[digit_index++] = sheet.sub_code[sub_index++].coordinate;
                coor[digit_index++] = sheet.sub_code[sub_index++].coordinate;
                coor[digit_index++] = sheet.sub_code[sub_index++].coordinate;
                coor[digit_index++] = sheet.sub_code[sub_index++].coordinate;
                
                for (int a = 0; a < 10; ++a)
                {
                    if (scan_blobs(coor[a], blobs))
                    {
                        sub_validity++;
                        subject_code += Convert.ToString(a);
                    }
                }
                if (sub_validity > 1 || sub_validity == 0)
                {
                    subject_code = "NOT_VALID";
                    continue;
                }
                sub_validity = 0;
            }


            char[] array = subject_code.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }


        /// <summary>
        /// Question Paper Scanning.
        /// Reverse the string.
        /// </summary>
        /// <param name="sheet"> Sheet object.</param>
        /// <param name="blobs"> Detected blobs.</param>
        /// <returns> Returns QP Code as a string. </returns>
        public static string get_qp_code(Sheet sheet, List<BLOB> blobs) 
        {
            string question_code = "";
            int question_validity = 0;
            int ques_index = 0;
            for (int i = 0; i < 5; ++i)
            {
                int digit_index = 0;
                Coordinate[] coor = new Coordinate[10];

                coor[digit_index++] = sheet.qp_code[ques_index++].coordinate;
                coor[digit_index++] = sheet.qp_code[ques_index++].coordinate;
                coor[digit_index++] = sheet.qp_code[ques_index++].coordinate;
                coor[digit_index++] = sheet.qp_code[ques_index++].coordinate;
                coor[digit_index++] = sheet.qp_code[ques_index++].coordinate;
                coor[digit_index++] = sheet.qp_code[ques_index++].coordinate;
                coor[digit_index++] = sheet.qp_code[ques_index++].coordinate;
                coor[digit_index++] = sheet.qp_code[ques_index++].coordinate;
                coor[digit_index++] = sheet.qp_code[ques_index++].coordinate;
                coor[digit_index++] = sheet.qp_code[ques_index++].coordinate;

                for (int a = 0; a < 10; ++a)
                {
                    if (scan_blobs(coor[a], blobs))
                    {
                        question_validity++;
                        question_code += Convert.ToString(a);
                    }
                }
                if (question_validity > 1 || question_validity == 0)
                {
                    question_code = "NOT_VALID";
                    continue;
                }
                question_validity = 0;
            }

            char[] array = question_code.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        /// <summary>
        /// Creates the sheet object which contains the coordinates of the blobs.
        /// Performs scanning and validity on the recorded Choice/Numbers.
        /// </summary>
        /// <param name="blobs"></param>
        public static char[] get_answers(Sheet sheet, List<BLOB> blobs)
        {
            char[] answers = new char[100]; // Array of answers.

            // Scanning A choices.
            CHOICE[] A = new CHOICE[100];
            int ch = 0;
            for (int a = 0; a < 100; ++a)
            {
                A[a] = sheet.choices[ch];
                ch += 4;
            }
            for (int i = 0; i < 100; ++i)
            {
                if (scan_blobs(A[i].coordinate, blobs))
                    if (check_validity(answers[i]))
                        answers[i] = 'A';
                    else
                        answers[i] = '0';
            }
            
            // Scanning B choices.
            CHOICE[] B = new CHOICE[100];
            ch = 1;
            for (int a = 0; a < 100; ++a)
            {
                B[a] = sheet.choices[ch];
                ch += 4;
            }
            for (int i = 0; i < 100; ++i)
            {
                if (scan_blobs(B[i].coordinate, blobs))
                    if (check_validity(answers[i]))
                        answers[i] = 'B';
                    else
                        answers[i] = '0';
            }
            
            
            // Scanning C choices.
            CHOICE[] C = new CHOICE[100];
            ch = 2;
            for (int a = 0; a < 100; ++a)
            {
                C[a] = sheet.choices[ch];
                ch += 4;
            }
            for (int i = 0; i < 100; ++i)
            {
                if (scan_blobs(C[i].coordinate, blobs))
                    if (check_validity(answers[i]))
                        answers[i] = 'C';
                    else
                        answers[i] = '0'; 
            }
            
            // Scanning D choices.
            CHOICE[] D = new CHOICE[100];
            ch = 3;
            for (int a = 0; a < 100; ++a)
            {
                D[a] = sheet.choices[ch];
                ch += 4;
            }
            for (int i = 0; i < 100; ++i)
            {
                if (scan_blobs(D[i].coordinate, blobs))
                    if (check_validity(answers[i]))
                        answers[i] = 'D';
                    else
                        answers[i] = '0'; 
            }
            
            return answers;

        }

    }

    
}
