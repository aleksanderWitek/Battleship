﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_v1._0.Model
{
    internal class Enemy_2_Boards
    {
        [Key]
        public int enemy_2_board_ID { get; set; }

        public virtual List<Player_2_Boards> ListPlayer_2_Boards { get; set; }

        public int shipsID { get; set; }
        [ForeignKey(nameof(shipsID))]
        public virtual Ships virtual_shipsID { get; set; }

        public byte[] field { get; set; }

        public string name { get; set; }
    }
}
