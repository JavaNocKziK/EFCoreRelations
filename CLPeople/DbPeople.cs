using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLPeople
{
    public class DbPeople
    {
        public DbSet<Person> People { get; set; }
    }
}
