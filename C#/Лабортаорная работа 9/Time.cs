using System;

public class Time
{
    private int hours;
    private int minutes;
    private static int objectCount = 0;

    public int Hours
    {
        get => hours;
        private set 
        {
            if (value < 0) throw new ArgumentException("Часы не могут быть отрицательными.");
            hours = Math.Max(0, value);
        }
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

    public Time(int hours = 0, int minutes = 0)
    {
        if (hours < 0 || minutes < 0)
            throw new ArgumentException("Часы и минуты не могут быть отрицательными.");
            
        Hours = hours;
        Minutes = minutes;
        objectCount++;
    }

   
    public void Show()
    {
        Console.WriteLine($"Часы:{this.Hours} Минуты:{this.Minutes}");
    }
    public static int ObjectCount => objectCount;

    public static Time operator --(Time time)
    {
        int totalMinutes = time.hours * 60 + time.minutes - 1;
        totalMinutes = Math.Max(0, totalMinutes);
        time.Hours = 0;
        time.Minutes = totalMinutes;
        return time;
    }

    public static Time operator +(Time time1, int minutes)
    {
        time1.Minutes += minutes;

        return time1;
    }

    public static Time operator +(int minutes, Time time1) 
    {
        time1.Minutes += minutes;
        return time1;
    }

    public static Time operator +(Time time1, Time time2) 
    {
        int totalMinutes = (time1.hours * 60 + time1.minutes) + (time2.hours * 60 + time2.minutes);
        return new Time(totalMinutes / 60, totalMinutes % 60);
    }

    public static explicit operator int(Time t) => t.hours;

    public static implicit operator bool(Time t) => t.hours != 0 || t.minutes != 0;

    public override string ToString() => $"{hours}h {minutes}m";
}
