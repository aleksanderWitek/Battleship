using Battleship_v1._0.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Battleship_v1._0.Function;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Battleship_v1._0
{

    public partial class Form1 : Form
    { 
        public Form1()
        {            
            InitializeComponent();
            Restart();
        }

        string boardName;
        string fieldName;
        string boardFieldName;
        public List<Button> Player_1_Buttons_List;
        public List<Button> Player_2_Buttons_List;
        public List<Button> Enemy_1_Buttons_List;
        public List<Button> Enemy_2_Buttons_List;
        int shipDirection;
        int player1Score;
        int player2Score;
        int round;

        public void BlueShip_UpdatePlayerBoard()
        {
            Player_1_Buttons_List = new List<Button> {p1_A1, p1_B1, p1_C1, p1_D1, p1_E1,
                                                      p1_A2, p1_B2, p1_C2, p1_D2, p1_E2,
                                                      p1_A3, p1_B3, p1_C3, p1_D3, p1_E3,
                                                      p1_A4, p1_B4, p1_C4, p1_D4, p1_E4,
                                                      p1_A5, p1_B5, p1_C5, p1_D5, p1_E5};

            Player_2_Buttons_List = new List<Button> {p2_A1, p2_B1, p2_C1, p2_D1, p2_E1,
                                                      p2_A2, p2_B2, p2_C2, p2_D2, p2_E2,
                                                      p2_A3, p2_B3, p2_C3, p2_D3, p2_E3,
                                                      p2_A4, p2_B4, p2_C4, p2_D4, p2_E4,
                                                      p2_A5, p2_B5, p2_C5, p2_D5, p2_E5};



            if (boardName == "p1")
            {
                for (int i = 0; i < Player_1_Buttons_List.Count; i++)
                {
                    if (Player_1_Buttons_List[i].Name == boardFieldName)
                    {
                        Player_1_Buttons_List[i].BackgroundImage = Properties.Resources.ship_blue_1;
                        Player_1_Buttons_List[i + (shipDirection)].BackgroundImage = Properties.Resources.ship_blue_2;
                        UpdatePlayerBoardInDb.PutBlueShipOnTheBoardInDb(fieldName, boardName, shipDirection);
                    }
                }
            }
            else if (boardName == "p2")
            {
                for (int i = 0; i < Player_2_Buttons_List.Count; i++)
                {
                    if (Player_2_Buttons_List[i].Name == boardFieldName)
                    {
                        Player_2_Buttons_List[i].BackgroundImage = Properties.Resources.ship_blue_1;
                        Player_2_Buttons_List[i + (shipDirection)].BackgroundImage = Properties.Resources.ship_blue_2;
                        UpdatePlayerBoardInDb.PutBlueShipOnTheBoardInDb(fieldName, boardName, shipDirection);
                    }
                }
            }
            BlueShipDirectionPanel.Visible = false;
            pickShipPanel.Visible = false;
        }

        public void RedShip_UpdatePlayerBoard()
        {
            Player_1_Buttons_List = new List<Button> {p1_A1, p1_B1, p1_C1, p1_D1, p1_E1,
                                                      p1_A2, p1_B2, p1_C2, p1_D2, p1_E2,
                                                      p1_A3, p1_B3, p1_C3, p1_D3, p1_E3,
                                                      p1_A4, p1_B4, p1_C4, p1_D4, p1_E4,
                                                      p1_A5, p1_B5, p1_C5, p1_D5, p1_E5};

            Player_2_Buttons_List = new List<Button> {p2_A1, p2_B1, p2_C1, p2_D1, p2_E1,
                                                      p2_A2, p2_B2, p2_C2, p2_D2, p2_E2,
                                                      p2_A3, p2_B3, p2_C3, p2_D3, p2_E3,
                                                      p2_A4, p2_B4, p2_C4, p2_D4, p2_E4,
                                                      p2_A5, p2_B5, p2_C5, p2_D5, p2_E5};


            if (boardName == "p1")
            {
                for (int i = 0; i < Player_1_Buttons_List.Count; i++)
                {
                    if (Player_1_Buttons_List[i].Name == boardFieldName)
                    {
                        Player_1_Buttons_List[i].BackgroundImage = Properties.Resources.ship_red_1;
                        Player_1_Buttons_List[i + (shipDirection)].BackgroundImage = Properties.Resources.ship_red_2;
                        Player_1_Buttons_List[i + (2*shipDirection)].BackgroundImage = Properties.Resources.ship_red_3;
                        UpdatePlayerBoardInDb.PutRedShipOnTheBoardInDb(fieldName, boardName, shipDirection);
                    }
                }
            }
            else if (boardName == "p2")
            {
                for (int i = 0; i < Player_2_Buttons_List.Count; i++)
                {
                    if (Player_2_Buttons_List[i].Name == boardFieldName)
                    {
                        Player_2_Buttons_List[i].BackgroundImage = Properties.Resources.ship_red_1;
                        Player_2_Buttons_List[i + (shipDirection)].BackgroundImage = Properties.Resources.ship_red_2;
                        Player_2_Buttons_List[i + (2 * shipDirection)].BackgroundImage = Properties.Resources.ship_red_3;
                        UpdatePlayerBoardInDb.PutRedShipOnTheBoardInDb(fieldName, boardName, shipDirection);
                    }
                }
            }
            RedShipDirectionPanel.Visible = false;
            pickShipPanel.Visible = false;
        }

        public void isFieldEmpty()
        {
            var db = new BattleshipContext();
            var obj = new Function.PickingShip();
            var isEmpty = obj.PickingShip_FirstStep(fieldName, boardName);


            if (isEmpty == true)
            {
                pickShipPanel.Visible = true;

                if (boardName == "p1")
                {
                    if (db.Player_1_Boards.Where(x => x.shipsID == 3).Count() < 2)
                    {
                        pickPanel_blueShip.Enabled = true;
                    }
                    else pickPanel_blueShip.Enabled = false;
                    if (db.Player_1_Boards.Where(x => x.shipsID == 7).Count() < 2)
                    {
                        pickPanel_redShip.Enabled = true;
                    }
                    else pickPanel_redShip.Enabled = false;
                }
                else if (boardName == "p2")
                {
                    if (db.Player_2_Boards.Where(x => x.shipsID == 3).Count() < 2)
                    {
                        pickPanel_blueShip.Enabled = true;
                    }
                    else pickPanel_blueShip.Enabled = false;
                    if (db.Player_2_Boards.Where(x => x.shipsID == 7).Count() < 2)
                    {
                        pickPanel_redShip.Enabled = true;
                    }
                    else pickPanel_redShip.Enabled = false;
                }
                else pickShipPanel.Visible = false;
            }
        }

        public void Restart()
        {
            var db = new BattleshipContext();

            Player_1_Buttons_List = new List<Button> {p1_A1, p1_B1, p1_C1, p1_D1, p1_E1,
                                                      p1_A2, p1_B2, p1_C2, p1_D2, p1_E2,
                                                      p1_A3, p1_B3, p1_C3, p1_D3, p1_E3,
                                                      p1_A4, p1_B4, p1_C4, p1_D4, p1_E4,
                                                      p1_A5, p1_B5, p1_C5, p1_D5, p1_E5};


            Player_2_Buttons_List = new List<Button> {p2_A1, p2_B1, p2_C1, p2_D1, p2_E1,
                                                      p2_A2, p2_B2, p2_C2, p2_D2, p2_E2,
                                                      p2_A3, p2_B3, p2_C3, p2_D3, p2_E3,
                                                      p2_A4, p2_B4, p2_C4, p2_D4, p2_E4,
                                                      p2_A5, p2_B5, p2_C5, p2_D5, p2_E5};

            Enemy_1_Buttons_List = new List<Button>  {e1_A1, e1_B1, e1_C1, e1_D1, e1_E1,
                                                      e1_A2, e1_B2, e1_C2, e1_D2, e1_E2,
                                                      e1_A3, e1_B3, e1_C3, e1_D3, e1_E3,
                                                      e1_A4, e1_B4, e1_C4, e1_D4, e1_E4,
                                                      e1_A5, e1_B5, e1_C5, e1_D5, e1_E5};

            Enemy_2_Buttons_List = new List<Button> {e2_A1, e2_B1, e2_C1, e2_D1, e2_E1,
                                                     e2_A2, e2_B2, e2_C2, e2_D2, e2_E2,
                                                     e2_A3, e2_B3, e2_C3, e2_D3, e2_E3,
                                                     e2_A4, e2_B4, e2_C4, e2_D4, e2_E4,
                                                     e2_A5, e2_B5, e2_C5, e2_D5, e2_E5};

            foreach (var item in db.Player_1_Boards)
            {
                item.shipsID = 1;
            }
            foreach (var item in db.Player_2_Boards)
            {
                item.shipsID = 1;
            }
            foreach (var item in db.Enemy_1_Boards)
            {
                item.shipsID = 1;
            }
            foreach (var item in db.Enemy_2_Boards)
            {
                item.shipsID = 1;
            }
            db.SaveChanges();

            for (int i = 0; i < Player_1_Buttons_List.Count; i++)
            {
                Player_1_Buttons_List[i].BackgroundImage = Properties.Resources.empty_hidden;
                Player_1_Buttons_List[i].Enabled = true;
                Player_1_Buttons_List[i].Visible = true;
            }
            for (int i = 0; i < Player_2_Buttons_List.Count; i++)
            {
                Player_2_Buttons_List[i].BackgroundImage = Properties.Resources.empty_hidden;
                Player_2_Buttons_List[i].Visible = false;
                Player_2_Buttons_List[i].Enabled = true;
            }
            for (int i = 0; i < Enemy_1_Buttons_List.Count; i++)
            {
                Enemy_1_Buttons_List[i].BackgroundImage = Properties.Resources.empty_hidden;
                Enemy_1_Buttons_List[i].Visible = false;
            }
            for (int i = 0; i < Enemy_2_Buttons_List.Count; i++)
            {
                Enemy_2_Buttons_List[i].BackgroundImage = Properties.Resources.empty_hidden;
                Enemy_2_Buttons_List[i].Visible = false;
            }

            pickShipPanel.Visible = false;
            BlueShipDirectionPanel.Visible = false;
            RedShipDirectionPanel.Visible = false;
            finishRoundButtonPlayer_1.Visible = false;
            finishRoundButtonPlayer_2.Visible = false;
            startRoundButton_Player_1.Visible = false;
            startRoundButton_Player_2.Visible = false;
            finishedShipsRound_Player_2.Visible = false;
            championPanel.Visible = false;
            startShipsRound_Player_2.Visible = false;
            player1Score = 0;
            player_1_score.Text = player1Score.ToString();
            player2Score = 0;
            player_2_score.Text = player2Score.ToString();
            round = 0;
            round_score.Text = round.ToString();
            finishedShipsRound_Player_1.Visible = true;
        }

        public void ShootYourEnemy()
        {
            var db = new BattleshipContext();

            Enemy_1_Buttons_List = new List<Button>  {e1_A1, e1_B1, e1_C1, e1_D1, e1_E1,
                                                      e1_A2, e1_B2, e1_C2, e1_D2, e1_E2,
                                                      e1_A3, e1_B3, e1_C3, e1_D3, e1_E3,
                                                      e1_A4, e1_B4, e1_C4, e1_D4, e1_E4,
                                                      e1_A5, e1_B5, e1_C5, e1_D5, e1_E5};

            Enemy_2_Buttons_List = new List<Button> {e2_A1, e2_B1, e2_C1, e2_D1, e2_E1,
                                                     e2_A2, e2_B2, e2_C2, e2_D2, e2_E2,
                                                     e2_A3, e2_B3, e2_C3, e2_D3, e2_E3,
                                                     e2_A4, e2_B4, e2_C4, e2_D4, e2_E4,
                                                     e2_A5, e2_B5, e2_C5, e2_D5, e2_E5};

            if(boardName == "e2")
            {
                if(db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 1)
                {
                    for (int i = 0; i < Enemy_2_Buttons_List.Count; i++)
                    {
                        if(Enemy_2_Buttons_List[i].Name == boardFieldName)
                        {
                            Enemy_2_Buttons_List[i].BackgroundImage = Properties.Resources.empty_hidden_shot;
                            Enemy_2_Buttons_List[i].Enabled = false;
                            var shotedShip = db.Player_1_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                            shotedShip.shipsID = 2;
                        }
                    }
                }
                else if(db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 3)
                {
                    for (int i = 0; i < Enemy_2_Buttons_List.Count; i++)
                    {
                        if (Enemy_2_Buttons_List[i].Name == boardFieldName)
                        {
                            Enemy_2_Buttons_List[i].BackgroundImage = Properties.Resources.ship_blue_1_shot;
                            Enemy_2_Buttons_List[i].Enabled = false;
                            var shotedShip = db.Player_1_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                            shotedShip.shipsID = 4;
                            player2Score++;
                            player_2_score.Text = player2Score.ToString();
                        }
                    }
                }
                else if (db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 5)
                {
                    for (int i = 0; i < Enemy_2_Buttons_List.Count; i++)
                    {
                        if (Enemy_2_Buttons_List[i].Name == boardFieldName)
                        {
                            Enemy_2_Buttons_List[i].BackgroundImage = Properties.Resources.ship_blue_2_shot;
                            Enemy_2_Buttons_List[i].Enabled = false;
                            var shotedShip = db.Player_1_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                            shotedShip.shipsID = 6;
                            player2Score++;
                            player_2_score.Text = player2Score.ToString();
                        }
                    }
                }
                else if (db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 7)
                {
                    for (int i = 0; i < Enemy_2_Buttons_List.Count; i++)
                    {
                        if (Enemy_2_Buttons_List[i].Name == boardFieldName)
                        {
                            Enemy_2_Buttons_List[i].BackgroundImage = Properties.Resources.ship_red_1_shot;
                            Enemy_2_Buttons_List[i].Enabled = false;
                            var shotedShip = db.Player_1_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                            shotedShip.shipsID = 8;
                            player2Score++;
                            player_2_score.Text = player2Score.ToString();
                        }
                    }
                }
                else if (db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 9)
                {
                    for (int i = 0; i < Enemy_2_Buttons_List.Count; i++)
                    {
                        if (Enemy_2_Buttons_List[i].Name == boardFieldName)
                        {
                            Enemy_2_Buttons_List[i].BackgroundImage = Properties.Resources.ship_red_2_shot;
                            Enemy_2_Buttons_List[i].Enabled = false;
                            var shotedShip = db.Player_1_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                            shotedShip.shipsID = 10;
                            player2Score++;
                            player_2_score.Text = player2Score.ToString();
                        }
                    }
                }
                else if (db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 11)
                {
                    for (int i = 0; i < Enemy_2_Buttons_List.Count; i++)
                    {
                        if (Enemy_2_Buttons_List[i].Name == boardFieldName)
                        {
                            Enemy_2_Buttons_List[i].BackgroundImage = Properties.Resources.ship_red_3_shot;
                            Enemy_2_Buttons_List[i].Enabled = false;
                            var shotedShip = db.Player_1_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                            shotedShip.shipsID = 12;
                            player2Score++;
                            player_2_score.Text = player2Score.ToString();
                        }
                    }
                }
                for (int i = 0; i < Enemy_2_Buttons_List.Count; i++)
                {
                    Enemy_2_Buttons_List[i].Enabled = false;
                }
                round++;
                round_score.Text = round.ToString();
            }
            else if (boardName == "e1")
            {
                if (db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 1)
                {
                    for (int i = 0; i < Enemy_1_Buttons_List.Count; i++)
                    {
                        if (Enemy_1_Buttons_List[i].Name == boardFieldName)
                        {
                            Enemy_1_Buttons_List[i].BackgroundImage = Properties.Resources.empty_hidden_shot;
                            Enemy_1_Buttons_List[i].Enabled = false;
                            var shotedShip = db.Player_2_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                            shotedShip.shipsID = 2;
                        }
                    }
                }
                else if (db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 3)
                {
                    for (int i = 0; i < Enemy_1_Buttons_List.Count; i++)
                    {
                        if (Enemy_1_Buttons_List[i].Name == boardFieldName)
                        {
                            Enemy_1_Buttons_List[i].BackgroundImage = Properties.Resources.ship_blue_1_shot;
                            Enemy_1_Buttons_List[i].Enabled = false;
                            var shotedShip = db.Player_2_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                            shotedShip.shipsID = 4;
                            player1Score++;
                            player_1_score.Text = player1Score.ToString();
                        }
                    }
                }
                else if (db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 5)
                {
                    for (int i = 0; i < Enemy_1_Buttons_List.Count; i++)
                    {
                        if (Enemy_1_Buttons_List[i].Name == boardFieldName)
                        {
                            Enemy_1_Buttons_List[i].BackgroundImage = Properties.Resources.ship_blue_2_shot;
                            Enemy_1_Buttons_List[i].Enabled = false;
                            var shotedShip = db.Player_2_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                            shotedShip.shipsID = 6;
                            player1Score++;
                            player_1_score.Text = player1Score.ToString();
                        }
                    }
                }
                else if (db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 7)
                {
                    for (int i = 0; i < Enemy_1_Buttons_List.Count; i++)
                    {
                        if (Enemy_1_Buttons_List[i].Name == boardFieldName)
                        {
                            Enemy_1_Buttons_List[i].BackgroundImage = Properties.Resources.ship_red_1_shot;
                            Enemy_1_Buttons_List[i].Enabled = false;
                            var shotedShip = db.Player_2_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                            shotedShip.shipsID = 8;
                            player1Score++;
                            player_1_score.Text = player1Score.ToString();
                        }
                    }
                }
                else if (db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 9)
                {
                    for (int i = 0; i < Enemy_1_Buttons_List.Count; i++)
                    {
                        if (Enemy_1_Buttons_List[i].Name == boardFieldName)
                        {
                            Enemy_1_Buttons_List[i].BackgroundImage = Properties.Resources.ship_red_2_shot;
                            Enemy_1_Buttons_List[i].Enabled = false;
                            var shotedShip = db.Player_2_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                            shotedShip.shipsID = 10;
                            player1Score++;
                            player_1_score.Text = player1Score.ToString();
                        }
                    }
                }
                else if (db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 11)
                {
                    for (int i = 0; i < Enemy_1_Buttons_List.Count; i++)
                    {
                        if (Enemy_1_Buttons_List[i].Name == boardFieldName)
                        {
                            Enemy_1_Buttons_List[i].BackgroundImage = Properties.Resources.ship_red_3_shot;
                            Enemy_1_Buttons_List[i].Enabled = false;
                            var shotedShip = db.Player_2_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                            shotedShip.shipsID = 12;
                            player1Score++;
                            player_1_score.Text = player1Score.ToString();
                        }
                    }
                }
                for (int i = 0; i < Enemy_1_Buttons_List.Count; i++)
                {
                    Enemy_1_Buttons_List[i].Enabled = false;
                }
            }


            db.SaveChanges();
        }


        private void Form1_Load(object sender, EventArgs e)
        {            

        }

        private void txtPlayer_1_score_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void p1_E2_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "E2";
            boardFieldName = "p1_E2";
            isFieldEmpty();
        }

        private void p1_D1_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "D1";
            boardFieldName = "p1_D1";
            isFieldEmpty();
        }

        private void p1_C1_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "C1";
            boardFieldName = "p1_C1";
            isFieldEmpty();
        }

        private void p1_B1_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "B1";
            boardFieldName = "p1_B1";
            isFieldEmpty();
        }

        private void p1_A1_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "A1";
            boardFieldName = "p1_A1";
            isFieldEmpty();

        }

        private void p1_E1_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "E1";
            boardFieldName = "p1_E1";
            isFieldEmpty();
        }

        private void p1_D2_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "D2";
            boardFieldName = "p1_D2";
            isFieldEmpty();
        }

        private void p1_C2_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "C2";
            boardFieldName = "p1_C2";
            isFieldEmpty();
        }

        private void p1_B2_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "B2";
            boardFieldName = "p1_B2";
            isFieldEmpty();
        }

        private void p1_A2_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "A2";
            boardFieldName = "p1_A2";
            isFieldEmpty();
        }

        private void p1_E3_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "E3";
            boardFieldName = "p1_E3";
            isFieldEmpty();
        }

        private void p1_D3_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "D3";
            boardFieldName = "p1_D3";
            isFieldEmpty();
        }

        private void p1_C3_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "C3";
            boardFieldName = "p1_C3";
            isFieldEmpty();
        }

        private void p1_B3_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "B3";
            boardFieldName = "p1_B3";
            isFieldEmpty();
        }

        private void p1_A3_Click(object sender, EventArgs e)
        {            
            boardName = "p1";
            fieldName = "A3";
            boardFieldName = "p1_A3";
            isFieldEmpty();
        }

        private void p1_E4_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "E4";
            boardFieldName = "p1_E4";
            isFieldEmpty();
        }

        private void p1_D4_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "D4";
            boardFieldName = "p1_D4";
            isFieldEmpty();
        }

        private void p1_C4_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "C4";
            boardFieldName = "p1_C4";
            isFieldEmpty();
        }

        private void p1_B4_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "B4";
            boardFieldName = "p1_B4";
            isFieldEmpty();
        }

        private void p1_A4_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "A4";
            boardFieldName = "p1_A4";
            isFieldEmpty();
        }

        private void p1_E5_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "E5";
            boardFieldName = "p1_E5";
            isFieldEmpty();
        }

        private void p1_D5_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "D5";
            boardFieldName = "p1_D5";
            isFieldEmpty();
        }

        private void p1_C5_Click(object sender, EventArgs e)
        {
            boardName = "p1";
            fieldName = "C5";
            boardFieldName = "p1_C5";
            isFieldEmpty();
        }

        private void p1_A5_Click(object sender, EventArgs e)
        {            
            boardName = "p1";
            fieldName = "A5";
            boardFieldName = "p1_A5";
            isFieldEmpty();
        }

        private void startRoundButton_Player_1_Click(object sender, EventArgs e)
        {
            startRoundButton_Player_1.Visible = false;
            finishRoundButtonPlayer_1.Visible = true;
            Player_1_Buttons_List = new List<Button> {p1_A1, p1_B1, p1_C1, p1_D1, p1_E1,
                                                      p1_A2, p1_B2, p1_C2, p1_D2, p1_E2,
                                                      p1_A3, p1_B3, p1_C3, p1_D3, p1_E3,
                                                      p1_A4, p1_B4, p1_C4, p1_D4, p1_E4,
                                                      p1_A5, p1_B5, p1_C5, p1_D5, p1_E5};

            Enemy_1_Buttons_List = new List<Button>  {e1_A1, e1_B1, e1_C1, e1_D1, e1_E1,
                                                      e1_A2, e1_B2, e1_C2, e1_D2, e1_E2,
                                                      e1_A3, e1_B3, e1_C3, e1_D3, e1_E3,
                                                      e1_A4, e1_B4, e1_C4, e1_D4, e1_E4,
                                                      e1_A5, e1_B5, e1_C5, e1_D5, e1_E5};
            for (int i = 0; i < Player_1_Buttons_List.Count; i++)
            {
                Player_1_Buttons_List[i].Visible = true;
                Player_1_Buttons_List[i].Enabled = false;
            }
            for (int i = 0; i < Enemy_1_Buttons_List.Count; i++)
            {                
                Enemy_1_Buttons_List[i].Visible = true;
                Enemy_1_Buttons_List[i].Enabled = true;
            }

        }

        private void pickShip_cannel_Click(object sender, EventArgs e)
        {
            pickShipPanel.Visible = false;
        }

        private void pickPanel_blueShip_Click(object sender, EventArgs e)
        {
            BlueShipDirectionPanel.Visible = true;            
            var obj = new PickingShip();


            if (obj.BlueShipPossibleDirection_Top(fieldName, boardName) == false)
            {
                blueShipPannelDirection_top.Enabled = false;
            }
            else
            {
                blueShipPannelDirection_top.Enabled = true;
            } 
            if (obj.BlueShipPossibleDirection_Right(fieldName, boardName) == false)
            {
                blueShipPannelDirection_right.Enabled = false;
            }
            else
            {
                blueShipPannelDirection_right.Enabled = true;
            }
            if (obj.BlueShipPossibleDirection_Bottom(fieldName, boardName) == false)
            {
                blueShipPannelDirection_bottom.Enabled = false;
            }
            else
            {
                blueShipPannelDirection_bottom.Enabled = true;
            }
            if (obj.BlueShipPossibleDirection_Left(fieldName, boardName) == false)
            {
                blueShipPannelDirection_left.Enabled = false;
            }
            else
            {
                blueShipPannelDirection_left.Enabled = true;
            }


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void blueShipPannelDirection_top_Click(object sender, EventArgs e)
        {
            shipDirection = -5;
            BlueShip_UpdatePlayerBoard();
        }

        private void blueShipPannelDirection_right_Click(object sender, EventArgs e)
        {
            shipDirection = 1;
            BlueShip_UpdatePlayerBoard();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void blueShipPannelDirection_bottom_Click(object sender, EventArgs e)
        {
            shipDirection = 5;
            BlueShip_UpdatePlayerBoard();
        }

        private void blueShipPannelDirection_left_Click(object sender, EventArgs e)
        {
            shipDirection = -1;
            BlueShip_UpdatePlayerBoard();
        }

        private void pickPanel_redShip_Click(object sender, EventArgs e)
        {
            RedShipDirectionPanel.Visible = true;
            var obj = new PickingShip();


            if (obj.RedShipPossibleDirection_Top(fieldName, boardName) == false)
            {
                redShipPannelDirection_top.Enabled = false;
            }
            else
            {
                redShipPannelDirection_top.Enabled = true;
            }
            if (obj.RedShipPossibleDirection_Right(fieldName, boardName) == false)
            {
                redShipPannelDirection_right.Enabled = false;
            }
            else
            {
                redShipPannelDirection_right.Enabled = true;
            }
            if (obj.RedShipPossibleDirection_Bottom(fieldName, boardName) == false)
            {
                redShipPannelDirection_bottom.Enabled = false;
            }
            else
            {
                redShipPannelDirection_bottom.Enabled = true;
            }
            if (obj.RedShipPossibleDirection_Left(fieldName, boardName) == false)
            {
                redShipPannelDirection_left.Enabled = false;
            }
            else
            {
                redShipPannelDirection_left.Enabled = true;
            }
        }

        private void redShipPannelDirection_top_Click(object sender, EventArgs e)
        {
            shipDirection = -5;
            RedShip_UpdatePlayerBoard();
        }

        private void redShipPannelDirection_right_Click(object sender, EventArgs e)
        {
            shipDirection = 1;
            RedShip_UpdatePlayerBoard();
        }

        private void redShipPannelDirection_bottom_Click(object sender, EventArgs e)
        {
            shipDirection = 5;
            RedShip_UpdatePlayerBoard();
        }

        private void redShipPannelDirection_left_Click(object sender, EventArgs e)
        {
            shipDirection = -1;
            RedShip_UpdatePlayerBoard();
        }

        private void finishRoundButtonPlayer_1_Click(object sender, EventArgs e)
        {
            if(player1Score == 10)
            {
                pickShipPanel.Visible = false;
                BlueShipDirectionPanel.Visible = false;
                RedShipDirectionPanel.Visible = false;
                finishRoundButtonPlayer_1.Visible = false;
                finishRoundButtonPlayer_2.Visible = false;
                startRoundButton_Player_1.Visible = false;
                startRoundButton_Player_2.Visible = false;
                finishedShipsRound_Player_2.Visible = false;
                championPanel.Visible = true;
                champion.Text = "Player 1 WIN!";
            }
            else
            {
                player_turn.Text = "Player 2 Turn";
                finishRoundButtonPlayer_1.Visible = false;
                startRoundButton_Player_2.Visible = true;

                Player_1_Buttons_List = new List<Button> {p1_A1, p1_B1, p1_C1, p1_D1, p1_E1,
                                                      p1_A2, p1_B2, p1_C2, p1_D2, p1_E2,
                                                      p1_A3, p1_B3, p1_C3, p1_D3, p1_E3,
                                                      p1_A4, p1_B4, p1_C4, p1_D4, p1_E4,
                                                      p1_A5, p1_B5, p1_C5, p1_D5, p1_E5};

                Enemy_1_Buttons_List = new List<Button>  {e1_A1, e1_B1, e1_C1, e1_D1, e1_E1,
                                                      e1_A2, e1_B2, e1_C2, e1_D2, e1_E2,
                                                      e1_A3, e1_B3, e1_C3, e1_D3, e1_E3,
                                                      e1_A4, e1_B4, e1_C4, e1_D4, e1_E4,
                                                      e1_A5, e1_B5, e1_C5, e1_D5, e1_E5};


                for (int i = 0; i < Player_1_Buttons_List.Count; i++)
                {
                    Player_1_Buttons_List[i].Visible = false;
                }
                for (int i = 0; i < Enemy_1_Buttons_List.Count; i++)
                {
                    Enemy_1_Buttons_List[i].Visible = false;
                }
            }


        }

        private void finishRoundButtonPlayer_2_Click(object sender, EventArgs e)
        {
            if (player2Score == 10)
            {
                pickShipPanel.Visible = false;
                BlueShipDirectionPanel.Visible = false;
                RedShipDirectionPanel.Visible = false;
                finishRoundButtonPlayer_1.Visible = false;
                finishRoundButtonPlayer_2.Visible = false;
                startRoundButton_Player_1.Visible = false;
                startRoundButton_Player_2.Visible = false;
                finishedShipsRound_Player_2.Visible = false;
                championPanel.Visible = true;
                champion.Text = "Player 2 WIN!";
            }
            else
            {
                player_turn.Text = "Player 1 Turn";
                finishRoundButtonPlayer_2.Visible = false;
                startRoundButton_Player_1.Visible = true;

                Player_2_Buttons_List = new List<Button> {p2_A1, p2_B1, p2_C1, p2_D1, p2_E1,
                                                      p2_A2, p2_B2, p2_C2, p2_D2, p2_E2,
                                                      p2_A3, p2_B3, p2_C3, p2_D3, p2_E3,
                                                      p2_A4, p2_B4, p2_C4, p2_D4, p2_E4,
                                                      p2_A5, p2_B5, p2_C5, p2_D5, p2_E5};
                Enemy_2_Buttons_List = new List<Button> {e2_A1, e2_B1, e2_C1, e2_D1, e2_E1,
                                                     e2_A2, e2_B2, e2_C2, e2_D2, e2_E2,
                                                     e2_A3, e2_B3, e2_C3, e2_D3, e2_E3,
                                                     e2_A4, e2_B4, e2_C4, e2_D4, e2_E4,
                                                     e2_A5, e2_B5, e2_C5, e2_D5, e2_E5};

                for (int i = 0; i < Player_2_Buttons_List.Count; i++)
                {
                    Player_2_Buttons_List[i].Visible = false;
                    Player_2_Buttons_List[i].Enabled = false;
                }
                for (int i = 0; i < Enemy_2_Buttons_List.Count; i++)
                {
                    Enemy_2_Buttons_List[i].Visible = false;
                    Enemy_2_Buttons_List[i].Enabled = false;
                }
            }

        }

        private void p2_A1_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "A1";
            boardFieldName = "p2_A1";
            isFieldEmpty();
        }

        private void p2_B1_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "B1";
            boardFieldName = "p2_B1";
            isFieldEmpty();
        }

        private void p2_C1_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "C1";
            boardFieldName = "p2_C1";
            isFieldEmpty();
        }

        private void p2_D1_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "D1";
            boardFieldName = "p2_D1";
            isFieldEmpty();
        }

        private void p2_E1_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "E1";
            boardFieldName = "p2_E1";
            isFieldEmpty();
        }

        private void p2_E2_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "E2";
            boardFieldName = "p2_E2";
            isFieldEmpty();
        }

        private void p2_D2_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "D2";
            boardFieldName = "p2_D2";
            isFieldEmpty();
        }

        private void p2_C2_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "C2";
            boardFieldName = "p2_C2";
            isFieldEmpty();
        }

        private void p2_B2_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "B2";
            boardFieldName = "p2_B2";
            isFieldEmpty();
        }

        private void p2_A2_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "A2";
            boardFieldName = "p2_A2";
            isFieldEmpty();
        }

        private void p2_A3_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "A3";
            boardFieldName = "p2_A3";
            isFieldEmpty();
        }

        private void p2_B3_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "B3";
            boardFieldName = "p2_B3";
            isFieldEmpty();
        }

        private void p2_C3_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "C3";
            boardFieldName = "p2_C3";
            isFieldEmpty();
        }

        private void p2_D3_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "D3";
            boardFieldName = "p2_D3";
            isFieldEmpty();
        }

        private void p2_E3_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "E3";
            boardFieldName = "p2_E3";
            isFieldEmpty();
        }

        private void p2_E4_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "E4";
            boardFieldName = "p2_E4";
            isFieldEmpty();
        }

        private void p2_D4_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "D4";
            boardFieldName = "p2_D4";
            isFieldEmpty();
        }

        private void p2_C4_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "C4";
            boardFieldName = "p2_C4";
            isFieldEmpty();
        }

        private void p2_B4_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "B4";
            boardFieldName = "p2_B4";
            isFieldEmpty();
        }

        private void p2_A4_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "A4";
            boardFieldName = "p2_A4";
            isFieldEmpty();
        }

        private void p2_A5_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "A5";
            boardFieldName = "p2_A5";
            isFieldEmpty();
        }

        private void p2_B5_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "B5";
            boardFieldName = "p2_B5";
            isFieldEmpty();
        }

        private void p2_C5_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "C5";
            boardFieldName = "p2_C5";
            isFieldEmpty();
        }

        private void p2_D5_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "D5";
            boardFieldName = "p2_D5";
            isFieldEmpty();
        }

        private void p2_E5_Click(object sender, EventArgs e)
        {
            boardName = "p2";
            fieldName = "E5";
            boardFieldName = "p2_E5";
            isFieldEmpty();
        }

        private void finishedShipsRound_Player_1_Click(object sender, EventArgs e)
        {
            var db = new BattleshipContext();

            if(db.Player_1_Boards.Where(x => x.shipsID == 1).Count() > 15)
            {

            }
            else
            {
                Player_1_Buttons_List = new List<Button> {p1_A1, p1_B1, p1_C1, p1_D1, p1_E1,
                                                      p1_A2, p1_B2, p1_C2, p1_D2, p1_E2,
                                                      p1_A3, p1_B3, p1_C3, p1_D3, p1_E3,
                                                      p1_A4, p1_B4, p1_C4, p1_D4, p1_E4,
                                                      p1_A5, p1_B5, p1_C5, p1_D5, p1_E5};

                for (int i = 0; i < Player_1_Buttons_List.Count; i++)
                {
                    Player_1_Buttons_List[i].Visible = false;
                }

                player_turn.Text = "Player 2 Turn";
                startShipsRound_Player_2.Visible = true;
                finishedShipsRound_Player_1.Visible = false;
            }

        }

        private void finishedShipsRound_Player_2_Click(object sender, EventArgs e)
        {
            var db = new BattleshipContext();
            if (db.Player_2_Boards.Where(x => x.shipsID == 1).Count() > 15)
            {

            }
            else
            {
                finishedShipsRound_Player_2.Visible = false;
                for (int i = 0; i < Player_1_Buttons_List.Count; i++)
                {
                    Player_1_Buttons_List[i].Visible = false;
                }
                for (int i = 0; i < Player_2_Buttons_List.Count; i++)
                {
                    Player_2_Buttons_List[i].Visible = false;
                }
                for (int i = 0; i < Enemy_1_Buttons_List.Count; i++)
                {
                    Enemy_1_Buttons_List[i].Visible = false;
                }
                for (int i = 0; i < Enemy_2_Buttons_List.Count; i++)
                {
                    Enemy_2_Buttons_List[i].Visible = false;
                }
                player_turn.Text = "Player 1 Turn";
                startRoundButton_Player_1.Visible = true;
            }

        }

        private void startRoundButton_Player_2_Click(object sender, EventArgs e)
        {
            startRoundButton_Player_2.Visible = false;

            var db = new BattleshipContext();
            Player_2_Buttons_List = new List<Button> {p2_A1, p2_B1, p2_C1, p2_D1, p2_E1,
                                                      p2_A2, p2_B2, p2_C2, p2_D2, p2_E2,
                                                      p2_A3, p2_B3, p2_C3, p2_D3, p2_E3,
                                                      p2_A4, p2_B4, p2_C4, p2_D4, p2_E4,
                                                      p2_A5, p2_B5, p2_C5, p2_D5, p2_E5};
            Enemy_2_Buttons_List = new List<Button> {e2_A1, e2_B1, e2_C1, e2_D1, e2_E1,
                                                     e2_A2, e2_B2, e2_C2, e2_D2, e2_E2,
                                                     e2_A3, e2_B3, e2_C3, e2_D3, e2_E3,
                                                     e2_A4, e2_B4, e2_C4, e2_D4, e2_E4,
                                                     e2_A5, e2_B5, e2_C5, e2_D5, e2_E5};

                      
                for (int i = 0; i < Player_2_Buttons_List.Count; i++)
                {
                    Player_2_Buttons_List[i].Visible = true;
                    Player_2_Buttons_List[i].Enabled = false;
                }
                for (int i = 0; i < Enemy_2_Buttons_List.Count; i++)
                {
                    Enemy_2_Buttons_List[i].Visible = true;
                    Enemy_2_Buttons_List[i].Enabled = true;
                }
                finishRoundButtonPlayer_2.Visible = true;

           
        }

        private void e2_E1_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "E1";
            boardFieldName = "e2_E1";
            ShootYourEnemy();
        }

        private void e2_B1_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "B1";
            boardFieldName = "e2_B1";
            ShootYourEnemy();
        }

        private void e2_C1_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "C1";
            boardFieldName = "e2_C1";
            ShootYourEnemy();
        }

        private void e2_D1_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "D1";
            boardFieldName = "e2_D1";
            ShootYourEnemy();
        }

        private void e2_A1_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "A1";
            boardFieldName = "e2_A1";
            ShootYourEnemy();
        }

        private void e2_A2_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "A2";
            boardFieldName = "e2_A2";
            ShootYourEnemy();
        }

        private void e2_B2_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "B2";
            boardFieldName = "e2_B2";
            ShootYourEnemy();
        }

        private void e2_C2_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "C2";
            boardFieldName = "e2_C2";
            ShootYourEnemy();
        }

        private void e2_D2_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "D2";
            boardFieldName = "e2_D2";
            ShootYourEnemy();
        }

        private void e2_E2_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "E2";
            boardFieldName = "e2_E2";
            ShootYourEnemy();
        }

        private void e2_A3_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "A3";
            boardFieldName = "e2_A3";
            ShootYourEnemy();
        }

        private void e2_B3_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "B3";
            boardFieldName = "e2_B3";
            ShootYourEnemy();
        }

        private void e2_C3_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "C3";
            boardFieldName = "e2_C3";
            ShootYourEnemy();
        }

        private void e2_D3_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "D3";
            boardFieldName = "e2_D3";
            ShootYourEnemy();
        }

        private void e2_E3_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "E3";
            boardFieldName = "e2_E3";
            ShootYourEnemy();
        }

        private void e2_A4_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "A4";
            boardFieldName = "e2_A4";
            ShootYourEnemy();
        }

        private void e2_B4_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "B4";
            boardFieldName = "e2_B4";
            ShootYourEnemy();
        }

        private void e2_C4_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "C4";
            boardFieldName = "e2_C4";
            ShootYourEnemy();
        }

        private void e2_D4_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "D4";
            boardFieldName = "e2_D4";
            ShootYourEnemy();
        }

        private void e2_E4_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "E4";
            boardFieldName = "e2_E4";
            ShootYourEnemy();
        }

        private void e2_A5_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "A5";
            boardFieldName = "e2_A5";
            ShootYourEnemy();
        }

        private void e2_B5_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "B5";
            boardFieldName = "e2_B5";
            ShootYourEnemy();
        }

        private void e2_C5_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "C5";
            boardFieldName = "e2_C5";
            ShootYourEnemy();
        }

        private void e2_D5_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "D5";
            boardFieldName = "e2_D5";
            ShootYourEnemy();
        }

        private void e2_E5_Click(object sender, EventArgs e)
        {
            boardName = "e2";
            fieldName = "E5";
            boardFieldName = "e2_E5";
            ShootYourEnemy();
        }

        private void e1_E5_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "E5";
            boardFieldName = "e1_E5";
            ShootYourEnemy();
        }

        private void e1_B1_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "B1";
            boardFieldName = "e1_B1";
            ShootYourEnemy();
        }

        private void e1_C1_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "C1";
            boardFieldName = "e1_C1";
            ShootYourEnemy();
        }

        private void e1_D1_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "D1";
            boardFieldName = "e1_D1";
            ShootYourEnemy();
        }

        private void e1_E1_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "E1";
            boardFieldName = "e1_E1";
            ShootYourEnemy();
        }

        private void e1_A2_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "A2";
            boardFieldName = "e1_A2";
            ShootYourEnemy();
        }

        private void e1_B2_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "B2";
            boardFieldName = "e1_B2";
            ShootYourEnemy();
        }

        private void e1_C2_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "C2";
            boardFieldName = "e1_C2";
            ShootYourEnemy();
        }

        private void e1_D2_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "D2";
            boardFieldName = "e1_D2";
            ShootYourEnemy();
        }

        private void e1_E2_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "E2";
            boardFieldName = "e1_E2";
            ShootYourEnemy();
        }

        private void e1_A3_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "A3";
            boardFieldName = "e1_A3";
            ShootYourEnemy();
        }

        private void e1_B3_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "B3";
            boardFieldName = "e1_B3";
            ShootYourEnemy();
        }

        private void e1_C3_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "C3";
            boardFieldName = "e1_C3";
            ShootYourEnemy();
        }

        private void e1_D3_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "D3";
            boardFieldName = "e1_D3";
            ShootYourEnemy();
        }

        private void e1_E3_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "E3";
            boardFieldName = "e1_E3";
            ShootYourEnemy();
        }

        private void e1_A4_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "A4";
            boardFieldName = "e1_A4";
            ShootYourEnemy();
        }

        private void e1_B4_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "B4";
            boardFieldName = "e1_B4";
            ShootYourEnemy();
        }

        private void e1_C4_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "C4";
            boardFieldName = "e1_C4";
            ShootYourEnemy();
        }

        private void e1_D4_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "D4";
            boardFieldName = "e1_D4";
            ShootYourEnemy();
        }

        private void e1_E4_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "E4";
            boardFieldName = "e1_E4";
            ShootYourEnemy();
        }

        private void e1_A5_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "A5";
            boardFieldName = "e1_A5";
            ShootYourEnemy();
        }

        private void e1_B5_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "B5";
            boardFieldName = "e1_B5";
            ShootYourEnemy();
        }

        private void e1_C5_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "C5";
            boardFieldName = "e1_C5";
            ShootYourEnemy();
        }

        private void e1_D5_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "D5";
            boardFieldName = "e1_D5";
            ShootYourEnemy();
        }

        private void e1_A1_Click(object sender, EventArgs e)
        {
            boardName = "e1";
            fieldName = "A1";
            boardFieldName = "e1_A1";
            ShootYourEnemy();
        }

        private void champion_Click(object sender, EventArgs e)
        {

        }

        private void championPanel_playAgainBtn_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void startShipsRound_Player_2_Click(object sender, EventArgs e)
        {
            startShipsRound_Player_2.Visible = false;
            Player_2_Buttons_List = new List<Button> {p2_A1, p2_B1, p2_C1, p2_D1, p2_E1,
                                                      p2_A2, p2_B2, p2_C2, p2_D2, p2_E2,
                                                      p2_A3, p2_B3, p2_C3, p2_D3, p2_E3,
                                                      p2_A4, p2_B4, p2_C4, p2_D4, p2_E4,
                                                      p2_A5, p2_B5, p2_C5, p2_D5, p2_E5};

            for (int i = 0; i < Player_2_Buttons_List.Count; i++)
                {
                    Player_2_Buttons_List[i].Visible = true;
                    Player_2_Buttons_List[i].Enabled = true;
                }
                finishedShipsRound_Player_2.Visible = true;
            
        }
    }
}
