using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_v1._0.Model
{
    internal class Ships
    {
        [Key]
        public int shipsID { get; set; }

        public virtual List<Player_1_Boards> ListPlayer_1_Boards { get; set; }
        public virtual List<Player_2_Boards> ListPlayer_2_Boards { get; set;}
        public virtual List<Enemy_1_Boards> ListEnemy_1_Boards { get; set; }
        public virtual List<Enemy_2_Boards> ListEnemy_2_Boards { get; set; }


        public string name { get; set; }
        public byte[] ship { get; set; }
    }
}
