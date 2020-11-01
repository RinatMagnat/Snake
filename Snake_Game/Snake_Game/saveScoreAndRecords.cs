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
    public partial class saveScoreAndRecords : Form
    {
        private int Score;
        public saveScoreAndRecords(int score)
        {
            this.Score = score;
            InitializeComponent();
            label2.Text = "Тукущий результат игры " + score +" очков";
        }

        private void saveScoreAndRecords_Load(object sender, EventArgs e)
        {

        }
    }
}
