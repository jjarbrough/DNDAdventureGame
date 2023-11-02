using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame.encounters
{
    internal class DapperEncounterRepository : IEncounterRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperEncounterRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Encounter> GetEncounters()
        {
            return _connection.Query<Encounter>("SELECT * FROM encounter;");
        }
    }
}
