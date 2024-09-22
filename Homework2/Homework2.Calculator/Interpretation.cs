namespace Homework2.Calculator;

/// <summary>
/// Provides functionality to interpret statistical metrics.
/// </summary>
public class Interpretation
{
    /// <summary>
    /// Interprets the given standard deviation value and categorizes it
    /// into descriptive terms such as "Above Average", "Below Average",
    /// "Exactly Average", or "Near Average".
    /// </summary>
    /// <param name="stdDev">The standard deviation value to interpret.</param>
    /// <returns>A string representing the interpretation of the standard deviation.</returns>
    public static string InterpretStandardDeviation(double stdDev)
    {
        stdDev = Math.Round(stdDev, 1);

        return stdDev switch
        {
            > 2.0 => "Above Average",
            < -2.0 => "Below Average",
            0.0 => "Exactly Average",
            _ => "Near Average"
        };
    }
}