using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs.apex.community.domain.Model
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public Community Community { get; set; }
    }
}
