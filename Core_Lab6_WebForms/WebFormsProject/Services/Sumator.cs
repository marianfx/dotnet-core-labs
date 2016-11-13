using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsProject.Services
{
    public class Sumator
    {
        public List<double> Numbers { get; set; }
        public Sumator(params double[] numbers)
        {
            Numbers = new List<double>(numbers);
        }

        public double GetSum()
        {
            if (Numbers == null)
                throw new Exception("Me has no list of numbers.");
            double sum = 0;
            foreach (double number in Numbers)
            {
                sum += number;
            }
            return sum;
        }
    }
}