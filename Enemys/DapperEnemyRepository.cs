using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame.Enemys
{
    internal class DapperEnemyRepository : IEnemyRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperEnemyRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Enemy> GetEnemies()
        {
            return _connection.Query<Enemy>("SELECT * FROM enemy;");
        }

        public Enemy GetEnemy(string name)
        {
            return _connection.QuerySingle<Enemy>("SELECT * FROM enemy WHERE name = @name", new { name });
        }
    }
}
