using System;

namespace Lab3_OOP_EVERY_FEATURE_COMBINED
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    sealed class God
    {
        private bool isBenevolent = true;
        private bool isOmniponent = true;
        private bool isOmniscient = true;

        public bool MakeUniverse { get; set; }
    }

    class Human : INaturalTalent
    {
        private int age;
        private int height;
        private string name;

        
        public string JobTitle { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }

        //public int Age { get => age; set => age = value; }
        //public int Height { get => height; set => height = value; }
        //public string Name { get => name; set => name = value; }

        public virtual void HumanIsHungry()
        {
            Console.WriteLine("Human is Hungry");
        }

        public virtual void HumanIsThirsy()
        {
            Console.WriteLine("Human is Thirsty");
        }

        public virtual void HumanIsTired()
        {
            Console.WriteLine("Human is Tired");
        }

        public void Sing()
        {
            Console.WriteLine("Humans can use their voice");
        }
        public void RunFast()
        {
            Console.WriteLine("Humans can Run");
        }

        public void Smart()
        {
            Console.WriteLine("Humans know how to exist");
        }


    }

    class Woman : Human , INaturalTalent
    {
        public override void HumanIsHungry()
        {
            Console.WriteLine("Woman is Hungry");
        }

        public override void HumanIsThirsy()
        {
            Console.WriteLine("Woman is Thirsty");
        }

        public override void HumanIsTired()
        {
            Console.WriteLine("Woman is Tired");
        }


    }

    class Man : Human, INaturalTalent
    {
        public override void HumanIsHungry()
        {
            Console.WriteLine("Man is Hungry");
        }

        public override void HumanIsThirsy()
        {
            Console.WriteLine("Man is Thirsty");
        }

        public override void HumanIsTired()
        {
            Console.WriteLine("Man is Tired");
        }

        public void Sing()
        {
            Console.WriteLine("I cant sing well");
        }
    }



    abstract class Baby : Woman
    {
        public abstract bool IsBorn();
        public abstract string LearnsFromParents();

    }


    interface INaturalTalent
    {
        public void Sing();
        public void RunFast();
        public void Smart();
    }



}
