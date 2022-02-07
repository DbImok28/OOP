using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Calculator
    {
        public void SetNextNumber(double num)
        {
            Number *= 10;
            if (!Double.IsNaN(Number) && !Double.IsInfinity(Number) && ((double)Convert.ToInt32(Number)) == Number)
            {
                if (Math.Abs(Number) == Number)
                {
                    Number += num;
                }
                else
                {
                    Number -= num;
                }
            }
            else
            {
                Number = num;
            }
        }
        public void SaveNumber()
        {
            SavedNumber = Number;
        }
        public void LoadNumber()
        {
            Number = SavedNumber;
        }
        public void Clear()
        {
            Number = 0;
        }
        public void Sin()
        {
            Number = Math.Sin(Number);
        }
        public void Cos()
        {
            Number = Math.Cos(Number);
        }
        public void Tg()
        {
            Number = Math.Tan(Number);

        }
        public void Sqrt2()
        {
            Number = Math.Sqrt(Number);

        }
        public void Sqrt3()
        {
            Number = Math.Pow(Number,1.0/3.0);
        }
        public void Pow()
        {
            Number = Math.Pow(Number,2);
        }
        public void Negate()
        {
            Number = -Number;
        }
        public double Number { get; private set; }
        private double SavedNumber { get; set; }
    }
}
