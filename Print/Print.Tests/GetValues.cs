using Services;

namespace Print.Tests
{
    public class GetValues
    {
        private IPrintService _printService;
        private IEnumerable<string>? _expectedValues;
        private IEnumerable<string>? _actualvalues;
        private IList<KeyValuePair<double, string>>? _substitutions;
        private double _upperBound;
        
        [SetUp]
        public void Setup()
        {
            _printService = new PrintService();
        }

        [Test]
        public void Print_GetValues_AreEquivalent()
        {
            _expectedValues = new List<string>()
            {
                "1",
                "2",
                "Aaron",
                "4",
                "Montgomery"
            };

            _printService = new PrintService();
            
            _substitutions = new List<KeyValuePair<double, string>>()
            {
                new KeyValuePair<double, string>(3, "Aaron"),
                new KeyValuePair<double, string>(5, "Montgomery")
            };
            
            _upperBound = 5;
            
            _actualvalues = _printService.GetValues(_upperBound, _substitutions);
            
            CollectionAssert.AreEquivalent(_expectedValues, _actualvalues);
        }

        [Test]
        public void Print_GetValues_Count()
        {
            object minValue = byte.MinValue;
            object maxValue = byte.MaxValue;
            double actualCount;

            _printService = new PrintService();
            _substitutions = Array.Empty<KeyValuePair<double, string>>();

            actualCount = Convert.ToDouble(minValue);
            _upperBound = Convert.ToDouble(maxValue);
            foreach (string value in _printService.GetValues(_upperBound, _substitutions))
            {
                actualCount++;
            }

            Assert.That(actualCount, Is.EqualTo(maxValue));
        }
    }
}
