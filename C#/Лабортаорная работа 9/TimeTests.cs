using Xunit;
using System;

public class TimeTests
{
    [Fact]
    public void Constructor_ValidValues_CreatesObject()
    {
        var time = new Time(2, 30);
        Assert.Equal(2, time.Hours);
        Assert.Equal(30, time.Minutes);
    }

    [Fact]
    public void Constructor_NegativeValues_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Time(-1, 30));
        Assert.Throws<ArgumentException>(() => new Time(2, -15));
    }

    [Fact]
    public void DecrementMinute_MinutesGreaterThanZero_DecrementsSuccessfully()
    {
        var time = new Time(2, 1);
        time.DecrementMinute();
        Assert.Equal(2, time.Hours);
        Assert.Equal(0, time.Minutes);
    }

    [Fact]
    public void DecrementMinute_ZeroMinutesAndHours_StaysAtZero()
    {
        var time = new Time(0, 0);
        time.DecrementMinute();
        Assert.Equal(0, time.Hours);
        Assert.Equal(0, time.Minutes);
    }

    [Theory]
    [InlineData(2, 30, 20, 2, 50)]
    [InlineData(1, 50, 15, 2, 5)]
    public void AddMinutes_ValidValues_AddsMinutesCorrectly(int initialHours, int initialMinutes, int addMinutes, int expectedHours, int expectedMinutes)
    {
        var time = new Time(initialHours, initialMinutes);
        time.AddMinutes(addMinutes);
        Assert.Equal(expectedHours, time.Hours);
        Assert.Equal(expectedMinutes, time.Minutes);
    }

    [Fact]
    public void AddMinutes_NegativeMinutes_ThrowsException()
    {
        var time = new Time(1, 0);
        Assert.Throws<ArgumentException>(() => time.AddMinutes(-5));
    }

    [Fact]
    public void AddTime_ValidValues_AddsCorrectly()
    {
        var time1 = new Time(1, 30);
        var time2 = new Time(2, 45);
        time1.AddTime(time2);
        Assert.Equal(4, time1.Hours);
        Assert.Equal(15, time1.Minutes);
    }

    [Fact]
    public void ExplicitConversionToInt_ReturnsHoursOnly()
    {
        var time = new Time(3, 45);
        int hours = (int)time;
        Assert.Equal(3, hours);
    }

    [Fact]
    public void ImplicitConversionToBool_ZeroTime_ReturnsFalse()
    {
        var time = new Time(0, 0);
        Assert.False(time);
    }

    [Fact]
    public void ImplicitConversionToBool_NonZeroTime_ReturnsTrue()
    {
        var time = new Time(1, 0);
        Assert.True(time);
    }
}
