using System;

namespace Business
{
    public class Product
    {
        public Product(string name, string description, DateTime startDate, double price, int vat)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = DateTime.MinValue;
            Price = price;
            Vat = vat;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public double Price { get; private set; }

        public int Vat { get; private set; }


        public bool IsValid()
        {
            return EndDate.Subtract(StartDate).Seconds <= 0;
        }

        public double ComputeVat()
        {
            return Price*Vat/100;
        }

        public void SetValability(DateTime endDate)
        {
            if (endDate < StartDate)
            {
                throw new ArgumentException("EndDate should be greater then StartDate");
            }

            EndDate = endDate;
        }
    }
}
