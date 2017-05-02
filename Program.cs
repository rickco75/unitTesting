// UnitTestingInOneProject

// This example puts the code to be tested and the unit
// testing code all into one project for learning purposes.
// This is not how it is done in real life.
// Done properly, you would create the Unit Test
// project separately and add a reference to the project
// to be tested.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class ClassUnderTest
{
    public int GoodAddIntegers(int x, int y)
    {
        return x + y; // good
    }
    public int BadAddIntegers(int x, int y)
    {
        return x * y; // bad
    }
}

[TestClass]
public class UnitTests
{
    [TestMethod]
    public void TestGoodAddIntegers()
    {
        // Arrange
        ClassUnderTest cut = new ClassUnderTest();

        // Act
        int result = cut.GoodAddIntegers(3, 4); // passes

        // Assert
        Assert.AreEqual(result, 3 + 4);
    }
    [TestMethod]
    public void TestBadAddIntegers()
    {
        // Arrange
        ClassUnderTest cut = new ClassUnderTest();

        // Act
        int result = cut.BadAddIntegers(3, 4);

        // Assert
        Assert.AreEqual(result, 3 + 4); // fails
    }
}

class Program
{
    static void Main()
    {
        UnitTests ut = new UnitTests();
        try
        {
            ut.TestGoodAddIntegers();
            ut.TestBadAddIntegers();
        }
        catch (AssertFailedException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("\nHere is the stack trace:\n");
            Console.WriteLine(ex.StackTrace);
        }
    }
}