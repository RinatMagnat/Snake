using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class Form1 : Form
    {
        private int heigth = 800;
        private int width = 800;
        private int sizeOfSnake = 40;
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeyCath);
            for (int i = 0; i < width / sizeOfSnake; i++) {
              _generateMap(new Point(0,sizeOfSnake * i),new Size(width,1));
                _generateMap(new Point(sizeOfSnake * i, 0), new Size(1, heigth));
             
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void _generateMap(Point p, Size s) {

            PictureBox pb = new PictureBox();
            pb.Location = p;
            pb.BackColor = Color.Black;
            pb.Size = s;
            this.Controls.Add(pb);
        }     
        private void KeyCath(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.Left:  hadSnake.Location = new Point(hadSnake.Location.X - 40, hadSnake.Location.Y);   break;
                case Keys.Right: hadSnake.Location = new Point(hadSnake.Location.X + 40, hadSnake.Location.Y);   break;
                case Keys.Up: hadSnake.Location = new Point(hadSnake.Location.X, hadSnake.Location.Y - 40);  break;
                case Keys.Down: hadSnake.Location = new Point(hadSnake.Location.X, hadSnake.Location.Y + 40);   break;
                default:     break;
            }
        }
    }
}
