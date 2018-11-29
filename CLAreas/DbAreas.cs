using Microsoft.EntityFrameworkCore;

namespace CLAreas
{
    public class DbAreas
    {
        public DbSet<Area> Areas { get; set; }
    }
}
