using Xunit;
using System;

public class UserInterfaceTests
{
    [Fact]
    public void SubtractOneMinute_TimeDecrementedCorrectly()
    {
        var time = new Time(1, 0);
        UserInterface.SubtractOneMinute(time);
        Assert.Equal(0, time.Hours);
        Assert.Equal(59, time.Minutes);
    }

    [Fact]
    public void AddMinutes_AddsMinutesCorrectly()
    {
        var time = new Time(1, 0);
        // Используем UserInterface для добавления минут
        time.AddMinutes(30);
        Assert.Equal(1, time.Hours);
        Assert.Equal(30, time.Minutes);
    }

    [Fact]
    public void AddTimes_AddsTwoTimesCorrectly()
    {
        var time1 = new Time(1, 30);
        var time2 = new Time(2, 0);
        UserInterface.AddTimes(time1, time2);
        Assert.Equal(3, time1.Hours);
        Assert.Equal(30, time1.Minutes);
    }

    [Fact]
    public void DisplayConversions_ConvertsToIntAndBoolCorrectly()
    {
        var time = new Time(2, 45);
        int hours = (int)time;
        bool isNonZero = time;

        Assert.Equal(2, hours);
        Assert.True(isNonZero);
    }

    [Fact]
    public void DisplayMaxIndex_ReturnsCorrectMaxIndex()
    {
        var timeArray = new TimeArray(3);
        timeArray[0] = new Time(1, 10);
        timeArray[1] = new Time(3, 0);
        timeArray[2] = new Time(2, 45);

        int maxIndex = timeArray.MaxIndex();
        Assert.Equal(1, maxIndex);
    }
}
