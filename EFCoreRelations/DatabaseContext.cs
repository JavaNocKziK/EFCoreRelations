using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Linq;

namespace EFCoreRelations
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            List<Assembly> assemblies = new List<Assembly>();
            List<string> files = Directory
                .EnumerateFiles(baseDirectory)
                .Where(s => s.Replace(baseDirectory, "").StartsWith("CL"))
                .Where(s => s.Replace(baseDirectory, "").EndsWith(".dll"))
                .ToList<string>();
            foreach (string file in files)
            {
                assemblies.Add(AssemblyLoadContext.Default.LoadFromAssemblyPath(file));
            }
            foreach (Assembly assembly in assemblies)
            {
                Type context = assembly.GetTypes()
                    .Where(s => s.Name.EndsWith("Model"))
                    .SingleOrDefault<Type>();
                var method = modelBuilder.GetType().GetMethod("Entity", new Type[] { });
                method = method.MakeGenericMethod(new Type[] { context });
                method.Invoke(modelBuilder, null);
            }
        }
    }
}
