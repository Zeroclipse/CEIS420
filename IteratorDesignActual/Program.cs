

using System.Collections;
using System.Xml.Linq;

internal class Program
{
    public static List<SalesPerson> salesPeople = new List<SalesPerson>();

    private static void Main(string[] args)
    {
        string input;
        string breakout;
        //endless looping code
        while (true)
        {
            //Code to get input from user, comment out and just put the method later
            //Comment out later
            Console.Write("Is this a test (Y or N): ");
            input = Console.ReadLine();
            Console.WriteLine();

            if (input.ToUpper() == "Y")
            {
                salesPeople = TestInput();
            }
            else if (input.ToUpper() == "N") 
            {
                salesPeople = ActualInput();
            }

            else
            {
                Console.WriteLine("Sorry, that is not an option. ");
            }

            CreateReport();




            //End code
            Console.Write("Do you wish to continue? (Y or N): ");
            breakout = Console.ReadLine();
            if (breakout.ToUpper() == "Y")
            {
                Console.WriteLine();
            }
            else
            {
                break;
            }

        }
    }

    public static List<SalesPerson> TestInput()
    {
        //Salespeople array to take out
        List<SalesPerson> people = new List<SalesPerson>();

        List<double> sales1 = new List<double>();
        string name1 = "Cody";
        string title1 = "Manager";
        sales1.Add(500);
        sales1.Add(450);
        sales1.Add(300);
        sales1.Add(200);
        SalesPerson person1 = new SalesPerson(name1, title1, sales1);
        people.Add(person1);

        List<double> sales2 = new List<double>();
        string name2 = "Luke";
        string title2 = "Associate";
        sales2.Add(150);
        sales2.Add(250);
        sales2.Add(800);
        SalesPerson person2 = new SalesPerson(name2, title2, sales2);
        people.Add(person2);

        List<double> sales3 = new List<double>();
        string name3 = "Leia";
        string title3 = "Assistant";
        sales3.Add(300);
        sales3.Add(800);
        sales3.Add(200);
        sales3.Add(150);
        SalesPerson person3 = new SalesPerson(name3, title3, sales3);
        people.Add(person3);

        return people;
    }

    public static List<SalesPerson> ActualInput()
    {
        //Salespeople array to take out
        List<SalesPerson> people = new List<SalesPerson>();

        //Endless loop for people
        int breakout;
        Console.Write("How many people do you want to enter sales info for? ");
        breakout = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < breakout; i++)
        {
            List<double> sales = new List<double>();

            Console.Write("Please enter sales person name: ");
            string name = Console.ReadLine();
            Console.Write("Please enter sales person title: ");
            string title = Console.ReadLine();
            Console.Write("How many sales values will you enter for this sales person? ");
            int salesValueCount = Convert.ToInt32(Console.ReadLine());

            for (int j = 0; j < salesValueCount; j++)
            {
                Console.Write("Please enter sales figure for " + name + ": ");
                int sale = Convert.ToInt32(Console.ReadLine());
                sales.Add(sale);
            }
            Console.WriteLine();

            SalesPerson person = new SalesPerson(name, title, sales);
            people.Add(person);
        }
        return people;

    }

    public static IEnumerable<SalesPerson> IterPerson()
    {
        foreach (var person in salesPeople)
        {
            yield return person;
        }
    }
    public static void CreateReport()
    {
        double companyTotal = 0.0;

        IEnumerable<SalesPerson> employees = IterPerson();
        foreach (SalesPerson person in employees)
        {
            double total = 0.0;
            double min = 9999999.9;
            double max = 0.0;
            double avg = 0.0;
            int count = 0;

            IEnumerable<double> sales = person.IterSales();
            foreach (double item in sales)
            {
                total += item;
                if (item < min)
                {
                    min = item;
                }
                if (item > max)
                {
                    max = item;
                }
                count++;
            }
            avg = total / count;
            companyTotal += total;

            Console.WriteLine("Sales Person: " + person.Name);
            Console.WriteLine("Total Sales: " + total.ToString("C"));
            Console.WriteLine("Min Sales: " + min.ToString("C"));
            Console.WriteLine("Max Sales: " + max.ToString("C"));
            Console.WriteLine("Average Sales: " + avg.ToString("C"));
            Console.WriteLine("---------------------------");
            Console.WriteLine();
        }
        Console.WriteLine("Company Total Sales: " + companyTotal.ToString("C"));
    }
}