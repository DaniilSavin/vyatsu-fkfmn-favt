<<<<<<< HEAD
﻿using LifeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        Board board;
        int N = 0;
        int DensityNud = 15;

        public Form1()
        {
            InitializeComponent();
            Reset();
        }

        // GUI actions that require a board reset
        private void ResetButton_Click(object sender, EventArgs e) { Reset(); }
        private void pictureBox1_SizeChanged(object sender, EventArgs e) { Reset(); }
        private void SizeNud_ValueChanged(object sender, EventArgs e) { Reset(); }
        private void DensityNud_ValueChanged(object sender, EventArgs e) { Reset(); }

        private void Reset(bool randomize = true)
        {
            int SizeNud = 5;
            board = new Board(pictureBox1.Width, pictureBox1.Height, SizeNud);
            if (randomize) board.Randomize((double)DensityNud / 100);
            Render();
            N = 0;
            DelayNud.Value = 1000;
            timer1.Interval = (int)DelayNud.Value;
        }

        private void Reset(string startingPattern)
        {
            
            string[] lines = startingPattern.Split('\n');
            int yOffset = (board.Rows - lines.Length) / 2;
            int xOffset = (board.Columns - lines[0].Length) / 2;

            Reset(randomize: false);
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    board.Cells[x + xOffset, y + yOffset].IsAlive = lines[y].Substring(x, 1) == "X";
                }
            }
            Render();
        }

        // adjustments to timer
        private void RunCheckbox_CheckedChanged(object sender, EventArgs e) { timer1.Enabled = RunCheckbox.Checked; }
        private void DelayNud_ValueChanged(object sender, EventArgs e) { timer1.Interval = (int)DelayNud.Value; }
        private void timer1_Tick(object sender, EventArgs e)
        {
            board.Advance();
            Render();
        }

        // drawing the board
        private void Render()
        {
            N++;
            textBox1.Text = "Число ходов - " + (N-1).ToString();
            using (var bmp = new Bitmap(board.Width, board.Height))
            using (var gfx = Graphics.FromImage(bmp))
            using (var brush = new SolidBrush(Color.Orange))
            {
                gfx.Clear(ColorTranslator.FromHtml("#2f3539")); //серый
                var cellSize = (board.CellSize > 1) ?
                                new Size(board.CellSize - 1, board.CellSize - 1) :
                                new Size(board.CellSize, board.CellSize);

                for (int col = 0; col < board.Columns; col++)
                {
                    for (int row = 0; row < board.Rows; row++)
                    {
                        var cell = board.Cells[col, row];
                        if (cell.IsAlive)
                        {
                            var cellLocation = new Point(col * board.CellSize, row * board.CellSize);
                            var cellRect = new Rectangle(cellLocation, cellSize);
                            gfx.FillRectangle(brush, cellRect);
                        }
                    }
                }

                pictureBox1.Image?.Dispose();
                pictureBox1.Image = (Bitmap)bmp.Clone();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number11 =
                "---------XX-------------------\n" +
                "--------X--X------------------\n" +
                "--------X-X-------------------\n" +
                "---------X--------------------\n";
            Reset(number11);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string number12 =
                "----------X----X--------------\n" +
                "--------XX-XXXX-XX------------\n" +
                "----------X----X--------------\n";
            Reset(number12);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string number13 =
                "-------X--------X-------------\n" +
                "--------X--------X------------\n" +
                "----X---X---X----X------------\n" +
                "-----XXXX----XXXXX------------\n";
            Reset(number13);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string number14 =
                "-----------------XX-----------\n" +
                "-----------------XX-----------\n" +
                "------------------------------\n" +
                "---------------XXXX-----------\n" +
                "-----------XX-X----X----------\n" +
                "-----------XX-XX---X----------\n" +
                "--------------X--X-X-XX-------\n" +
                "--------------X-X--X-XX-------\n" +
                "---------------XXXX-----------\n" +
                "------------------------------\n" +
                "---------------XX-------------\n" +
                "---------------XX-------------\n";
            Reset(number14);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string number15 =
                "--------------------------X----------\n" +
                "-----------------------XXXX----X-----\n" +
                "--------------X-------XXXX-----X-----\n" +
                "-------------X-X------X--X---------XX\n" +
                "------------X---XX----XXXX---------XX\n" +
                "-XX---------X---XX-----XXXX----------\n" +
                "-XX---------X---XX--------X----------\n" +
                "-------------X-X---------------------\n" +
                "--------------X----------------------\n" +
                "-----------------------X-X-----------\n" +
                "------------------------XX-----------\n" +
                "------------------------X------------\n";
            Reset(number15);
        }
        //private void button6_Click(object sender, EventArgs e) //3.1
        //{
        //    string number21 =
        //        "------------X-----------------\n" +
        //        "-----------X-X----------------\n" +
        //        "----------X-X-----------------\n" +
        //        "-----------X------------------\n";
        //    Reset(number21);
        //}
        //private void button7_Click(object sender, EventArgs e) //3.2
        //{
        //    string number22 =
        //        "-----------XXX----------------\n" +
        //        "------------------------------\n" +
        //        "-------------X----------------\n" +
        //        "-------------X----------------\n" +
        //        "-------------X----------------\n" +
        //        "------------------------------\n" +
        //        "------------XXXX--------------\n";
        //    Reset(number22);
        //}
        //private void button8_Click(object sender, EventArgs e) //3.3
        //{
        //    string number23 =
        //        "-------------X----------------\n" +
        //        "------------X-X---------------\n" +
        //        "---------XXX---X--------------\n" +
        //        "-------------X--X-------------\n" +
        //        "---------X--XX----------------\n" +
        //        "---------X--XX----------------\n" +
        //        "--------------X---------------\n" +
        //        "----------XX------------------\n" +
        //        "----------X-----X-------------\n" +
        //        "----------X-X-XX--------------\n" +
        //        "---------------X--------------\n";
        //    Reset(number23);
        //}
        /*private void button6_Click(object sender, EventArgs e)
        {
            string number21 =
                "------------X-----------------\n" +
                "-----------X-X----------------\n" +
                "-----------X-X----------------\n" +
                "----------XX-XX-------------\n";
            Reset(number21);
        }*/
        private void button6_Click(object sender, EventArgs e)
        {
            string number21 =
                "-------------XXXX-------------\n" +
                "-------------XXXX-------------\n" +
                "-------------XXXX-------------\n" +
                "---------XXXX----XXXX---------\n" +
                "---------XXXX----XXXX---------\n" +
                "---------XXXX----XXXX---------\n" +
                "-----XXXX------------XXXX-----\n" +
                "-----XXXX------------XXXX-----\n" +
                "-----XXXX------------XXXX-----\n";
            Reset(number21);
        }
        /*private void button7_Click(object sender, EventArgs e)
        {
            string number22 =
                "-----------X---X--------------\n" +
                "----------X-X-X-X-------------\n" +
                "----------X--X--X-------------\n" +
                "----------X-----X-------------\n" +
                "-----------X---X--------------\n" +
                "------------X-X---------------\n" +
                "-------------X----------------\n";
            Reset(number22);
        }*/
        private void button7_Click(object sender, EventArgs e)
        {
            string number22 =
                "-------------XXXX-------------\n" +
                "-------------XXXX-------------\n" +
                "-------------XXXX-------------\n" +
                "-----XXXX----XXXX----XXXX-----\n" +
                "-----XXXX----XXXX----XXXX-----\n" +
                "-----XXXX----XXXX----XXXX-----\n" +
                "-XXXXXXXXXXXXXXXXXXXXXXXXXXXX-\n" +
                "-XXXXXXXXXXXXXXXXXXXXXXXXXXXX-\n" +
                "-XXXXXXXXXXXXXXXXXXXXXXXXXXXX-\n" +
                "-----XXXX----XXXX----XXXX-----\n" +
                "-----XXXX----XXXX----XXXX-----\n" +
                "-----XXXX----XXXX----XXXX-----\n" +
                "-------------XXXX-------------\n" +
                "-------------XXXX-------------\n" +
                "-------------XXXX-------------\n";
            Reset(number22);
        }
        /* private void button8_Click(object sender, EventArgs e)
         {
             string number23 =
                 "----------XXX-----X-----------\n" +
                 "-------------X--X-X-----------\n" +
                 "------XXX-X-X--X--X-XX--------\n" +
                 "-------XX--X--X---X-XX--------\n" +
                 "----------X----X--X-----------\n" +
                 "----------------X-X-----------\n";
             Reset(number23);
         }*/

        private void button8_Click(object sender, EventArgs e)
        {
            string number23 =
                "---------------------------------XXXX-------------\n" +
                "---------------------------------XXXX-------------\n" +
                "---------------------------------XXXX-------------\n" +
                "-----------------------------XXXX----XXXX---------\n" +
                "-----------------------------XXXX----XXXX---------\n" +
                "-----------------------------XXXX----XXXX---------\n" +
                "-------------------------XXXX------------XXXX-----\n" +
                "-------------------------XXXX------------XXXX-----\n" +
                "-------------------------XXXX------------XXXX-----\n" +
                "-------------XXXX---------------------------------\n" +
                "-------------XXXX---------------------------------\n" +
                "-------------XXXX---------------------------------\n" +
                "-----XXXX----XXXX----XXXX-------------------------\n" +
                "-----XXXX----XXXX----XXXX-------------------------\n" +
                "-----XXXX----XXXX----XXXX-------------------------\n" +
                "-XXXXXXXXXXXXXXXXXXXXXXXXXXXX---------------------\n" +
                "-XXXXXXXXXXXXXXXXXXXXXXXXXXXX---------------------\n" +
                "-XXXXXXXXXXXXXXXXXXXXXXXXXXXX---------------------\n" +
                "-----XXXX----XXXX----XXXX-------------------------\n" +
                "-----XXXX----XXXX----XXXX-------------------------\n" +
                "-----XXXX----XXXX----XXXX-------------------------\n" +
                "-------------XXXX---------------------------------\n" +
                "-------------XXXX---------------------------------\n" +
                "-------------XXXX---------------------------------\n";
            Reset(number23);
        }
    }
}
=======
﻿using LifeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        Board board;
        int N = 0;
        int DensityNud = 15;

        public Form1()
        {
            InitializeComponent();
            Reset();
        }

        // GUI actions that require a board reset
        private void ResetButton_Click(object sender, EventArgs e) { Reset(); }
        private void pictureBox1_SizeChanged(object sender, EventArgs e) { Reset(); }
        private void SizeNud_ValueChanged(object sender, EventArgs e) { Reset(); }
        private void DensityNud_ValueChanged(object sender, EventArgs e) { Reset(); }

        private void Reset(bool randomize = true)
        {
            int SizeNud = 5;
            board = new Board(pictureBox1.Width, pictureBox1.Height, SizeNud);
            if (randomize) board.Randomize((double)DensityNud / 100);
            Render();
            N = 0;
            DelayNud.Value = 1000;
            timer1.Interval = (int)DelayNud.Value;
        }

        private void Reset(string startingPattern)
        {
            
            string[] lines = startingPattern.Split('\n');
            int yOffset = (board.Rows - lines.Length) / 2;
            int xOffset = (board.Columns - lines[0].Length) / 2;

            Reset(randomize: false);
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    board.Cells[x + xOffset, y + yOffset].IsAlive = lines[y].Substring(x, 1) == "X";
                }
            }
            Render();
        }

        // adjustments to timer
        private void RunCheckbox_CheckedChanged(object sender, EventArgs e) { timer1.Enabled = RunCheckbox.Checked; }
        private void DelayNud_ValueChanged(object sender, EventArgs e) { timer1.Interval = (int)DelayNud.Value; }
        private void timer1_Tick(object sender, EventArgs e)
        {
            board.Advance();
            Render();
        }

        // drawing the board
        private void Render()
        {
            N++;
            textBox1.Text = "Число ходов - " + (N-1).ToString();
            using (var bmp = new Bitmap(board.Width, board.Height))
            using (var gfx = Graphics.FromImage(bmp))
            using (var brush = new SolidBrush(Color.Orange))
            {
                gfx.Clear(ColorTranslator.FromHtml("#2f3539")); //серый
                var cellSize = (board.CellSize > 1) ?
                                new Size(board.CellSize - 1, board.CellSize - 1) :
                                new Size(board.CellSize, board.CellSize);

                for (int col = 0; col < board.Columns; col++)
                {
                    for (int row = 0; row < board.Rows; row++)
                    {
                        var cell = board.Cells[col, row];
                        if (cell.IsAlive)
                        {
                            var cellLocation = new Point(col * board.CellSize, row * board.CellSize);
                            var cellRect = new Rectangle(cellLocation, cellSize);
                            gfx.FillRectangle(brush, cellRect);
                        }
                    }
                }

                pictureBox1.Image?.Dispose();
                pictureBox1.Image = (Bitmap)bmp.Clone();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number11 =
                "---------XX-------------------\n" +
                "--------X--X------------------\n" +
                "--------X-X-------------------\n" +
                "---------X--------------------\n";
            Reset(number11);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string number12 =
                "----------X----X--------------\n" +
                "--------XX-XXXX-XX------------\n" +
                "----------X----X--------------\n";
            Reset(number12);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string number13 =
                "-------X--------X-------------\n" +
                "--------X--------X------------\n" +
                "----X---X---X----X------------\n" +
                "-----XXXX----XXXXX------------\n";
            Reset(number13);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string number14 =
                "-----------------XX-----------\n" +
                "-----------------XX-----------\n" +
                "------------------------------\n" +
                "---------------XXXX-----------\n" +
                "-----------XX-X----X----------\n" +
                "-----------XX-XX---X----------\n" +
                "--------------X--X-X-XX-------\n" +
                "--------------X-X--X-XX-------\n" +
                "---------------XXXX-----------\n" +
                "------------------------------\n" +
                "---------------XX-------------\n" +
                "---------------XX-------------\n";
            Reset(number14);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string number15 =
                "--------------------------X----------\n" +
                "-----------------------XXXX----X-----\n" +
                "--------------X-------XXXX-----X-----\n" +
                "-------------X-X------X--X---------XX\n" +
                "------------X---XX----XXXX---------XX\n" +
                "-XX---------X---XX-----XXXX----------\n" +
                "-XX---------X---XX--------X----------\n" +
                "-------------X-X---------------------\n" +
                "--------------X----------------------\n" +
                "-----------------------X-X-----------\n" +
                "------------------------XX-----------\n" +
                "------------------------X------------\n";
            Reset(number15);
        }
        //private void button6_Click(object sender, EventArgs e) //3.1
        //{
        //    string number21 =
        //        "------------X-----------------\n" +
        //        "-----------X-X----------------\n" +
        //        "----------X-X-----------------\n" +
        //        "-----------X------------------\n";
        //    Reset(number21);
        //}
        //private void button7_Click(object sender, EventArgs e) //3.2
        //{
        //    string number22 =
        //        "-----------XXX----------------\n" +
        //        "------------------------------\n" +
        //        "-------------X----------------\n" +
        //        "-------------X----------------\n" +
        //        "-------------X----------------\n" +
        //        "------------------------------\n" +
        //        "------------XXXX--------------\n";
        //    Reset(number22);
        //}
        //private void button8_Click(object sender, EventArgs e) //3.3
        //{
        //    string number23 =
        //        "-------------X----------------\n" +
        //        "------------X-X---------------\n" +
        //        "---------XXX---X--------------\n" +
        //        "-------------X--X-------------\n" +
        //        "---------X--XX----------------\n" +
        //        "---------X--XX----------------\n" +
        //        "--------------X---------------\n" +
        //        "----------XX------------------\n" +
        //        "----------X-----X-------------\n" +
        //        "----------X-X-XX--------------\n" +
        //        "---------------X--------------\n";
        //    Reset(number23);
        //}
        /*private void button6_Click(object sender, EventArgs e)
        {
            string number21 =
                "------------X-----------------\n" +
                "-----------X-X----------------\n" +
                "-----------X-X----------------\n" +
                "----------XX-XX-------------\n";
            Reset(number21);
        }*/
        private void button6_Click(object sender, EventArgs e)
        {
            string number21 =
                "-------------XXXX-------------\n" +
                "-------------XXXX-------------\n" +
                "-------------XXXX-------------\n" +
                "---------XXXX----XXXX---------\n" +
                "---------XXXX----XXXX---------\n" +
                "---------XXXX----XXXX---------\n" +
                "-----XXXX------------XXXX-----\n" +
                "-----XXXX------------XXXX-----\n" +
                "-----XXXX------------XXXX-----\n";
            Reset(number21);
        }
        /*private void button7_Click(object sender, EventArgs e)
        {
            string number22 =
                "-----------X---X--------------\n" +
                "----------X-X-X-X-------------\n" +
                "----------X--X--X-------------\n" +
                "----------X-----X-------------\n" +
                "-----------X---X--------------\n" +
                "------------X-X---------------\n" +
                "-------------X----------------\n";
            Reset(number22);
        }*/
        private void button7_Click(object sender, EventArgs e)
        {
            string number22 =
                "-------------XXXX-------------\n" +
                "-------------XXXX-------------\n" +
                "-------------XXXX-------------\n" +
                "-----XXXX----XXXX----XXXX-----\n" +
                "-----XXXX----XXXX----XXXX-----\n" +
                "-----XXXX----XXXX----XXXX-----\n" +
                "-XXXXXXXXXXXXXXXXXXXXXXXXXXXX-\n" +
                "-XXXXXXXXXXXXXXXXXXXXXXXXXXXX-\n" +
                "-XXXXXXXXXXXXXXXXXXXXXXXXXXXX-\n" +
                "-----XXXX----XXXX----XXXX-----\n" +
                "-----XXXX----XXXX----XXXX-----\n" +
                "-----XXXX----XXXX----XXXX-----\n" +
                "-------------XXXX-------------\n" +
                "-------------XXXX-------------\n" +
                "-------------XXXX-------------\n";
            Reset(number22);
        }
        /* private void button8_Click(object sender, EventArgs e)
         {
             string number23 =
                 "----------XXX-----X-----------\n" +
                 "-------------X--X-X-----------\n" +
                 "------XXX-X-X--X--X-XX--------\n" +
                 "-------XX--X--X---X-XX--------\n" +
                 "----------X----X--X-----------\n" +
                 "----------------X-X-----------\n";
             Reset(number23);
         }*/

        private void button8_Click(object sender, EventArgs e)
        {
            string number23 =
                "---------------------------------XXXX-------------\n" +
                "---------------------------------XXXX-------------\n" +
                "---------------------------------XXXX-------------\n" +
                "-----------------------------XXXX----XXXX---------\n" +
                "-----------------------------XXXX----XXXX---------\n" +
                "-----------------------------XXXX----XXXX---------\n" +
                "-------------------------XXXX------------XXXX-----\n" +
                "-------------------------XXXX------------XXXX-----\n" +
                "-------------------------XXXX------------XXXX-----\n" +
                "-------------XXXX---------------------------------\n" +
                "-------------XXXX---------------------------------\n" +
                "-------------XXXX---------------------------------\n" +
                "-----XXXX----XXXX----XXXX-------------------------\n" +
                "-----XXXX----XXXX----XXXX-------------------------\n" +
                "-----XXXX----XXXX----XXXX-------------------------\n" +
                "-XXXXXXXXXXXXXXXXXXXXXXXXXXXX---------------------\n" +
                "-XXXXXXXXXXXXXXXXXXXXXXXXXXXX---------------------\n" +
                "-XXXXXXXXXXXXXXXXXXXXXXXXXXXX---------------------\n" +
                "-----XXXX----XXXX----XXXX-------------------------\n" +
                "-----XXXX----XXXX----XXXX-------------------------\n" +
                "-----XXXX----XXXX----XXXX-------------------------\n" +
                "-------------XXXX---------------------------------\n" +
                "-------------XXXX---------------------------------\n" +
                "-------------XXXX---------------------------------\n";
            Reset(number23);
        }
    }
}
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
