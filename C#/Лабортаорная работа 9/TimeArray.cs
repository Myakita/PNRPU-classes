// TimeArray.cs
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class TimeArray
{
    private Time[] arr;

    public TimeArray(int size)
    {
        if (size <= 0) throw new ArgumentException("Размер массива должен быть положительным.");
        arr = new Time[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = new Time();
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

    // Свойство для получения длины массива
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

    public int MaxIndex()
    {
        if (arr.Length == 0) throw new InvalidOperationException("Массив пустой, невозможно найти максимальный элемент.");
        if (arr.Length == 0)
            throw new InvalidOperationException("Невозможно найти максимальный индекс в пустом массиве.");

        int maxIndex = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i].Hours * 60 + arr[i].Minutes > arr[maxIndex].Hours * 60 + arr[maxIndex].Minutes)
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
