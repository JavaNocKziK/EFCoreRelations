using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace EFCoreRelations
{
    class Program
    {
        static List<Assembly> assemblies = new List<Assembly>();

        static void Main(string[] args)
        {
            LoadAssemblies();

            bool keepAlive = true;
            while (keepAlive)
            {
                Console.Write("Create new entry for: ");
                string assemblyToLoad = Console.ReadLine();

                if (assemblyToLoad == "quit")
                {
                    keepAlive = false;
                    return;
                }

                Type type = GetAssembly(assemblyToLoad).GetTypes()
                        .Where(s => s.Name.EndsWith("Model"))
                        .SingleOrDefault<Type>();

                using (DatabaseContext context = new DatabaseContext())
                {
                    var dbSetMethodInfo = typeof(DbContext).GetMethod("Set");
                    dynamic dbSet = dbSetMethodInfo.MakeGenericMethod(type).Invoke(context, null);
                    dynamic Rec = Activator.CreateInstance(type);

                    if (assemblyToLoad == "CLPeople")
                    {
                        Console.Write("Area value: ");
                        Rec.AreaId = int.Parse(Console.ReadLine());
                        Console.Write("Place value: ");
                        Rec.PlaceId = int.Parse(Console.ReadLine());
                        Console.Write("Space value: ");
                        Rec.SpaceId = int.Parse(Console.ReadLine());
                    }

                    dbSet.Add(Rec);
                    context.SaveChanges();
                }

                Console.WriteLine("Entry added!");
            }

            Console.WriteLine("Done.");
            Console.Read();
        }

        static void LoadAssemblies()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            List<string> files = Directory
                .EnumerateFiles(baseDirectory)
                .Where(s => s.Replace(baseDirectory, "").StartsWith("CL"))
                .Where(s => s.Replace(baseDirectory, "").EndsWith(".dll"))
                .ToList<string>();
            foreach (string file in files)
            {
                assemblies.Add(AssemblyLoadContext.Default.LoadFromAssemblyPath(file));
            }
        }

        static Assembly GetAssembly(string name)
        {
            return assemblies
                .Where(a => a.FullName.StartsWith(name))
                .SingleOrDefault<Assembly>();
        }
    }
}
