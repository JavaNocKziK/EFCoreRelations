using Microsoft.EntityFrameworkCore;

namespace CLSpaces
{
    public class DbSpaces
    {
        public DbSet<Space> Spaces { get; set; }
    }
}
