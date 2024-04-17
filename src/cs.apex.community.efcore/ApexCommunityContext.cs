using cs.apex.community.domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs.apex.community.efcore
{
    public class ApexCommunityContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Community> Community { get; set; } 
        public DbSet<Game> Games { get; set; }

        public ApexCommunityContext(DbContextOptions<ApexCommunityContext> options) : base(options) 
        { 
        
        }
    }
}
