using Homework2.Calculator;

namespace Homework2.UnitTests;

public class StatisticsTests
{
    /// <summary>
    ///     Tests that ComputeSampleStandardDeviation correctly calculates the sample
    ///     standard deviation for a list of multiple values.
    ///     Ensures that the method processes a standard set of input values accurately and returns
    ///     the expected standard deviation within the accepted precision threshold.
    /// </summary>
    [Test]
    public void Statistics_MultipleValues_ComputeSampleStdDev()
    {
        //arrange
        var sampleValuesList = new List<double> { 9, 6, 8, 5, 7 };

        //act
        var sampleStdDev = Statistics.ComputeSampleStandardDeviation(sampleValuesList);

        //assert
        Assert.That(sampleStdDev,
            Is.EqualTo(1.5811388300841898)
                .Within(1e-10));
    }

    /// <summary>
    ///     Tests that ComputeSampleStandardDeviation throws an ArgumentException
    ///     when provided with an empty list of values.
    ///     Ensures that the method correctly handles invalid input by throwing the
    ///     appropriate exception with the expected error message.
    /// </summary>
    [Test]
    public void Statistics_NoValues_ErrorInComputeSampleStdDev()
    {
        //arrange
        var emptyValuesList = new List<double>();

        //act + assert
        //write assertion that calculator threw
        Assert.That(() => Statistics.ComputeSampleStandardDeviation(emptyValuesList),
            Throws.ArgumentException
                .With.Message.EqualTo("valuesList parameter cannot be null or empty"));
    }

    /// <summary>
    ///     Tests that ComputePopulationStandardDeviation correctly calculates the population
    ///     standard deviation for a list of multiple values.
    ///     Ensures that the method processes a standard set of input values accurately and returns
    ///     the expected standard deviation within the accepted precision threshold.
    /// </summary>
    [Test]
    public void Statistics_MultipleValues_ComputePopulationStdDev()
    {
        //arrange
        var populationValuesList = new List<double>
        {
            9, 2, 5, 4, 12, 7, 8, 11, 9, 3, 7, 4, 12, 5, 4, 10, 9, 6, 9, 4
        };

        //act
        var sampleStdDev = Statistics.ComputePopulationStandardDeviation(populationValuesList);

        //assert
        Assert.That(sampleStdDev,
            Is.EqualTo(2.9832867780352594)
                .Within(1e-10));
    }

    /// <summary>
    ///     Tests that ComputePopulationStandardDeviation method throws an ArgumentException
    ///     when called with an empty list.
    ///     Ensures that the method correctly handles cases where the input list is
    ///     insufficient to compute a population standard deviation.
    /// </summary>
    [Test]
    public void Statistics_NoValues_ErrorInComputePopulationStdDev()
    {
        //arrange
        var emptyValuesList = new List<double>();

        //act + assert
        //write assertion that calculator threw
        Assert.That(() => Statistics.ComputePopulationStandardDeviation(emptyValuesList),
            Throws.ArgumentException
                .With.Message.EqualTo("valuesList parameter cannot be null or empty"));
    }

    /// <summary>
    ///     Tests that ComputeVariance method throws an ArgumentException when called with
    ///     a single value (too low values) for sample variance.
    ///     Ensures that the method correctly handles cases where the number
    ///     of values is insufficient to compute a sample variance.
    /// </summary>
    //[Ignore("Coverage demo")]
    [Test]
    public void Statistics_SingleValue_ErrorInComputeSampleVariance()
    {
        //arrange
        const int valueCount = 1;
        const bool isPopulation = false;
        const double squareOfDifferences = 0.0d;

        //act + assert
        //write assertion that calculator threw
        Assert.That(() => Statistics.ComputeVariance(squareOfDifferences, valueCount, isPopulation),
            Throws.ArgumentException
                .With.Message.StartsWith("numValues is too low"));
    }

    /// <summary>
    ///     Tests that ComputeVariance method throws an ArgumentException when called with
    ///     a single value (zero values) for population variance.
    ///     This is to ensure the method correctly handles edge cases where the number
    ///     of values is too low to compute a variance.
    /// </summary>
    [Test]
    //[Ignore("Coverage demo")]
    public void Statistics_SingleValue_ErrorInComputePopulationVariance()
    {
        //arrange
        const int valueCount = 0;
        const bool isPopulation = true;
        const double squareOfDifferences = 0.0d;

        //act + assert
        //write assertion that calculator threw
        Assert.That(() => Statistics.ComputeVariance(squareOfDifferences, valueCount, isPopulation),
            Throws.ArgumentException
                .With.Message.StartsWith("numValues is too low"));
    }

    /// <summary>
    ///     Tests that ComputeSquareOfDifferences accurately calculates the sum
    ///     of the squared differences between each value in the list and the mean.
    ///     Ensures that the method processes a provided list of values and mean,
    ///     and returns the correct sum of squared differences within an acceptable precision threshold.
    /// </summary>
    [Test]
    //[Ignore("Coverage demo")]
    public void Statistics_MultipleValues_ComputeSquareOfDifferences()
    {
        // Arrange
        var valuesList = new List<double> { 10, 8, 10, 8, 10 };
        var mean = valuesList.Average(); // Compute the mean

        // Compute the expected square of differences
        var expectedSquareOfDifferences = valuesList
            .Select(value => Math.Pow(value - mean, 2))
            .Sum();

        // Act
        var actualSquareOfDifferences =
            Statistics.ComputeSquareOfDifferences(valuesList, mean);

        // Assert
        Assert.That(actualSquareOfDifferences, Is.EqualTo(expectedSquareOfDifferences).Within(1e-10));
    }

    /// <summary>
    ///     Tests that ComputeSquareOfDifferences throws an ArgumentException when provided with an empty list.
    ///     Ensures that the method correctly identifies and handles empty input lists by triggering the appropriate exception.
    /// </summary>
    [Test]
    //[Ignore("Coverage demo")]
    public void Statistics_EmptyValuesList_ErrorInComputeSquareOfDifferences()
    {
        // Arrange
        var emptyValuesList = new List<double>(); // Creates an empty list
        const double mean = 0.0; // Mean is irrelevant for an empty list but needs to be provided

        // Act + Assert
        Assert.That(() => Statistics.ComputeSquareOfDifferences(emptyValuesList, mean),
            Throws.ArgumentException
                .With.Message.EqualTo("valuesList parameter cannot be null or empty"));
    }

    /// <summary>
    /// Tests that ComputeMean correctly calculates the mean (average) for a list of multiple values.
    /// Ensures that the method accurately processes the input values and returns the expected mean,
    /// validating the accuracy within a specified precision threshold.
    /// </summary>
    [Test]
    //[Ignore("Coverage demo")]
    public void Statistics_MultipleValues_ComputeMean()
    {
        // Arrange
        var valuesList = new List<double> { 1, 2, 3, 4, 5 };

        // Calculate expected mean manually
        var expectedMean = valuesList.Average();

        // Act
        var actualMean = Statistics.ComputeMean(valuesList);

        // Assert
        Assert.That(actualMean, Is.EqualTo(expectedMean).Within(1e-10));
    }

    /// <summary>
    /// Tests that ComputeMean correctly handles an empty list of values.
    /// Ensures that the method throws an ArgumentException with the expected message when
    /// given an empty list, verifying proper validation of input parameters.
    /// </summary>
    [Test]
    //[Ignore("Coverage demo")]
    public void Statistics_EmptyValuesList_ErrorInComputeMean()
    {
        // Arrange
        var emptyValuesList = new List<double>(); // Creates an empty list

        // Act + Assert
        Assert.That(() => Calculator.Statistics.ComputeMean(emptyValuesList),
            Throws.ArgumentException
                .With.Message.EqualTo("valuesList parameter cannot be null or empty"));
    }
}