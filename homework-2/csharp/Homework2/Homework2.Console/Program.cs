using Homework2.Calculator;

namespace Homework2.Console;

internal static class Program
{
    private static void Main(string[] args)
    {
        var sampleValuesList = new List<double> { 9, 6, 8, 5, 7 };
        var sampleStdDev = Statistics.ComputeSampleStandardDeviation(sampleValuesList);
        var sampleStdDevInterpretation = Interpretation.InterpretStandardDeviation(sampleStdDev);
        System.Console.WriteLine($"Sample StdDev = {sampleStdDev} ({sampleStdDevInterpretation})");
        // Writes "Sample StdDev=1.5811388300841898 (Near Average)"

        var populationValuesList = new List<double>
        {
            9, 2, 5, 4, 12, 7, 8, 11, 9, 3, 7, 4, 12, 5, 4, 10, 9, 6, 9, 4
        };
        var popStdDev = Statistics.ComputePopulationStandardDeviation(populationValuesList);
        var popStdDevInterpretation = Interpretation.InterpretStandardDeviation(popStdDev);
        System.Console.WriteLine($"Population StdDev = {popStdDev} ({popStdDevInterpretation})");
        // Writes "Population StdDev=2.9832867780352594 (Above Average)"
    }
}