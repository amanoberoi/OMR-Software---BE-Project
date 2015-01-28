using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using AForge;
using XMLRead;
namespace OMRSoft
{
    public class OMRSoft
    {
        public string roll_no, subject_code, qp_code;
        public string answer_key;
        public Bitmap scanned_image;
        public List<BLOB> useful;
        public OMRSoft(string path)
        {
            useful = new List<BLOB>(100);
            roll_no = ""; subject_code = ""; qp_code = "";
            answer_key = "";
            scanned_image = new Bitmap(path);
            scanned_image= new Bitmap(filter());

        }

        private Bitmap filter()
        {
            Bitmap filtered_image;
            AForge.Imaging.Filters.Grayscale gr = new AForge.Imaging.Filters.Grayscale(0.2125, 0.7154, 0.0721);
            AForge.Imaging.Filters.Threshold th = new AForge.Imaging.Filters.Threshold(100);
            AForge.Imaging.Filters.Invert invert = new AForge.Imaging.Filters.Invert();
            filtered_image = gr.Apply(scanned_image);
            filtered_image = invert.Apply(filtered_image);
            filtered_image = th.Apply(filtered_image);
            return filtered_image;
        }

        private System.Drawing.Point[] ToPointsArray(List<IntPoint> points)
        {
            System.Drawing.Point[] array = new System.Drawing.Point[points.Count];

            for (int i = 0, n = points.Count; i < n; i++)
            {
                array[i] = new System.Drawing.Point(points[i].X, points[i].Y);
            }

            return array;
        }
        
        // Summary - Decides the 4 points from a set of approx. 16 to trim the image.
        /************************
         * It receives the 4 quadrilaterals with 4 corners each (so 16 points with X and Y).
         * Then decides which corners are which (like top left, bottom right) on the basis of preconceived notions.
         * After that, the process selects the inner points of these quadrilaterals for Cropping/Trimming.
         */
        public Bitmap DecideCorners(List<List<IntPoint>> QuadCorners)
        {
            Bitmap image = this.scanned_image;
            List<IntPoint> top_left, top_right, bot_left, bot_right;
            top_left = new List<IntPoint>(); top_right = new List<IntPoint>();
            bot_left = new List<IntPoint>(); bot_right = new List<IntPoint>();

            for (int i = 0; i < 4; ++i)
            {
                if (QuadCorners[i][0].X < Scanner_DPI.dpi_value / 200 * 200 && QuadCorners[i][0].Y < Scanner_DPI.dpi_value / 200 * 500)
                    top_left = QuadCorners[i];
                if (QuadCorners[i][0].X > Scanner_DPI.dpi_value / 200 * 200 && QuadCorners[i][0].Y < Scanner_DPI.dpi_value / 200 * 500)
                    top_right = QuadCorners[i];
                if (QuadCorners[i][0].X < Scanner_DPI.dpi_value / 200 * 200 && QuadCorners[i][0].Y > Scanner_DPI.dpi_value / 200 * 500)
                    bot_left = QuadCorners[i];
                if (QuadCorners[i][0].X > Scanner_DPI.dpi_value / 200 * 200 && QuadCorners[i][0].Y > Scanner_DPI.dpi_value / 200 * 500)
                    bot_right = QuadCorners[i];
            }

            IntPoint[] corners = new IntPoint[4];

            int X = top_left[0].X;
            int Y = top_left[0].Y;
            for (int i = 0; i < 4; i++)
            {
                if (X <= top_left[i].X)
                    X = top_left[i].X;
                if (Y <= top_left[i].Y)
                    Y = top_left[i].Y;
            }
            corners[0] = new IntPoint(X, Y);

            X = top_right[0].X;
            Y = top_right[0].Y;
            for (int i = 0; i < 4; i++)
            {
                if (X >= top_right[i].X)
                    X = top_right[i].X;
                if (Y <= top_right[i].Y)
                    Y = top_right[i].Y;
            }
            corners[1] = new IntPoint(X, Y);

            X = bot_left[0].X;
            Y = bot_left[0].Y;
            for (int i = 0; i < 4; i++)
            {
                if (X <= bot_left[i].X)
                    X = bot_left[i].X;
                if (Y >= bot_left[i].Y)
                    Y = bot_left[i].Y;
            }
            corners[2] = new IntPoint(X, Y);

            X = bot_right[0].X;
            Y = bot_right[0].Y;
            for (int i = 0; i < 4; i++)
            {
                if (X >= bot_right[i].X)
                    X = bot_right[i].X;
                if (Y >= bot_right[i].Y)
                    Y = bot_right[i].Y;
            }
            corners[3] = new IntPoint(X, Y);

            Rectangle rectangle = new Rectangle(corners[0].X, corners[0].Y, corners[1].X - corners[0].X, corners[2].Y - corners[0].Y);
            Bitmap CroppedImage = image.Clone(rectangle, image.PixelFormat);
            
            return CroppedImage;
        }

        // Summary - Gets the exterior rectangles.
        /***************
         * It uses a different JPEG altogether due to bpp issue (only 24 or 32 is acceptable).
         * Selects the rectangles on the basis of area (around 350 to 400).
         * Sends the quadrilaterals (4 of them) with their 4 coordinates (each) to DecideCorners for trimming.
         */
        public void PreProcess()
        {
            Bitmap bitmap = this.scanned_image;
            List<List<IntPoint>> QuadCorners = new List<List<IntPoint>>(4);

            BitmapData bitmapData = bitmap.LockBits(
                   new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                   ImageLockMode.ReadWrite, bitmap.PixelFormat);

            // step 1 - turn background to black
            ColorFiltering colorFilter = new ColorFiltering();

            colorFilter.Red = new IntRange(0, 64);
            colorFilter.Green = new IntRange(0, 64);
            colorFilter.Blue = new IntRange(0, 64);
            colorFilter.FillOutsideRange = false;
            //MessageBox.Show(bitmapData.PixelFormat.ToString());
            colorFilter.ApplyInPlace(bitmapData);

            // step 2 - locating objects
            BlobCounter blobCounter = new BlobCounter();

            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 5;
            blobCounter.MinWidth = 5;

            blobCounter.ProcessImage(bitmapData);   
            Blob[] blobs = blobCounter.GetObjectsInformation();
            bitmap.UnlockBits(bitmapData);
            
            // step 3 - check objects' type and highlight
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
            //int count = 0;
            Pen redPen = new Pen(Color.Red, 2);
            Graphics g = Graphics.FromImage(bitmap);
            
            // Threshold area values for rectangles. It doesnt have a specific equation for the value based on threshold.
            // Values have been tested and set accordingly.
            int area_upper = 0, area_lower = 0;
            if (Scanner_DPI.dpi_value == 200)
            {
                area_lower = 2000;
                area_upper = 3000;
            }
            else if (Scanner_DPI.dpi_value == 300)
            {
                area_lower = 5000;
                area_upper = 6000;
            }
            for (int i = 0, n = blobs.Length; i < n; i++)
            {
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);

                List<IntPoint> corners;

                // is quadrilateral
                if (shapeChecker.IsConvexPolygon(edgePoints, out corners))
                {
                    // get sub-type
                    PolygonSubType subType = shapeChecker.CheckPolygonSubType(corners);

                        if (subType == PolygonSubType.Rectangle && blobs[i].Area > area_lower && blobs[i].Area < area_upper)
                        {
                            //g.DrawPolygon(redPen, ToPointsArray(corners));
                            QuadCorners.Add(corners);

                        }
                }
            }
            this.scanned_image = DecideCorners(QuadCorners);
        }

        public void blob_detect ()
        {
            Bitmap image = this.scanned_image;
            BlobCounter blob = new BlobCounter();
            blob.FilterBlobs = false;
            
            int blob_ht_width = 30;
            blob.MinHeight = blob_ht_width;
            blob.MinWidth = blob_ht_width;
            blob.ProcessImage(image);
            
            Blob[] b = blob.GetObjectsInformation();
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
            /*blob_counter.Text = b.Length.ToString();
            Graphics g = Graphics.FromImage(image2);
            Pen yellowPen = new Pen(Color.Yellow, 5);
            Pen redPen = new Pen(Color.Red, 5);
            Pen greenPen = new Pen(Color.Green, 5);
            int b_counter = 0;
             */
            for (int i = 0, n = b.Length; i < n; i++)
            {
                List<IntPoint> edgePoints = blob.GetBlobsEdgePoints(b[i]);
                List<IntPoint> edges = new List<IntPoint>();
                AForge.Point center;
                float radius;

                if (shapeChecker.IsCircle(edgePoints, out center, out radius))
                {
                
                    if (b[i].Fullness * 100 >= 40 && b[i].Fullness * 100 < 100 && radius > 10)
                    {
                        Coordinate coor = new Coordinate(center.X, center.Y);
                        BLOB blb = new BLOB(coor, radius);
                        useful.Add(blb);
                    }   
                }    
            }
            
        }

        public void generate_results(Sheet sheet)
        {
            char[] ans = new char[100];
            Thread[] thread = new Thread[4];
            thread[0] = new Thread(() => { answer_key = new string(Coordinate_match.get_answers(sheet, useful)); });
            thread[1] = new Thread(() => { roll_no = Coordinate_match.get_rollno(sheet, useful); });
            thread[2] = new Thread(() => { qp_code = Coordinate_match.get_qp_code(sheet, useful); });
            thread[3] = new Thread(() => { subject_code = Coordinate_match.get_subject_code(sheet, useful); });
            for (int i = 0; i <= 3; ++i)
            {
                thread[i].Start();
                thread[i].Join();
            }
            
        }

    }
}
