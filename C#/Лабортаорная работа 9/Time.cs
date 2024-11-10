// Time.cs
using System;

public class Time
{
    private int hours;
    private int minutes;
    private static int objectCount = 0;

    public Time(int hours = 0, int minutes = 0)
    {
        if (hours < 0 || minutes < 0)
            throw new ArgumentException("Часы и минуты не могут быть отрицательными.");

        Hours = hours;
        Minutes = minutes;
        objectCount++;
    }

    public int Hours
    {
        get => hours;
        private set => hours = Math.Max(0, value);
    }

    public int Minutes
    {
        get => minutes;
        private set
        {
            if (value < 0) throw new ArgumentException("Минуты не могут быть отрицательными.");
            hours += value / 60;
            minutes = value % 60;
        }
    }

    public static int ObjectCount => objectCount;

    // Уменьшение времени на одну минуту
    public void DecrementMinute()
    {
        int totalMinutes = hours * 60 + minutes - 1;
        totalMinutes = Math.Max(0, totalMinutes);
        Hours = totalMinutes / 60;
        Minutes = totalMinutes % 60;
    }

    // Добавление минут к текущему времени
    public void AddMinutes(int mins)
    {
        if (mins < 0) throw new ArgumentException("Минуты для добавления не могут быть отрицательными.");

        int totalMinutes = hours * 60 + minutes + mins;
        Hours = totalMinutes / 60;
        Minutes = totalMinutes % 60;
    }

    // Сложение двух объектов Time
    public void AddTime(Time other)
    {
        int totalMinutes = (hours + other.hours) * 60 + minutes + other.minutes;
        Hours = totalMinutes / 60;
        Minutes = totalMinutes % 60;
    }

    public static explicit operator int(Time t) => t.hours;

    public static implicit operator bool(Time t) => t.hours != 0 || t.minutes != 0;

    public override string ToString() => $"{hours}h {minutes}m";
}
