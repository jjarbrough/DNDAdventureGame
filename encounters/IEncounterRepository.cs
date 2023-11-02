using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDAdventureGame.encounters
{
    public interface IEncounterRepository
    {
        public IEnumerable<Encounter> GetEncounters();
    }
}
