using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp5
{
    [Serializable]
    public class Aeroflot : ISerializable
    {
        public String Destination { get; set; }
        public int Number { get; set; }
        public int[] Days { get; set; }

        public Aeroflot()
        {
        }

        protected Aeroflot(SerializationInfo info, StreamingContext context)
        {
            Destination = (String) info.GetValue("Destination", typeof(String));
            Number = (int) info.GetValue("Number", typeof(int));
            Days = (int[]) info.GetValue("Days", typeof(int[]));
        }

        public Aeroflot(string destination, int number, int[] days)
        {
            Destination = destination;
            Number = number;
            Days = days;
        }

        public override string ToString()
        {
            return $"{nameof(Destination)}: {Destination}, {nameof(Number)}: {Number}, {nameof(Days)}: {Days}";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("Destination", Destination);
            info.AddValue("Number", Number);
            info.AddValue("Days", Days);
        }

        public static void Write(String path, List<Aeroflot> aeroflots)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, aeroflots);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something goes wrong.. " + ex.Message);
                throw ex;
            }
            finally
            {
                fs.Close();
            }
        }


        public List<Aeroflot> Read(String path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);

            try
            {
                BinaryFormatter bs = new BinaryFormatter();
                return (List<Aeroflot>) bs.Deserialize(fs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something goes wrong.. " + ex.Message);
                throw ex;
            }
            finally
            {
                fs.Close();
            }
        }

        public static List<Aeroflot> SortByDestination(List<Aeroflot> aeroflots)
        {
            return aeroflots.OrderBy(x => x.Destination).ToList();
        }

        public static List<Aeroflot> SortByNumber(List<Aeroflot> aeroflots)
        {
            return aeroflots.OrderBy(x => x.Number).ToList();
        }

        public static List<Aeroflot> FindByDestination(List<Aeroflot> aeroflots, String keyword)
        {
            return aeroflots.FindAll(x => x.Destination.Contains(keyword));
        }
    }
}