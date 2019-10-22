using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird crow = new Bird("Crow", new CommonFlyBehavior(), new NoWalkBehavior());
            Bird penguin = new Bird("Penguin", new FlightlessFlyBehavior(), new CommonWalkBehavior());
            Bird chicken = new Bird("Chicken", new HoverFlyBehavior(), new CommonWalkBehavior());
            Bird eagle = new Bird("Eagle", new CommonFlyBehavior(), new NoWalkBehavior());

            crow.Fly();
            crow.Walk();
            penguin.Fly();
            penguin.Walk();
            chicken.Fly();
            chicken.Walk();
            eagle.Fly();
            eagle.Walk();
        }
    }

    interface IFlyBehavior
    {
        public void Fly();
    }

    interface IWalkBehavior
    {
        public void Walk();
    }

    class CommonFlyBehavior : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("Flies.");
        }
    }

    class FlightlessFlyBehavior : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("Unable to fly.");
        }
    }

    class HoverFlyBehavior : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("Hovers slightly above the ground.");
        }
    }

    class CommonWalkBehavior : IWalkBehavior
    {
        public void Walk()
        {
            Console.WriteLine("Walks.");
        }
    }

    class NoWalkBehavior : IWalkBehavior
    {
        public void Walk()
        {
            Console.WriteLine("Unable to walk.");
        }
    }

    class Bird
    {
        public string Name { get; set; }
        public IFlyBehavior FlyBehavior { get; set; }
        public IWalkBehavior WalkBehavior { get; set; }
        
        public Bird(string name, IFlyBehavior flyBehavior, IWalkBehavior walkBehavior)
        {
            Name = name;
            FlyBehavior = flyBehavior;
            WalkBehavior = walkBehavior;
        }

        public void Fly()
        {
            Console.Write($"{Name}: ");
            FlyBehavior.Fly();
        }

        public void Walk()
        {
            Console.Write($"{Name}: ");
            WalkBehavior.Walk();
        }
    }
}
