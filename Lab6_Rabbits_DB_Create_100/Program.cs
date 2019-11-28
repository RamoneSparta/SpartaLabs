using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;
using System.Linq;




namespace Lab6_Rabbits_DB_Create_100
{
    class Program
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();
        public static List<string> rabbitNames = new List<string>
        {
            "Thumper", "Oreo", "Bun Bun", "Cocoa", "Daisy", "Bunny", "Cinnamon", "Snowball", "Bugs", "Marshmallow", "Midnight", "Angel"
        };

        static void Main(string[] args)
        {


            using (var db = new RabbitDBContext())
            {
                AddRabbits();
                listRabbits();
                //PrintRabbits(db);
            }

            
        }

        #region My Version CRUD

        #region CRUD Class
        static void CRUD ()
        {
            PopulateList();
            addRabbits();
            listRabbits();
            updateRabbits(1, "Bugs Bunny", 710);
            listRabbits();
            deleteRabbits(1);
            listRabbits();
        }
        #endregion

        #region PopulateList
        static void PopulateList()
        {
            var rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                rabbits.Add(new Rabbit { RabbitName = rabbitNames[rand.Next(0, rabbitNames.Count)], RabbitAge = rand.Next(1, 1001) });
            }
        }
        #endregion

        #region addRabbits
        static void addRabbits ()
        {
            using (var db = new RabbitDBContext())
            {
                foreach (Rabbit r in rabbits)
                {
                    db.Rabbits.Add(r);
                    db.SaveChanges();
                }

                
            }
        }
        #endregion

        #region updateRabbits

        static void updateRabbits (int id, string name, int age)
        {
            using (var db = new RabbitDBContext())
            {
                rabbits = db.Rabbits.ToList();
                foreach (Rabbit r in rabbits)
                {
                    if (r.RabbitID == id)
                    {
                        r.RabbitName = name;
                        r.RabbitAge = age;
                    }
                }
                db.SaveChanges();
            }
        }

        #endregion

        #region deleteRabbits
        static void deleteRabbits(int id) 
        {
            using (var db = new RabbitDBContext())
            {
                rabbits = db.Rabbits.ToList();
                rabbits.RemoveAt(id);
                db.SaveChanges();
            }
        }
        #endregion

        #region PrintRabbits
        static void PrintRabbits(RabbitDBContext db)
        {
            foreach (var rabbit in db.Rabbits)
            {
                Console.WriteLine($"Rabbit {rabbit.RabbitID} is called {rabbit.RabbitName} and is {rabbit.RabbitAge} years old");
            }
        }
        #endregion

        #region listRabbits
        static void listRabbits()
        {
            using (var db = new RabbitDBContext())
            {
                rabbits = db.Rabbits.ToList();
            }
            rabbits.ForEach(r => Console.WriteLine($"{r.RabbitID, - 15} {r.RabbitName, - 15} {r.RabbitAge, - 10}"));
  
        }

        #endregion

        #endregion

        static void AddRabbits()
        {
            using (var db = new RabbitDBContext())
            {
                for (int i = 0; i < 100; i++)
                {
                    IncrementAge(db, i);
                    Breeding(db);
                    if (i<10)
                    {
                            db.Rabbits.Add(new Rabbit("Rabbit 0" + i, 0));
                            db.SaveChanges();

                    }
                    else
                    {

                            db.Rabbits.Add(new Rabbit("Rabbit " + i, 0));
                            db.SaveChanges();

                    }
                    
                }
                

            }

        }

        static void IncrementAge (RabbitDBContext db,int i)
        {

                rabbits = db.Rabbits.ToList();
                foreach (var r in rabbits)
                {
                    r.RabbitAge++;
                    db.Rabbits.Update(r);
                    for (int k = 0; k < i; k++)
                    {
                    if (i < 10)
                    {
                        db.Rabbits.Add(new Rabbit("Rabbit 0" + i + " version " + k, 0));
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Rabbits.Add(new Rabbit("Rabbit " + i + " version " + k, 0));
                        db.SaveChanges();
                    }
                    }
                }
               
                db.SaveChanges();
            
        }

        static void Breeding(RabbitDBContext db)
        {

            //rabbits = db.Rabbits.ToList();
            foreach (var r in rabbits)
            {
                r.RabbitAge++;
                db.Rabbits.Update(r);
            }
        }


    }

    #region Rabbit
    class Rabbit
    {
        public Rabbit()
        {

        }
        public Rabbit(int RabbitID,string RabbitName, int RabbitAge)
        {
            this.RabbitID = RabbitID;
            this.RabbitName = RabbitName;
            this.RabbitAge = RabbitAge;
        }

        public Rabbit( string RabbitName, int RabbitAge)
        {
            this.RabbitName = RabbitName;
            this.RabbitAge = RabbitAge;
        }

        public int RabbitID { get; set; }
        public string RabbitName { get; set; }
        public int RabbitAge { get; set; }


    }
    #endregion


    #region RabbitDBContext : DbContext
    // Connect to database
    class RabbitDBContext : DbContext
    {
        // Set table

        public DbSet<Rabbit> Rabbits { get; set; }

        // Method to connect ot database

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RabbitsDB;";
            builder.UseSqlServer(connectionString);
        }
    }

    #endregion




}
