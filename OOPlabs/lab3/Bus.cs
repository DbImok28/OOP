using System;

namespace lab3
{
    public class Bus
    {
        static Bus()
        {
            FirstBusNumber = 1;
        }
        public Bus()
        {
            ID = GetHashCode();
            Count++;
        }
        public Bus(string name, int number, DateTime time, int numberOfGeneral = 40, int numberOfCompartment = 20, int numberOfReservedSeat = 20, int numberOfLuxury = 10)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }
            Name = name;        
            Number = number;
            Time = time;
            NumberOfGeneral = numberOfGeneral;
            NumberOfCompartment = numberOfCompartment;
            NumberOfReservedSeat = numberOfReservedSeat;
            NumberOfLuxury = numberOfLuxury;

            ID = GetHashCode();
            Count++;
        }
        private Bus(string name, int number, int numberOfGeneral = 40, int numberOfCompartment = 20, int numberOfReservedSeat = 20, int numberOfLuxury = 10)
            : this(name, number, DateTime.Now)
        {
            
        }
        ~Bus()
        {
            Count--;
        }
        public Bus GetBusNow()
        {
            return new Bus(Name, Number);
        }
        public bool Start(ref DateTime endTime)
        {
            endTime = Time.AddMinutes(30);
            return true;
        }
        public bool StartOut(out DateTime endTime)
        {
            endTime = Time.AddMinutes(30);
            return true;
        }
        public override string ToString()
        {
            return $"Name = {Name}, Number = {Number}.";
        }
        public override int GetHashCode()
        {
            return Number;
        }

        public override bool Equals(object obj)
        {
            if (obj is Bus)
            {
                Bus bus = (Bus)obj;
                return (bus.Name == Name && bus.Number == Number);
            }
            return false;
        }

        public string Name { get; }
        public int Number { get; private set; }
        public DateTime Time { get; }
        public int NumberOfGeneral { get; }
        public int NumberOfCompartment { get; }
        public int NumberOfReservedSeat { get; }
        public int NumberOfLuxury { get; }
        public static int FirstBusNumber { get; private set; }

        public readonly int ID;
        public const int MaxNumber = 100;
        public static int Count = 0;
    }
}