using Battleship_v1._0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_v1._0.Function
{
    internal class PickingShip
    {

        //Checking if the field is empty
        public bool PickingShip_FirstStep(string fieldName, string boardName)
        {
            var db = new BattleshipContext();

            if (boardName == "p1")
            {
                if (db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 1)
                {
                    return true;
                }
                else return false;
            }
            else if (boardName == "p2")
            {
                if (db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.shipsID).FirstOrDefault() == 1)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        
        //Checking where blue ship can go
        public bool BlueShipPossibleDirection_Top(string fieldName, string boardName)
        {
            var db = new BattleshipContext();

            if(boardName == "p1")
            {
                var chosenField = db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.player_1_board_ID).FirstOrDefault();
                if (chosenField - 5 > 0)
                {
                    if (db.Player_1_Boards.Where(x => x.player_1_board_ID == chosenField - 5).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;                
            }
            else if (boardName == "p2")
            {
                var chosenField = db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.player_2_board_ID).FirstOrDefault();
                if (chosenField - 5 > 0)
                {
                    if (db.Player_2_Boards.Where(x => x.player_2_board_ID == chosenField - 5).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        public bool BlueShipPossibleDirection_Right(string fieldName, string boardName)
        {
            var db = new BattleshipContext();

            if (boardName == "p1")
            {
                var chosenField = db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.player_1_board_ID).FirstOrDefault();
                if (chosenField + 1 < 26 && chosenField + 1 != 6 && chosenField + 1 != 11 && chosenField + 1 != 16 && chosenField + 1 != 21)
                {
                    if (db.Player_1_Boards.Where(x => x.player_1_board_ID == chosenField + 1).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (boardName == "p2")
            {
                var chosenField = db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.player_2_board_ID).FirstOrDefault();
                if (chosenField + 1 < 26 && chosenField + 1 != 6 && chosenField + 1 != 11 && chosenField + 1 != 16 && chosenField + 1 != 21)
                {
                    if (db.Player_2_Boards.Where(x => x.player_2_board_ID == chosenField + 1).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        public bool BlueShipPossibleDirection_Bottom(string fieldName, string boardName)
        {
            var db = new BattleshipContext();

            if (boardName == "p1")
            {
                var chosenField = db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.player_1_board_ID).FirstOrDefault();
                if (chosenField + 5 < 26)
                {
                    if (db.Player_1_Boards.Where(x => x.player_1_board_ID == chosenField + 5).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (boardName == "p2")
            {
                var chosenField = db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.player_2_board_ID).FirstOrDefault();
                if (chosenField + 5 < 26)
                {
                    if (db.Player_2_Boards.Where(x => x.player_2_board_ID == chosenField + 5).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        public bool BlueShipPossibleDirection_Left(string fieldName, string boardName)
        {
            var db = new BattleshipContext();

            if (boardName == "p1")
            {
                var chosenField = db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.player_1_board_ID).FirstOrDefault();
                if (chosenField - 1 > 0 && chosenField - 1  != 5 && chosenField - 1 != 10 && chosenField - 1 != 15 && chosenField - 1 != 20)
                {
                    if (db.Player_1_Boards.Where(x => x.player_1_board_ID == chosenField - 1).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (boardName == "p2")
            {
                var chosenField = db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.player_2_board_ID).FirstOrDefault();
                if (chosenField - 1 > 0 && chosenField - 1 != 5 && chosenField - 1 != 10 && chosenField - 1 != 15 && chosenField - 1 != 20)
                {
                    if (db.Player_2_Boards.Where(x => x.player_2_board_ID == chosenField - 1).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        
        //Checking where red ship can go
        public bool RedShipPossibleDirection_Top(string fieldName, string boardName)
        {
            var db = new BattleshipContext();

            if (boardName == "p1")
            {
                var chosenField = db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.player_1_board_ID).FirstOrDefault();
                if (chosenField - 10 > 0)
                {
                    if (db.Player_1_Boards.Where(x => x.player_1_board_ID == chosenField - 5).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        if (db.Player_1_Boards.Where(x => x.player_1_board_ID == chosenField - 10).Select(z => z.shipsID).FirstOrDefault() == 1)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else if (boardName == "p2")
            {
                var chosenField = db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.player_2_board_ID).FirstOrDefault();
                if (chosenField - 10 > 0)
                {
                    if (db.Player_2_Boards.Where(x => x.player_2_board_ID == chosenField - 5).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        if (db.Player_2_Boards.Where(x => x.player_2_board_ID == chosenField - 10).Select(z => z.shipsID).FirstOrDefault() == 1)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        public bool RedShipPossibleDirection_Right(string fieldName, string boardName)
        {
            var db = new BattleshipContext();

            if (boardName == "p1")
            {
                var chosenField = db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.player_1_board_ID).FirstOrDefault();
                if (chosenField + 2 < 26 && chosenField + 2 != 6 && chosenField + 2 != 7 && chosenField + 2 != 11 && chosenField + 2 != 12
                     && chosenField + 2 != 16 && chosenField + 2 != 17 && chosenField + 2 != 21 && chosenField + 2 != 22)
                {
                    if (db.Player_1_Boards.Where(x => x.player_1_board_ID == chosenField + 1).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        if (db.Player_1_Boards.Where(x => x.player_1_board_ID == chosenField + 2).Select(z => z.shipsID).FirstOrDefault() == 1)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else if (boardName == "p2")
            {
                var chosenField = db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.player_2_board_ID).FirstOrDefault();
                if (chosenField + 2 < 26 && chosenField + 2 != 6 && chosenField + 2 != 7 && chosenField + 2 != 11 && chosenField + 2 != 12
                     && chosenField + 2 != 16 && chosenField + 2 != 17 && chosenField + 2 != 21 && chosenField + 2 != 22)
                {
                    if (db.Player_2_Boards.Where(x => x.player_2_board_ID == chosenField + 1).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        if (db.Player_2_Boards.Where(x => x.player_2_board_ID == chosenField + 2).Select(z => z.shipsID).FirstOrDefault() == 1)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        public bool RedShipPossibleDirection_Bottom(string fieldName, string boardName)
        {
            var db = new BattleshipContext();

            if (boardName == "p1")
            {
                var chosenField = db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.player_1_board_ID).FirstOrDefault();
                if (chosenField + 10 < 26)
                {
                    if (db.Player_1_Boards.Where(x => x.player_1_board_ID == chosenField + 5).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        if (db.Player_1_Boards.Where(x => x.player_1_board_ID == chosenField + 10).Select(z => z.shipsID).FirstOrDefault() == 1)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else if (boardName == "p2")
            {
                var chosenField = db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.player_2_board_ID).FirstOrDefault();
                if (chosenField + 10 < 26)
                {
                    if (db.Player_2_Boards.Where(x => x.player_2_board_ID == chosenField + 5).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        if (db.Player_2_Boards.Where(x => x.player_2_board_ID == chosenField + 10).Select(z => z.shipsID).FirstOrDefault() == 1)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        public bool RedShipPossibleDirection_Left(string fieldName, string boardName)
        {
            var db = new BattleshipContext();

            if (boardName == "p1")
            {
                var chosenField = db.Player_1_Boards.Where(x => x.name == fieldName).Select(z => z.player_1_board_ID).FirstOrDefault();
                if (chosenField - 2 > 0 && chosenField - 2 != 5 && chosenField - 2 != 4 && chosenField - 2 != 9 && chosenField - 2 != 10
                     && chosenField - 2 != 14 && chosenField - 2 != 15 && chosenField - 2 != 19 && chosenField - 2 != 20)
                {
                    if (db.Player_1_Boards.Where(x => x.player_1_board_ID == chosenField - 1).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        if (db.Player_1_Boards.Where(x => x.player_1_board_ID == chosenField - 2).Select(z => z.shipsID).FirstOrDefault() == 1)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else if (boardName == "p2")
            {
                var chosenField = db.Player_2_Boards.Where(x => x.name == fieldName).Select(z => z.player_2_board_ID).FirstOrDefault();
                if (chosenField - 2 > 0 && chosenField - 2 != 5 && chosenField - 2 != 4 && chosenField - 2 != 9 && chosenField - 2 != 10
                     && chosenField - 2 != 14 && chosenField - 2 != 15 && chosenField - 2 != 19 && chosenField - 2 != 20)
                {
                    if (db.Player_2_Boards.Where(x => x.player_2_board_ID == chosenField - 1).Select(z => z.shipsID).FirstOrDefault() == 1)
                    {
                        if (db.Player_2_Boards.Where(x => x.player_2_board_ID == chosenField - 2).Select(z => z.shipsID).FirstOrDefault() == 1)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }


    }



}

