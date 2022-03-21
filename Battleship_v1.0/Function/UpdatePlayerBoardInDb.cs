using Battleship_v1._0.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Battleship_v1._0.Function
{
    internal static class UpdatePlayerBoardInDb
    {
        public static void PutBlueShipOnTheBoardInDb(string fieldName,string boardName, int direction)
        {            
            var db = new BattleshipContext();
            if(boardName == "p1")
            {
                var fieldNumberOne = db.Player_1_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                var fieldNumberTwo = db.Player_1_Boards.Where(z => z.player_1_board_ID == fieldNumberOne.player_1_board_ID + (direction)).FirstOrDefault();
                fieldNumberOne.shipsID = 3;
                fieldNumberTwo.shipsID = 5;
                db.SaveChanges();
            }
            else if (boardName == "p2")
            {
                var fieldNumberOne = db.Player_2_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                var fieldNumberTwo = db.Player_2_Boards.Where(z => z.player_2_board_ID == fieldNumberOne.player_2_board_ID + (direction)).FirstOrDefault();
                fieldNumberOne.shipsID = 3;
                fieldNumberTwo.shipsID = 5;
                db.SaveChanges();
            }
        }

        public static void PutRedShipOnTheBoardInDb(string fieldName,string boardName, int direction)
        {
            var db = new BattleshipContext();
            if(boardName == "p1")
            {
                var fieldNumberOne = db.Player_1_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                var fieldNumberTwo = db.Player_1_Boards.Where(z => z.player_1_board_ID == fieldNumberOne.player_1_board_ID + (direction)).FirstOrDefault();
                var fieldNumberThree = db.Player_1_Boards.Where(z => z.player_1_board_ID == fieldNumberOne.player_1_board_ID + (2 * direction)).FirstOrDefault();
                fieldNumberOne.shipsID = 7;
                fieldNumberTwo.shipsID = 9;
                fieldNumberThree.shipsID = 11;
                db.SaveChanges();
            }
            else if (boardName == "p2")
            {
                var fieldNumberOne = db.Player_2_Boards.Where(x => x.name == fieldName).FirstOrDefault();
                var fieldNumberTwo = db.Player_2_Boards.Where(z => z.player_2_board_ID == fieldNumberOne.player_2_board_ID + (direction)).FirstOrDefault();
                var fieldNumberThree = db.Player_2_Boards.Where(z => z.player_2_board_ID == fieldNumberOne.player_2_board_ID + (2 * direction)).FirstOrDefault();
                fieldNumberOne.shipsID = 7;
                fieldNumberTwo.shipsID = 9;
                fieldNumberThree.shipsID = 11;
                db.SaveChanges();
            }
        }
    }
}
