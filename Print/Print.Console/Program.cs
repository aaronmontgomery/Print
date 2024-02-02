using Services;

namespace Print.Console
{
    internal class Program
    {
        static void Main()
        {
            IPrintService printService;
            IEnumerable<string> values;
            IList<KeyValuePair<double, string>> substitutions;
            double upperBound;
            
            printService = new PrintService();
            substitutions = new List<KeyValuePair<double, string>>()
            {
                new KeyValuePair<double, string>(3, "Aaron"),
                new KeyValuePair<double, string>(5, "Montgomery")
            };
            
            upperBound = 100;
            values = printService.GetValues(upperBound, substitutions);
            foreach (string value in values)
            {
                System.Console.WriteLine(value);
            }
        }
    }
}
