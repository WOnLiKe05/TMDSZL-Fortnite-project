using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TMD_SZL_Fortnite_project
{
    public partial class Form1 : Form
    {
        public List<jatekos> jatekosok = new List<jatekos>();
        public List<int> legtobbkill = new List<int>();
        public List<int> legtobbXP = new List<int>();


        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("bg.png");
            lNev.Visible = false;
            lKill.Visible = false;
            lPajzs.Visible = false;
            lEletero.Visible = false;
            lSzint.Visible = false;
            lXP.Visible = false;
            pBFegyver1.Visible = false;
            pBFegyver2.Visible = false;
            pBFegyver3.Visible = false;
            pBFegyver4.Visible = false;
            pBFegyver5.Visible = false;
            pBItem1.Visible = false;
            pBItem2.Visible = false;
            pBItem3.Visible = false;
            pBItem4.Visible = false;
            pBItem5.Visible = false;
            pBItem6.Visible = false;
            pBItem7.Visible = false;
            pBItem8.Visible = false;
            lLoszer1.Visible = false;
            lLoszer2.Visible = false;
            lLoszer3.Visible = false;
            lLoszer4.Visible = false;
            lLoszer5.Visible = false;
            lBRanglista.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            randomgeneralas();
            felulet();
        }

        public void randomgeneralas()
        {

            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            List<string> nevekk = new List<string> { "ALehandro", "Mustafa", "Valamixd", "xXafaffXx", "FaZe-Kas", "LajosLakatos", "Parajt", "Vofsfd", "ASDASD", "dffdsaf" };


            List<string> fegyverekk = new List<string>();
            string[] fegyverek = { "SweeperShotgun", "StingerSMG", "DeadeyeDMR", "AssaultRifle", "DrumGun", "TacticalShotgun" };
            fegyverekk.AddRange(fegyverek);

            List<string> itemekk = new List<string>();
            string[] itemek = { "JunkRift", "Grappler", "Balloons", "Jetpack", "Bush", "Decoy", "BoomBox", "ShockwaveGrenade", "BoogieBomb" };
            itemekk.AddRange(itemek);

            List<int> loszerekk = new List<int>();
            int[] loszerek = { 7, 30, 10, 30, 80, 8 };
            loszerekk.AddRange(loszerek);

            int db = 0;
            for (int i = 0; i < 8; i++)
            {
                jatekos uj = new jatekos();
                uj.szam = db;
                uj.nev = nevekk[rnd.Next(nevekk.Count)];

                uj.szint = rnd.Next(1, 201);
                uj.xp = uj.szint * 80000;
                uj.eletero = rnd.Next(1, 101);
                uj.pajzs = rnd.Next(1, 101);
                uj.kill = rnd.Next(0, 21);

                for (int j = 0; j < 5; j++)
                {
                    int index = rnd.Next(fegyverekk.Count);

                    uj.fegyver.Add(fegyverekk[index]);
                    string a = fegyverekk[index];

                    uj.loszer.Add(rnd.Next(loszerekk[index] + 1));
                    uj.maxLoszer.Add(loszerekk[index]);
                    int b = loszerekk[index];

                    fegyverekk.Remove(a);
                    loszerekk.Remove(b);
                }


                for (int j = 0; j < 8; j++)
                {
                    int index = rnd.Next(itemekk.Count);
                    uj.item.Add(itemekk[index]);
                    string a = itemekk[index];

                    itemekk.Remove(a);
                }
                jatekosok.Add(uj);

                itemekk.Clear();
                fegyverekk.Clear();
                nevekk.Remove(uj.nev);
                fegyverekk.AddRange(fegyverek);
                itemekk.AddRange(itemek);
                loszerekk.Clear();
                loszerekk.AddRange(loszerek);

            }
            SortedSet<int> killek = new SortedSet<int>();
            SortedSet<int> xpk = new SortedSet<int>();

            foreach (var item in jatekosok)
            {
                killek.Add(item.kill);
            }
            foreach (var item in jatekosok)
            {
                xpk.Add(item.xp);
            }
            legtobbkill.AddRange(killek.Reverse());
            legtobbXP.AddRange(xpk.Reverse());
        }
        public void felulet()
        {
            nUDJatekos.Minimum = 1;
            nUDJatekos.Maximum = jatekosok.Count;
            nUDJatekos.ValueChanged += nUDJatekos_ValueChanged;

            rBKill.CheckedChanged += rBKill_CheckedChanged;
            rBXp.CheckedChanged += rBXp_CheckedChanged;

            lBJatekos.SelectedValueChanged += listBox1_SelectedValueChanged;

            foreach (var item in jatekosok)
            {
                lBJatekos.Items.Add(item.nev);
            }


        }

        private void nUDJatekos_ValueChanged(object sender, EventArgs e)
        {





        }

        private void rBKill_CheckedChanged(object sender, EventArgs e)
        {
            lBRanglista.Visible = true;
            lBRanglista.Items.Clear();
            foreach (var item in legtobbkill)
            {
                foreach (var item2 in jatekosok)
                {
                    if (item2.kill == item)
                    {
                        lBRanglista.Items.Add(item2.nev + " : " + item);
                    }
                }

            }
        }

        private void rBXp_CheckedChanged(object sender, EventArgs e)
        {
            lBRanglista.Visible = true;
            lBRanglista.Items.Clear();
            lBRanglista.Items.Clear();
            foreach (var item in legtobbXP)
            {
                foreach (var item2 in jatekosok)
                {
                    if (item2.xp == item)
                    {
                        lBRanglista.Items.Add(item2.nev + " : " + item);
                    }
                }

            }

        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //Levente része
            lNev.Visible = true;
            lKill.Visible = true;
            lPajzs.Visible = true;
            lEletero.Visible = true;
            lSzint.Visible = true;
            lXP.Visible = true;
            pBFegyver1.Visible = true;
            pBFegyver2.Visible = true;
            pBFegyver3.Visible = true;
            pBFegyver4.Visible = true;
            pBFegyver5.Visible = true;
            pBItem1.Visible = true;
            pBItem2.Visible = true;
            pBItem3.Visible = true;
            pBItem4.Visible = true;
            pBItem5.Visible = true;
            pBItem6.Visible = true;
            pBItem7.Visible = true;
            pBItem8.Visible = true;
            lLoszer1.Visible = true;
            lLoszer2.Visible = true;
            lLoszer3.Visible = true;
            lLoszer4.Visible = true;
            lLoszer5.Visible = true;


            foreach (var item in jatekosok)
            {
                if (lBJatekos.SelectedItem.ToString() == item.nev)
                {
                    lNev.Text = "Játékos neve: " + item.nev;
                    lKill.Text = "Kill: " + item.kill.ToString();
                    lPajzs.Text = "Pajzs: " + item.pajzs.ToString() + "/100";
                    lEletero.Text = "HP: " + item.eletero.ToString() + "/100";
                    lSzint.Text = "Szint: " + item.szint.ToString() + "/200";
                    lXP.Text = "XP: " + item.xp.ToString();
                    lLoszer1.Text = item.loszer[0].ToString() + "/" + item.maxLoszer[0].ToString();
                    lLoszer2.Text = item.loszer[1].ToString() + "/" + item.maxLoszer[1].ToString();
                    lLoszer3.Text = item.loszer[2].ToString() + "/" + item.maxLoszer[2].ToString();
                    lLoszer4.Text = item.loszer[3].ToString() + "/" + item.maxLoszer[3].ToString();
                    lLoszer5.Text = item.loszer[4].ToString() + "/" + item.maxLoszer[4].ToString();

                    pBFegyver1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBFegyver2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBFegyver3.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBFegyver4.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBFegyver5.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBFegyver1.Image = Image.FromFile(item.fegyver[0] + ".png");
                    pBFegyver2.Image = Image.FromFile(item.fegyver[1] + ".png");
                    pBFegyver3.Image = Image.FromFile(item.fegyver[2] + ".png");
                    pBFegyver4.Image = Image.FromFile(item.fegyver[3] + ".png");
                    pBFegyver5.Image = Image.FromFile(item.fegyver[4] + ".png");

                    pBItem1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBItem2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBItem3.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBItem4.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBItem5.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBItem6.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBItem7.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBItem8.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBItem1.Image = Image.FromFile(item.item[0] + ".png");
                    pBItem2.Image = Image.FromFile(item.item[1] + ".png");
                    pBItem3.Image = Image.FromFile(item.item[2] + ".png");
                    pBItem4.Image = Image.FromFile(item.item[3] + ".png");
                    pBItem5.Image = Image.FromFile(item.item[4] + ".png");
                    pBItem6.Image = Image.FromFile(item.item[5] + ".png");
                    pBItem7.Image = Image.FromFile(item.item[6] + ".png");
                    pBItem8.Image = Image.FromFile(item.item[7] + ".png");
                }
            }

        }

        private void lBJatekos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class jatekos
    {
        public int szam;
        public string nev;
        public int szint;
        public int xp;
        public int eletero;
        public int pajzs;
        public int kill;
        public List<string> fegyver = new List<string>();
        public HashSet<string> fegyv;
        public List<int> loszer = new List<int>();
        public List<int> maxLoszer = new List<int>();
        public List<string> item = new List<string>();
    }
}
