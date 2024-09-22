namespace Homework2.Calculator;

/// <summary>
/// Library providing statistical calculations such as mean, standard deviation (sample and population),
/// and variance for a list of double values.
/// </summary>
public static class Statistics
{
    private const bool IsPopulation = true;
    private const bool IsSample = false;

    /// <summary>
    /// Computes the sample standard deviation for a list of values.
    /// </summary>
    /// <param name="valuesList">List of double values for which the sample standard deviation is to be computed.</param>
    /// <returns>The sample standard deviation of the values in the list.</returns>
    public static double ComputeSampleStandardDeviation(List<double> valuesList)
    {
        return ComputeStandardDeviation(valuesList, IsSample);
    }

    /// <summary>
    /// Computes the population standard deviation for a list of values.
    /// </summary>
    /// <param name="valuesList">List of double values for which the population standard deviation is to be computed.</param>
    /// <returns>The population standard deviation of the values in the list.</returns>
    public static double ComputePopulationStandardDeviation(List<double> valuesList)
    {
        return ComputeStandardDeviation(valuesList, IsPopulation);
    }

    /// <summary>
    /// Computes the standard deviation for a list of values, either as a sample or population.
    /// </summary>
    /// <param name="valuesList">List of double values for which the standard deviation is to be computed.</param>
    /// <param name="isPopulation">Boolean flag indicating whether the computation is for population (true) or sample (false).</param>
    /// <returns>The standard deviation of the values in the list.</returns>
    /// <exception cref="ArgumentException">Thrown when the values list is null or empty, or when the sample size is less than 2.</exception>
    private static double ComputeStandardDeviation(List<double> valuesList, bool isPopulation)
    {
        if (valuesList == null || valuesList.Count == 0)
            throw new ArgumentException("valuesList parameter cannot be null or empty");

        var mean = ComputeMean(valuesList);
        var squareOfDifferences = ComputeSquareOfDifferences(valuesList, mean);
        var variance = ComputeVariance(squareOfDifferences, valuesList.Count, isPopulation);

        return Math.Sqrt(variance);
    }

    /// <summary>
    /// Computes the mean (average) of a list of values.
    /// </summary>
    /// <param name="valuesList">List of double values for which the mean is to be computed.</param>
    /// <returns>The mean (average) of the values in the list.</returns>
    /// <exception cref="ArgumentException">Thrown when the valuesList parameter is null or empty.</exception>
    public static double ComputeMean(List<double> valuesList)
    {
        if (valuesList == null || valuesList.Count == 0)
            throw new ArgumentException("valuesList parameter cannot be null or empty");

        double sumAccumulator = 0;
        foreach (var value in valuesList)
            sumAccumulator += value;

        return sumAccumulator / valuesList.Count;
    }

    /// <summary>
    /// Computes the sum of the squared differences from the mean for a list of values.
    /// </summary>
    /// <param name="valuesList">List of double values for which the squared differences from the mean are to be computed.</param>
    /// <param name="mean">The mean of the values in the list.</param>
    /// <returns>The sum of the squared differences from the mean for the values in the list.</returns>
    /// <exception cref="ArgumentException">Thrown when the valuesList parameter is null or empty.</exception>
    public static double ComputeSquareOfDifferences(List<double> valuesList, double mean)
    {
        if (valuesList == null || valuesList.Count == 0)
            throw new ArgumentException("valuesList parameter cannot be null or empty");

        double squareAccumulator = 0;
        foreach (var value in valuesList)
        {
            var difference = value - mean;
            var squareOfDifference = difference * difference;
            squareAccumulator += squareOfDifference;
        }

        return squareAccumulator;
    }

    /// <summary>
    /// Computes the variance for a given set of squared differences.
    /// </summary>
    /// <param name="squareOfDifferences">Sum of the squared differences from the mean.</param>
    /// <param name="numValues">Number of values in the dataset.</param>
    /// <param name="isPopulation">Indicates if the dataset represents a population (true) or a sample (false).</param>
    /// <returns>The variance of the dataset.</returns>
    /// <exception cref="ArgumentException">Thrown when sample size is less than 2 or population size is less than 1.</exception>
    public static double ComputeVariance(double squareOfDifferences, int numValues, bool isPopulation)
    {
        if (!isPopulation) numValues -= 1;

        if (numValues < 1)
            throw new ArgumentException(
                "numValues is too low (sample size must be >= 2, population size must be >= 1)");

        return squareOfDifferences / numValues;
    }
}