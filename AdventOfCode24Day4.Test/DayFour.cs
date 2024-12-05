namespace AdventOfCode24Day4.Test;

[TestClass]
public class DayFourTests
{
    [TestMethod]
    public void PartOne_ShouldParseWordSearchCorrectly()
    {
        string input = "MMMSXXMASM\nMSAMXMSMSA\nAMXSXMAAMM\nMSAMASMSMX\nXMASAMXAMM\nXXAMMXXAMA\nSMSMSASXSS\nSAXAMASAAA\nMAMMMXMMMM\nMXMXAXMASX";
        int expected = 18;

        string tempTestFile = "tempTestFilePartOne.txt";
        File.WriteAllText(tempTestFile, input);

        DayFour dayFour = new DayFour(tempTestFile);
        int actual = dayFour.PartOne();

        Assert.AreEqual(expected, actual);

        File.Delete(tempTestFile);
    }
    [TestMethod]
    public void PartTwo_ShouldParseWordSearchCorrectly()
    {
        string input = "MMMSXXMASM\nMSAMXMSMSA\nAMXSXMAAMM\nMSAMASMSMX\nXMASAMXAMM\nXXAMMXXAMA\nSMSMSASXSS\nSAXAMASAAA\nMAMMMXMMMM\nMXMXAXMASX";
        int expected = 9;

        string tempTestFile = "tempTestFilePartTwo.txt";
        File.WriteAllText(tempTestFile, input);

        DayFour dayFour = new DayFour(tempTestFile);
        int actual = dayFour.PartTwo();

        Assert.AreEqual(expected, actual);

        File.Delete(tempTestFile);
    }
}