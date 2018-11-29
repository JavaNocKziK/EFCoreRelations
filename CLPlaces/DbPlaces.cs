using Microsoft.EntityFrameworkCore;

namespace CLPlaces
{
    public class DbPlaces
    {
        public DbSet<Place> Places { get; set; }
    }
}
