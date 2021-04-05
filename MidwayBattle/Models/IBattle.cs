using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidwayBattle.Models;

namespace MidwayBattle.Models
{
    public interface IBattle
    {
        Weapon CurrentWeapon { get; set; }

        BattleModeName BattleMode { get; set; }

        // return hit point values for each battle mode
        int Attack();
        int Defend();
        int Retreat();
    }
}
