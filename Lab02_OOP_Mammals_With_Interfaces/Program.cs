using System;

namespace Lab02_OOP_Mammals_With_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class Mammal
    {
        bool IsWarmBlooded = true;
        int Weight { get; set; }
        int Height { get; set; }
        int Length { get; set; }

    }

    class Cat : Mammal, IUseSmell,IUseVision
    {
        public virtual void Roar() 
        {
            Console.WriteLine("Cat is roaring cutely");
        }

        public void SeeMyPrey()
        {

        }

        public void SmellMyPrey()
        {

        }
    }

    class Lion : Cat
    {
        public override void Roar()
        {
            Console.WriteLine("Lion is roaring");
        }

        public void SeeMyPrey()
        {
            Console.WriteLine("Lion is staring hungily");
        }

        public void SmellMyPrey()
        {
            Console.WriteLine("The Lion can smell fresh meat");
        }
    }

    class Tiger : Cat
    {
        public override void Roar()
        {
            Console.WriteLine("Tiger is roaring");   
        }

        public void SeeMyPrey()
        {
            Console.WriteLine("Tiger is staring loningly");
        }

        public void SmellMyPrey()
        {
            Console.WriteLine("The Tiger can also smell");
        }
    }
}
