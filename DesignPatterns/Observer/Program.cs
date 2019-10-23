using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Thermometer thermometer = new Thermometer();
            ThermometerDisplay display1 = new ThermometerDisplay(1, thermometer);
            ThermometerDisplay display2 = new ThermometerDisplay(2, thermometer);
            ThermometerDisplay display3 = new ThermometerDisplay(3, thermometer);
            thermometer.AddObserver(display1);
            thermometer.AddObserver(display2);
            thermometer.AddObserver(display3);

            thermometer.ReadTemperature();
            thermometer.RemoveObserver(display1);
            thermometer.ReadTemperature();
            thermometer.AddObserver(display1);

            thermometer.ReadTemperature();
            thermometer.ReadTemperature();
            thermometer.ReadTemperature();
        }
    }

    interface IObservable
    {
        public void AddObserver(IObserver observer);
        public void RemoveObserver(IObserver observer);
        public void Notify();
    }

    interface IObserver
    {
        public void Update();
    }

    class Thermometer : IObservable
    {
        private int temperature;
        public int Temperature { get { return this.temperature; } 
                                 set { this.temperature = value; Notify(); } }
        private List<IObserver> observers = new List<IObserver>();
        
        public Thermometer()
        {
            Temperature = 0;
        }

        public void ReadTemperature()
        {
            Random random = new Random();
            Temperature = random.Next(-32, 131);
        }

        public void AddObserver(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver currentObserver in observers)
            {
                currentObserver.Update();
            }
        }
    }

    class ThermometerDisplay : IObserver
    {
        private readonly int ID;
        public Thermometer Subject { get; set; }

        public ThermometerDisplay(int id)
        {
            ID = id;
        }

        public ThermometerDisplay(int id, Thermometer subject)
        {
            ID = id;
            Subject = subject;
        }

        public void Update()
        {
            Console.Write($"Display {ID}: ");
            Console.WriteLine("Thermometer reads {0} F.", Subject.Temperature);
        }
    }
}
