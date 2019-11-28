using System;

namespace Lab12_OOP_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var James = new Child("James");
            foreach (char c in James.Name)
            {
                // James grows by a year for each character in his name
                James.Grow();
            }

        }
    }

    class Child
    {

        // Trivial Event Annual Birthday
         delegate void BirthdayDelegate();
         event BirthdayDelegate HaveABirthday;

        public string Name { get; set; }
        public int Age { get; set; }


        public void HaveAParty()
        {
            // "this" refers to the instance
            this.Age++;
            Console.WriteLine("Celebrating Another Year!!! " + 
            $"Age is now: {this.Age}");
        }

        public Child(string Name)
        {
            this.Name = Name;
            this.Age = 0;
            HaveABirthday += HaveAParty; // Placeholder
        }

        public void Grow()
        {
            HaveABirthday();
        }
    }

}
