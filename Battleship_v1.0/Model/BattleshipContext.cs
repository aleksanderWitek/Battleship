using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_v1._0.Model
{
    internal class BattleshipContext : DbContext
    {
        public BattleshipContext() : base("Db_Battleship") { }


        public virtual DbSet<Player_1_Boards> Player_1_Boards { get; set; }
        public virtual DbSet<Player_2_Boards> Player_2_Boards { get; set; }
        public virtual DbSet<Enemy_1_Boards> Enemy_1_Boards { get; set; }
        public virtual DbSet<Enemy_2_Boards> Enemy_2_Boards { get; set; }
        public virtual DbSet<Ships> Ships { get; set; }
    }
}
