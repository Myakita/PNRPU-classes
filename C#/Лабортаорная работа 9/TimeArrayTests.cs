using Xunit;
using System;

public class TimeArrayTests
{
    [Fact]
    public void Constructor_ValidSize_CreatesArrayWithDefaultValues()
    {
        var timeArray = new TimeArray(5);
        Assert.Equal(5, timeArray.Length);
        for (int i = 0; i < timeArray.Length; i++)
        {
            Assert.Equal(0, timeArray[i].Hours);
            Assert.Equal(0, timeArray[i].Minutes);
        }
    }

    [Fact]
    public void Constructor_NegativeSize_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new TimeArray(-5));
    }

    [Fact]
    public void Indexer_GetAndSet_ValidIndexWorksCorrectly()
    {
        var timeArray = new TimeArray(2);
        var newTime = new Time(3, 15);
        timeArray[1] = newTime;

        Assert.Equal(newTime, timeArray[1]);
    }

    [Fact]
    public void Indexer_OutOfBounds_ThrowsException()
    {
        var timeArray = new TimeArray(2);
        Assert.Throws<ArgumentException>(() => timeArray[-1]);
        Assert.Throws<ArgumentException>(() => timeArray[2]);
    }

    [Fact]
    public void MaxIndex_ReturnsCorrectMaxTimeIndex()
    {
        var timeArray = new TimeArray(3);
        timeArray[0] = new Time(1, 30);
        timeArray[1] = new Time(2, 15);
        timeArray[2] = new Time(0, 45);

        int maxIndex = timeArray.MaxIndex();
        Assert.Equal(1, maxIndex);
    }

    [Fact]
    public void MaxIndex_EmptyArray_ThrowsException()
    {
        var timeArray = new TimeArray(0);
        Assert.Throws<InvalidOperationException>(() => timeArray.MaxIndex());
    }
}
