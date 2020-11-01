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

        private PictureBox fruit;
        private int rI, rJ;
        private int moveX = 1, moveY = 0;
        private int heigth = 800;
        private int width = 800;
        private int sizeOfSnake = 40;
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeyCath);
            for (int i = 0; i < width / sizeOfSnake; i++) {
              _generateMap(new Point(0,sizeOfSnake * i), new Size(width,1));
              _generateMap(new Point(sizeOfSnake * i, 0), new Size(1, heigth));               
            }
            _generateFruit();
            timer1.Tick += new EventHandler(_update);
            timer1.Interval = 500;
            timer1.Start();
           
        }

        private void _generateFruit() {
            this.fruit = new PictureBox();
            this.fruit.BackColor = Color.Yellow;
            this.fruit.Size = new Size(sizeOfSnake, sizeOfSnake);
            Random random = new Random();
            rI = random.Next(0, width);
            int temp = rI % sizeOfSnake;
            rI -= temp;
            rJ = random.Next(0, heigth);
            temp = rJ % sizeOfSnake;
            rJ -= temp;
            this.fruit.Location = new Point(rI,rJ);
            this.Controls.Add(fruit);
        }

        private void _update(object myObject,EventArgs eventArgs) {
          hadSnake.Location = new Point(hadSnake.Location.X + (moveX*sizeOfSnake), hadSnake.Location.Y+(moveY*sizeOfSnake));
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
                case Keys.Left:  moveX = -1; moveY = 0;   break;
                case Keys.Right: moveX = 1; moveY = 0; break;
                case Keys.Up:    moveY = -1;  moveX = 0; break;
                case Keys.Down:  moveY = 1;  moveX = 0; break;               
                default: /*"Нужно подумать еще чуток о реолизации"*/
                         //MessageBox.Show(e.KeyCode.ToString());
                break;
            }
        }
    }
}
