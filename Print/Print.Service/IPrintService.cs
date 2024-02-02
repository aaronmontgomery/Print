namespace Services
{
    public interface IPrintService
    {
        IEnumerable<string> GetValues(double upperBound, IList<KeyValuePair<double, string>> substitutions);
    }
}
