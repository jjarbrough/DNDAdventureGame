using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal interface IEnemyRepository
    {
        public IEnumerable<Enemy> GetEnemies();
        public Enemy GetEnemy(string name);
    }
}
