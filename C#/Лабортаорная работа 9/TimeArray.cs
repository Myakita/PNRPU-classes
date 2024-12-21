using System;

public class TimeArray
{
    private Time[] arr;

    public TimeArray() 
    {
        arr = new Time[1];
        arr[0] = new Time(0, 0);
    }

    public TimeArray(int size)
    {
        if (size <= 0)
            throw new ArgumentException("Размер массива должен быть положительным.");

        arr = new Time[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = new Time(0, 0);
        }
    }

    public TimeArray(int size, bool randomize)
    {
        if (size <= 0) throw new ArgumentException("Размер массива должен быть положительным.");
        arr = new Time[size];
        Random rand = new Random();
        for (int i = 0; i < size; i++)
        {
            arr[i] = new Time(rand.Next(0, 24), rand.Next(0, 60));
        }
    }
    public Time[] ToArray()
    {
        return arr;
    }

    public int Length => arr.Length;

    public Time this[int index]
    {
        get
        {
            if (index < 0 || index >= arr.Length) throw new ArgumentException("Индекс вне диапазона массива");
            return arr[index];
        }
        set
        {
            if (index < 0 || index >= arr.Length) throw new ArgumentException("Индекс вне диапазона массива");
            arr[index] = value;
        }
    }
    private bool IsGreater(Time a, Time b)
    {
        return a.Hours > b.Hours || (a.Hours == b.Hours && a.Minutes > b.Minutes);
    }
    public int MaxIndex()
    {
        if (arr.Length == 0) 
            throw new InvalidOperationException("Массив пустой, невозможно найти максимальный элемент.");

        int maxIndex = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (IsGreater(arr[i], arr[maxIndex]))
            {
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    public void Print()
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"Time[{i}]: {arr[i]}");
        }
    }
}
