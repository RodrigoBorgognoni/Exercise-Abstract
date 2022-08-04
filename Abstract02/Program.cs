using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract02.Entities;
using Abstract02.Entities.Enums;

using Type = Abstract02.Entities.Enums.Type;

namespace Abstract02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write(Environment.NewLine);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax Payer #{i} data: ");
                Console.Write("Individual or Company: ");
                Type type = (Type)Enum.Parse(typeof(Type), Console.ReadLine().ToLower());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual Income: ");
                double income = double.Parse(Console.ReadLine());

                if (type.ToString() == "individual")
                {
                    Console.Write("Health Expenditures: ");
                    double health = double.Parse(Console.ReadLine());
                    list.Add(new Individual(name, income, health));
                }
                else
                {
                    Console.Write("Number of Employees: ");
                    int emp = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, income, emp));
                }
                Console.Write(Environment.NewLine);
            }

            double sum = 0.0;
            Console.WriteLine("TAXES PAID: ");
            foreach (TaxPayer tp in list)
            {
                double tax = tp.Tax();
                Console.WriteLine($"Name: {tp.Name} - Tax: {tp.Tax():C}");
                sum += tax;
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"TOTAL TAXES: {sum:C}");
        }
    }
}
