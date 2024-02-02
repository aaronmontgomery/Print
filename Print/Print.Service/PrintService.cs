using System.Text;

namespace Services
{
    public class PrintService : IPrintService
    {
        public IEnumerable<string> GetValues(double upperBound, IList<KeyValuePair<double, string>> substitutions)
        {
            StringBuilder stringBuilder;
            bool isPrinted;
            
            stringBuilder = new StringBuilder();
            for (double i = 1; i <= upperBound; i++)
            {
                stringBuilder.Clear();
                isPrinted = false;
                
                try
                {
                    foreach (var substitution in substitutions)
                    {
                        try
                        {
                            if (i % substitution.Key == 0)
                            {
                                stringBuilder.Append(substitution.Value);
                                isPrinted = true;
                            }
                        }

                        catch
                        {

                        }
                    }

                    if (!isPrinted)
                    {
                        stringBuilder.Append(i);
                    }
                }
                
                catch
                {
                    stringBuilder.Append(i);
                }

                yield return stringBuilder.ToString();
            }
        }
    }
}
