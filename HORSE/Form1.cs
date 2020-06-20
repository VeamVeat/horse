using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HORSE
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            Get();


        }

        public int Col = 0, Row = 0;
        public ulong bypass = 0;

        Image[] img =
             {
                global::HORSE.Properties.Resources._1,
                global::HORSE.Properties.Resources._2,
                global::HORSE.Properties.Resources.HORSE5,

            };

        PictureBox[,] Pole;

        List<Point> Pretendent = new List<Point>();

        public int _X_ = 0;
        public int _Y_ = 0;

        // генерация доски picturebox №1
        private void Button1_Click(object sender, EventArgs e) { GetPanel(); }

        // Прорисовываем доску графикой
        public void Dosca()
        {


            bool isBlack = false;
            Pen pens = new Pen(Color.FromArgb(180, 134, 98));
            Brush brush = new SolidBrush(Color.FromArgb(180, 134, 98));
            Pen pensl = new Pen(Color.FromArgb(239, 217, 180));
            Brush brushal = new SolidBrush(Color.FromArgb(239, 217, 180));
            Rectangle rect;
            Graphics gfx = panel2.CreateGraphics();

            for (int i = 0; i <= Row - 1; i++)
            {
                for (int j = 0; j <= Col - 1; j++)
                {
                    if (isBlack)
                    {
                        rect = new Rectangle(i * 40, j * 40, 40, 40);
                        gfx.DrawRectangle(pens, rect);
                        gfx.FillRectangle(brush, rect);
                        isBlack = false;
                    }
                    else
                    {
                        rect = new Rectangle(i * 40, j * 40, 40, 40);
                        gfx.DrawRectangle(pensl, rect);
                        gfx.FillRectangle(brushal, rect);
                        isBlack = true;
                    }

                }
                if (Row % 2 == 0)
                    isBlack = !isBlack;

            }

            gfx.Dispose();
            brush.Dispose();
            brushal.Dispose();
            pensl.Dispose();
            pens.Dispose();

        }

        // Соедениям 2 координаты
        public void Line(int xx, int yy, int XX, int YY)
        {
            Point p1 = new Point();
            Point p2 = new Point();
            Graphics g = panel2.CreateGraphics();
            SolidBrush solid = new SolidBrush(Color.Black);
            Rectangle recth;
            SolidBrush redBrush = new SolidBrush(Color.Black);
            Pen pen = new Pen(solid, 1);
            p1.X = Pole[xx, yy].Location.X + Pole[xx, yy].Size.Width / 2;
            p1.Y = Pole[xx, yy].Location.Y + Pole[xx, yy].Size.Height / 2;
            recth = new Rectangle(p1.X - 3, p1.Y - 3, 7, 7);
            float startAngle = 0.0F;
            float sweepAngle = 360.0F;
            g.FillPie(redBrush, recth, startAngle, sweepAngle);
            p2.X = Pole[XX, YY].Location.X + Pole[XX, YY].Size.Width / 2;
            p2.Y = Pole[XX, YY].Location.Y + Pole[XX, YY].Size.Height / 2;
            recth = new Rectangle(p2.X - 3, p2.Y - 3, 7, 7);
            g.FillPie(redBrush, recth, startAngle, sweepAngle);
            g.DrawLine(pen, p1, p2);
            g.Dispose();
            solid.Dispose();
            pen.Dispose();

        }


        // прорисовки графики

        public int i, j, n, nsqr, q;
        public int[] dx = new int[9];
        public int[] dy = new int[9];
        public int[,] h = new int[29, 29];

        // Доска 3
        public void DisplayDoscaTree()
        {
            bool isBlack = false;
            Pen pens = new Pen(Color.FromArgb(180, 134, 98));
            Brush brush = new SolidBrush(Color.FromArgb(180, 134, 98));
            Pen pensl = new Pen(Color.FromArgb(239, 217, 180));
            Brush brushal = new SolidBrush(Color.FromArgb(239, 217, 180));
            Rectangle rect;
            Graphics gfx = panel3.CreateGraphics();

            for (int i = 0; i <= Row - 1; i++)
            {
                for (int j = 0; j <= Col - 1; j++)
                {
                    if (isBlack)
                    {
                        rect = new Rectangle(i * 40, j * 40, 40, 40);
                        gfx.DrawRectangle(pens, rect);
                        gfx.FillRectangle(brush, rect);
                        isBlack = false;
                    }
                    else
                    {
                        rect = new Rectangle(i * 40, j * 40, 40, 40);
                        gfx.DrawRectangle(pensl, rect);
                        gfx.FillRectangle(brushal, rect);
                        isBlack = true;
                    }
                    //await Task.Delay(1);
                }
                if (Row % 2 == 0)
                    isBlack = !isBlack;

            }

            gfx.Dispose();
            brush.Dispose();
            brushal.Dispose();
            pensl.Dispose();
            pens.Dispose();
        }


        //третья доска (цифры)
        async public void DoscaRezult()
        {

            Graphics gj = panel3.CreateGraphics();
            int count = 0;
            int a = _X_ + 1;
            int b = _Y_ + 1;
            int kil = h[a, b];
            Point p1 = new Point();
            Point p2 = new Point();
            for (int row = 1; row <= Row; row++)
            {
                for (int col = 1; col <= Col; col++)
                {
                    if (h[row, col] != 0)
                    {
                        count++;
                    }
                }
            }

            for (int l = 0; l < count; l++)
            {
                for (int ii = 1; ii <= Row; ii++)
                {
                    for (int jj = 1; jj <= Col; jj++)
                    {
                        if (h[ii, jj] - 1 == kil)
                        {

                            p1.X = Pole[a - 1, b - 1].Location.X;
                            p1.Y = Pole[a - 1, b - 1].Location.Y;
                            p2.X = Pole[ii - 1, jj - 1].Location.X;
                            p2.Y = Pole[ii - 1, jj - 1].Location.Y;
                            gj.DrawString(kil.ToString(), new Font("Book Antiqua", 13, FontStyle.Bold), Brushes.Black, p1.X, p1.Y);
                            await Task.Delay(300);
                            gj.DrawString(h[ii, jj].ToString(), new Font("Book Antiqua", 13, FontStyle.Bold), Brushes.Black, p2.X, p2.Y);


                            kil = h[ii, jj];
                            a = ii;
                            b = jj;


                        }
                    }
                }
            }

        }


        public ulong counter = 0;

        public int Q1(int q)
        {
            if (q == 0)
                return 1;
            else
                return 0;


        }

        public int Brute(int i, int x, int y)
        {
            int j, u, v, q1 = 0;
            for (j = 1; j <= 8; j++)
            {
                if (Q1(q1) == 0)
                {
                    return q1;
                }

                u = x + dx[j]; // 3
                v = y + dy[j]; // 2
                if (1 <= u && u <= n && 1 <= v && v <= n && h[u, v] == 0)
                {
                    h[u, v] = i;
                    if (i < nsqr)
                    {
                        q1 = Brute(i + 1, u, v);
                        if (q1 == 0)
                        {
                            h[u, v] = 0;
                        }
                    }
                    else
                    {

                        q1 = 1;
                    }
                }
            }
            counter++;
            if (bypass != 0)
            {
                if (counter % bypass == 0)
                    LineDisplay(h);
            }

            return q1;
        }

        //отрисовка линий через n коллчество обходов
        public void LineDisplay(int[,] h)
        {
            int count = 0;


            int a = _X_ + 1;
            int b = _Y_ + 1;
            int kil = h[a, b];
            for (int row = 1; row <= Row; row++)
            {
                for (int col = 1; col <= Col; col++)
                {
                    if ((h[row, col] != 0))
                    {
                        count++;
                    }
                }
            }

            for (int l = 0; l < count; l++)
            {
                for (int ii = 1; ii <= Row; ii++)
                {
                    for (int jj = 1; jj <= Col; jj++)
                    {
                        if (h[ii, jj] - 1 == kil)
                        {
                            Line(a - 1, b - 1, ii - 1, jj - 1);
                            kil = h[ii, jj];
                            a = ii;
                            b = jj;


                        }
                    }
                }
            }
             Dosca();
           // this.Invoke(new Action(() => { panel2.Refresh(); }));
            this.Invoke(new Action(() => { textBox1.Text = counter.ToString(); }));
            
        }


        // метод соеденяющий линиями все координаты

        Point moveStart;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moveStart = new Point(e.X, e.Y);
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if ((e.Button & MouseButtons.Left) != 0)
            {

                Point deltaPos = new Point(e.X - moveStart.X, e.Y - moveStart.Y);

                this.Location = new Point(this.Location.X + deltaPos.X,
                this.Location.Y + deltaPos.Y);
            }

        }



        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Поток
        public void ThreadFunction()
        {

            Dosca();
            bypass = Convert.ToUInt64(textBox4.Text);
            dx[1] = 2; dx[2] = 1; dx[3] = -1; dx[4] = -2;
            dx[5] = -2; dx[6] = -1; dx[7] = 1; dx[8] = 2;
            dy[1] = 1; dy[2] = 2; dy[3] = 2; dy[4] = 1;
            dy[5] = -1; dy[6] = -2; dy[7] = -2; dy[8] = -1;
            n = Row;
            nsqr = n * n;

            h[_X_ + 1, _Y_ + 1] = 1;

            int count = 0;

            if (Brute(2, _X_ + 1, _Y_ + 1) == 0)
                MessageBox.Show("Нет решений");

            else
            {

               // Dosca();
                int a = _X_ + 1;
                int b = _Y_ + 1;
                int y = h[a, b];
                for (int row = 1; row <= Row; row++)
                {
                    for (int col = 1; col <= Col; col++)
                    {
                        if ((h[row, col] != 0))
                        {
                            count++;
                        }
                    }
                }

                for (int l = 0; l < count; l++)
                {
                    for (int ii = 1; ii <= Row; ii++)
                    {
                        for (int jj = 1; jj <= Col; jj++)
                        {
                            if (h[ii, jj] - 1 == y)
                            {
                                Line(a - 1, b - 1, ii - 1, jj - 1);
                                y = h[ii, jj];
                                a = ii;
                                b = jj;

                            }
                        }
                    }
                }
            }
            this.Invoke(new Action(() => { textBox1.Text = counter.ToString(); }));
           

            DoscaRezult();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            DisplayDoscaTree();
            Thread thread = new Thread(ThreadFunction);
            thread.Start();

        }


        // определение координат по клику
        //Считывание координат(ставим коня)
        void Clic(object sender, EventArgs e)
        {

            PictureBox picClick = sender as PictureBox;
            Image CurrentPic = picClick.Image;


            string[] NamePars = picClick.Name.Split('_');
            _X_ = Convert.ToInt32(NamePars[1]);
            _Y_ = Convert.ToInt32(NamePars[2]);
            Pole[_X_, _Y_].Image = img[2];


        }



        //рисуем доску picturebox
        void GetPanel()
        {

            Col = Convert.ToInt32(textBox2.Text);
            Row = Convert.ToInt32(textBox3.Text);
            Pole = new PictureBox[Col, Row];
            int X = 0, Y = 0;
            panel1.Controls.Clear();
            bool isBlack = false;
            for (int xx = 0; xx < Row; xx++)
            {
                X = 0;
                for (int yy = 0; yy < Col; yy++)
                {
                    if (isBlack)
                    {
                        PictureBox pic = new PictureBox()

                        {
                            Image = img[0],
                            Location = new System.Drawing.Point(X, Y),
                            Name = "_" + xx + "_" + yy,
                            Size = new System.Drawing.Size(40, 40),
                            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
                        };

                        pic.Click += Clic;
                        Pole[xx, yy] = pic;
                        panel1.Controls.Add(pic);
                        X += 40;
                        isBlack = false;
                    }
                    else
                    {
                        PictureBox pic = new PictureBox()

                        {
                            Image = img[1],
                            Location = new System.Drawing.Point(X, Y),
                            Name = "_" + xx + "_" + yy,
                            Size = new System.Drawing.Size(40, 40),
                            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
                        };

                        pic.Click += Clic;
                        Pole[xx, yy] = pic;
                        panel1.Controls.Add(pic);
                        X += 40;
                        isBlack = true;
                    }

                }
                Y += 40;
                if (Row % 2 == 0)
                    isBlack = !isBlack;
            }
        }

        async public void Get()
        {
            for (double i = 0.0; i < 0.95 ; i+=0.05)
            {
                this.Opacity = i;
                await Task.Delay(20);
            }
        }
    }
}