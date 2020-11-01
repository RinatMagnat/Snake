using System;
using System.IO;
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
    {   List<int> ls;
        private int Score;

        public saveScoreAndRecords(int score)
        {
            this.Score = score;
            StreamWriter sw;
            InitializeComponent();
            label2.Text = "Тукущий результат игры " + score +" очков";
            string path = Application.StartupPath + "\\";
            int temp = 0;
            string records= "records.txt";
            try
            {               
                sw = new StreamWriter(path + records, true, Encoding.UTF8);
                sw.WriteLine(score);
                sw.Close();
            }
            catch (Exception e) { }
            finally {                
                    }

            try
            {
                ls = new List<int>();
                StreamReader sr = new StreamReader(path + records);
                string line = sr.ReadLine();
                while (line != null)
                {
                    int.TryParse(line,out temp);
                    ls.Add(temp);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e) { }
            ls.Sort();
            ls.Reverse();
            label3.Text = "1. " + ls[0];
            if (ls.Count > 2)
            {
                label4.Text = "2. " + ls[1];
                if (ls.Count > 3)
                {
                    label5.Text = "3. " + ls[2];
                }
            }

            try
            {
                StreamWriter sw2 = new StreamWriter(path + records, false, Encoding.UTF8);
                sw2.WriteLine(ls[0]);
                if (ls.Count > 1)
                {
                    sw2.WriteLine(ls[1]);
                    if (ls.Count > 2)
                    {
                        sw2.WriteLine(ls[2]);
                    }
                }
                sw2.Close();
            }
            catch (Exception e) { }
            finally
            {
            }


        }

        private void saveScoreAndRecords_Load(object sender, EventArgs e)
        {

        }
    }
}
