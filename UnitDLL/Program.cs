using LibraryDLL;

namespace UnitDLL
{
    public class Program
    {
        static void Main()
        {
            СheckSumDLL obj = new СheckSumDLL("JHMCM56557C404453");
            Console.WriteLine(obj.ExaminationСheckSum());
        }
    }
}