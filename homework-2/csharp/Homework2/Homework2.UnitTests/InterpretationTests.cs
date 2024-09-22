using Homework2.Calculator;

namespace Homework2.UnitTests
{
    [TestFixture]
    public class InterpretationTests
    {
        /// <summary>
        /// Parameterized test of the interpretation of standard deviation values
        /// to ensure they are categorized into the correct descriptive terms such as "Above Average", "Below Average",
        /// "Exactly Average", or "Near Average".
        /// </summary>
        /// <param name="input">The standard deviation value to interpret and test.</param>
        /// <param name="expectedOutput">The expected description category for the standard deviation value.</param>
        [TestCase(3.0, "Above Average")]
        [TestCase(-3.0, "Below Average")]
        [TestCase(0.0, "Exactly Average")]
        [TestCase(1.5, "Near Average")]
        [TestCase(-1.5, "Near Average")]
        [TestCase(2.0, "Near Average")]
        [TestCase(-2.0, "Near Average")]
        public void Interpretation_StandardDeviation_ReturnsInterpretationOfStandardDeviation(double input, string expectedOutput)
        {
            var result = Interpretation.InterpretStandardDeviation(input);
            Assert.That(result, Is.EqualTo(expectedOutput));
        }
    }
}