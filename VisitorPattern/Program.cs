using System;

namespace VisitorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var bread = new Necessity(3.50);

            TaxVisitor necessityTaxCalculator = new TaxVisitor(0.06);

            Console.WriteLine($"Bread price before tax: ${bread.Price}");
            Console.ReadLine();

            bread.Accept(necessityTaxCalculator);

            Console.WriteLine($"Bread price with tax: ${bread.Price}");
            Console.ReadLine();

            var bourbon = new Liquor(25.00);
            TaxVisitor liquorTaxCalculator = new TaxVisitor(0.18);

            Console.WriteLine($"Bourbon price before tax: ${bourbon.Price}");
            Console.ReadLine();

            bourbon.Accept(liquorTaxCalculator);

            Console.WriteLine($"Bourbon price with tax: ${bourbon.Price}");
            Console.ReadLine();

            var cigar = new Tobacco(8.50);
            TaxVisitor tobaccoTaxCalculator = new TaxVisitor(0.33);

            Console.WriteLine($"Cigar price before tax: ${cigar.Price}");
            Console.ReadLine();

            cigar.Accept(tobaccoTaxCalculator);

            Console.WriteLine($"Cigar price with tax: ${cigar.Price}");
            Console.ReadLine();

            Console.WriteLine("MEMORIAL DAY SALE! 10% OFF!");
            Console.ReadLine();

            SaleVisitor memorialDaySaleCalculator = new SaleVisitor(0.10);

            bread.Accept(memorialDaySaleCalculator);
            bourbon.Accept(memorialDaySaleCalculator);
            cigar.Accept(memorialDaySaleCalculator);

            Console.WriteLine($"Bread memorial day sale price: ${bread.Price}");
            Console.WriteLine($"Bourbon memorial day sale price: ${bourbon.Price}");
            Console.WriteLine($"Cigar memorial day sale price: ${cigar.Price}");

            Console.ReadLine();
        }

        public interface IVisitor
        {
            void Visit(IVisitable visitable);
        }

        public interface IVisitable
        {
            double Price { get; set; }
            void Accept(IVisitor visitor);
        }

        public class Liquor : IVisitable
        {
            public Liquor(double price)
            {
                Price = price;
            }

            public double Price { get; set; }
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class Necessity : IVisitable
        {
            public Necessity(double price)
            {
                Price = price;
            }

            public double Price { get; set; }
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class Tobacco : IVisitable
        {
            public Tobacco(double price)
            {
                Price = price;
            }

            public double Price { get; set; }
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class TaxVisitor : IVisitor
        {
            public TaxVisitor(double taxRate)
            {
                TaxRate = taxRate;
            }

            public double TaxRate { get; set; }

            public void Visit(IVisitable visitable)
            {
                visitable.Price += (visitable.Price * TaxRate);
            }
        }

        public class SaleVisitor : IVisitor
        {
            public SaleVisitor(double saleRate)
            {
                SaleRate = saleRate;
            }

            public double SaleRate { get; set; }

            public void Visit(IVisitable visitable)
            {
                visitable.Price -= (visitable.Price * SaleRate);
            }
        }
    }
}
