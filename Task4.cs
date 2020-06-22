using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace ConsoleApp5
{
    public class Task4
    {
        private delegate void Printable();

        private Dictionary<String, String> menu = new Dictionary<string, string>();
        private Dictionary<String, Printable> menuMethods = new Dictionary<string, Printable>();
        private List<Aeroflot> _aeroflots;
        
        public Task4()
        {
            menu.Add("1", "read from file");
            menu.Add("2", "sort by destination");
            menu.Add("3", "sort by number");
            menu.Add("4", "find by destination");

            menuMethods.Add("1", ReadFromFile);
            menuMethods.Add("2", SortByDestination);
            menuMethods.Add("3", SortByNumber);
            menuMethods.Add("4", FindByDestination);
        }

        public void show()
        {
            String keyMenu;
            do
            {
                outputMenu();
                Console.WriteLine("Please, select menu point.");
                keyMenu = Console.ReadLine();
                try
                {
                    menuMethods[keyMenu]();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input" + e.Message);
                }
            } while (!keyMenu.Equals("Q"));
        }

        private static void PrintFlot(List<Aeroflot> aeroflots)
        {
            aeroflots.ForEach(x => Console.WriteLine(x));
        }

        private void ReadFromFile()
        {
            Console.Write("Input file path: ");

            String path = Console.ReadLine();

            Stream stream = File.OpenRead(path);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                _aeroflots =(List<Aeroflot>) bf.Deserialize(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            PrintFlot(_aeroflots);
        }

        private void SortByDestination()
        {
           _aeroflots = Aeroflot.SortByDestination(_aeroflots);

            PrintFlot(_aeroflots);
        }

        private void SortByNumber()
        {
            _aeroflots = Aeroflot.SortByNumber(_aeroflots);

            PrintFlot(_aeroflots);
        }

        private void FindByDestination()
        {
            Console.Write("Input key:");

            String key = Console.ReadLine();

            PrintFlot(Aeroflot.FindByDestination(_aeroflots, key));
        }


        private void outputMenu()
        {
            Console.WriteLine("\nMenu:");

            menu.ToList()
                .ForEach(x => Console.WriteLine(x.Key + " - " + x.Value));
        }
    }
}