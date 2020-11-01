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
        private PictureBox[] picture;
        private PictureBox fruit;
        private int rI, rJ;
        private int moveX = 1, moveY = 0;
        private int heigth = 800;
        private int width  = 800;
        private int sizeOfSnake = 40;
        private int score = 0;
        private int step  = 0;
        private Label lb;
        public Form1()
        {
            InitializeComponent();
            _generateSnake();
            _createPanel();
            this.KeyDown += new KeyEventHandler(KeyCath);
            for (int i = 0; i < width / sizeOfSnake; i++) {
              _generateMap(new Point(0,sizeOfSnake * i), new Size(width,1));
              _generateMap(new Point(sizeOfSnake * i, 0), new Size(1, heigth));               
            }
            _generateFruit();
            timer1.Tick    += new EventHandler(_update);
            timer1.Interval = 500;
            timer1.Start();
           
        }

        private void _createPanel() {

            char chLeft  = '\u2190';   //стрелка на лево
            char chRigth = '\u2192';   //стрелка на право
            char chUp    = '\u2191';   //стрелка в вверх
            char chDown  = '\u2193';   //стрелка вниз 

            Panel pn     = new Panel();
            pn.Size      = new Size(150, 900);
            pn.Location  = new Point(900-100,0);
            pn.BackColor = Color.Blue;
            lb           = new Label();
            lb.Location  = new Point(20, 0);
            lb.Font      = new Font("Microsoft Sans Serif", 12F);
            lb.ForeColor = Color.Yellow;
            lb.Text = "Score: " + this.score+" ";            
            this.Controls.Add(pn);
            pn.Controls.Add(lb);

            Label LbLeft     = new Label();
            LbLeft.Location  = new Point(20, 30);
            LbLeft.ForeColor = Color.Yellow;
            LbLeft.Font      = new Font("Microsoft Sans Serif", 12F);                     
            LbLeft.Text      = chLeft + " Left";
            pn.Controls.Add(LbLeft);    
            
            Label LbRigth     = new Label();
            LbRigth.Location  = new Point(20, 60);
            LbRigth.ForeColor = Color.Yellow;
            LbRigth.Font      = new Font("Microsoft Sans Serif", 12F);
            LbRigth.Text      = chRigth + " Right";
            pn.Controls.Add(LbRigth);

            Label LbUp     = new Label();
            LbUp.Location  = new Point(20, 90);
            LbUp.ForeColor = Color.Yellow;
            LbUp.Font      = new Font("Microsoft Sans Serif", 12F);
            LbUp.Text = chUp + "  Up";
            pn.Controls.Add(LbUp);

            Label LbDown     = new Label();
            LbDown.Location  = new Point(20, 120);
            LbDown.ForeColor = Color.Yellow;
            LbDown.Font      = new Font("Microsoft Sans Serif", 12F);
            LbDown.Text      = chDown + "  Down";
            pn.Controls.Add(LbDown);

            Label LbHelp     = new Label();
            LbHelp.Location  = new Point(20, 150);
            LbHelp.ForeColor = Color.Yellow;
            LbHelp.Font      = new Font("Microsoft Sans Serif", 12F);
            LbHelp.Text      = " F1 " + "  Help";
            pn.Controls.Add(LbHelp);

            Label LbEsc      = new Label();
            LbEsc.Location   = new Point(20, 180);
            LbEsc.ForeColor  = Color.Yellow;
            LbEsc.Font       = new Font("Microsoft Sans Serif", 12F);
            LbEsc.Text       = " Esc "+ " Close";
            pn.Controls.Add(LbEsc);


        }

        private void _eatFruit() {
            PictureBox pb  = new PictureBox();
            pb.Size        = new Size(sizeOfSnake, sizeOfSnake);
            pb.Location    = new Point(this.picture[score-1].Location.X - 40 * moveX, this.picture[score-1].Location.Y - 40 * moveY);
            pb.BackColor   = Color.Green;
            picture[score] = pb;
            this.Controls.Add(picture[score]);
        }

        private void _creashSnake() {
            for (int i = 0; i < score; i++) {
                if (picture[0].Location == picture[i].Location && i!=0) {
                    //удаляем хвост змее
                    for (int j = score; j>=i;j--){
                        score = i-1;
                        this.Controls.Remove(picture[j]);
                    }
                }
            }
            lb.Text = "Score: " + this.score*step + " ";
        }

        private void _generateSnake() {
            picture              = new PictureBox[200];
            picture[0]           = new PictureBox();
            picture[0].BackColor = Color.Black;
            picture[0].Location  = new Point(0, 0);
            picture[0].Size      = new Size(sizeOfSnake, sizeOfSnake);
            this.Controls.Add(picture[0]);
        }

        private void MoveSnake() {
            for (int i = score; i >= 1; i--) {
                picture[i].Location = picture[i - 1].Location;
            }
            picture[0].Location = new Point(picture[0].Location.X + (moveX * sizeOfSnake), picture[0].Location.Y + (moveY * sizeOfSnake));
            _creashSnake();
        }

        private void _generateFruit() {
            this.fruit            = new PictureBox();
            this.fruit.BackColor  = Color.Yellow;
            this.fruit.Size       = new Size(sizeOfSnake, sizeOfSnake);
            Random random         = new Random();
            rI                    = random.Next(0, width);
            int temp              = rI % sizeOfSnake;
            rI -= temp;
            rJ                    = random.Next(0, heigth);
            temp                  = rJ % sizeOfSnake;
            rJ -= temp;
            this.fruit.Location   = new Point(rI,rJ);
            this.Controls.Add(fruit);
        }

        private void _update(object myObject,EventArgs eventArgs) {
            MoveSnake();
            _checkBorder();
            if (picture[0].Location == fruit.Location) { fruit.Dispose(); _generateFruit(); this.score++; this.step += 1; _eatFruit(); lb.Text = "Score: " + this.score*step + " ";
                if (timer1.Interval > 50)
                {
                    timer1.Stop(); timer1.Interval -= 50; timer1.Start();
                }
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

        private void _checkBorder() {
            if (picture[0].Location.X < 0) {
                picture[0].Location = new Point(760, picture[0].Location.Y);
            }
            if (picture[0].Location.Y > 760) {
                picture[0].Location = new Point(picture[0].Location.X, 0);
            }
            if (picture[0].Location.X > 760) {
                picture[0].Location = new Point(0, picture[0].Location.Y);
            }
            if (picture[0].Location.Y < 0) {
                picture[0].Location = new Point(picture[0].Location.X,760);
            }
        }

        private void KeyCath(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.Left:  moveX = -1;  moveY = 0; break;
                case Keys.Right: moveX =  1;  moveY = 0; break;
                case Keys.Up:    moveY = -1;  moveX = 0; break;
                case Keys.Down:  moveY =  1;  moveX = 0; break;
                case Keys.Space: if (timer1.Enabled == true) { timer1.Stop(); } else { timer1.Start(); } break; //запускаем и останавливаем таймер
                case Keys.F1:
                    timer1.Stop();
                    saveScoreAndRecords sv = new saveScoreAndRecords(score*step);                    
                    if (sv.ShowDialog() == DialogResult.OK) {
                        timer1.Start();
                    }
                    break;
                case Keys.Escape: Close(); break;
                default: break;
            }
        }

    }
}
