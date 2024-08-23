using Homework1;

namespace Tests;

public class Tests
{
    [Test]
    public void PassingTest()
    {
        Assert.AreEqual(4, Calculator.Add(2,2));
    }

    [Test]
    public void FailingTest()
    {
        Assert.AreEqual(5, Calculator.Add(2,3));
    }
}