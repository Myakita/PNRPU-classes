namespace Лабораторная_работа_5
{
    using System;

    class Program
    {
        static void Main()
        {
            int[]? array1D = null;
            int[,]? array2D = null;
            int[][]? jaggedArray = null;

            ShowMenu(ref array1D, ref array2D, ref jaggedArray);
        }

        static void ShowMenu(ref int[] array1d, ref int[,] array2d, ref int[][] jaggedArray)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Текущие массивы:");
                PrintArrays(array1d, array2d, jaggedArray);

                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Ввести массивы вручную");
                Console.WriteLine("2. Сгенерировать случайные массивы");
                Console.WriteLine("3. Добавить элементы в конец одномерного массива");
                Console.WriteLine("4. Удалить столбцы из двумерного массива");
                Console.WriteLine("5. Добавить строку в начало рваного массива");
                Console.WriteLine("6. Выйти");
                Console.Write("Выберите опцию: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            InputArraysManually(out array1d, out array2d, out jaggedArray);
                            break;
                        case 2:
                            GenerateRandomArrays(out array1d, out array2d, out jaggedArray);
                            break;
                        case 3:
                            AddElementsToEnd(ref array1d);
                            break;
                        case 4:
                            RemoveColumns(ref array2d);
                            break;
                        case 5:
                            AddRowToStart(ref jaggedArray);
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }

                    if (!exit)
                    {
                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода. Введите число.");
                }
            }
        }

        static void InputArraysManually(out int[] array1d, out int[,] array2d, out int[][] jaggedArray)
        {
            Console.WriteLine("Ввод одномерного массива:");
            int size = GetValidNumber("Введите количество элементов: ");
            array1d = new int[size];
            for (int i = 0; i < size; i++)
            {
                array1d[i] = GetValidNumber($"Введите элемент {i + 1}: ");
            }

            Console.WriteLine("\nВвод двумерного массива:");
            int rows = GetValidNumber("Введите количество строк: ");
            int columns = GetValidNumber("Введите количество столбцов: ");
            array2d = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array2d[i, j] = GetValidNumber($"Введите элемент [{i}, {j}]: ");
                }
            }

            Console.WriteLine("\nВвод рваного массива:");
            int jaggedRows = GetValidNumber("Введите количество строк: ");
            jaggedArray = new int[jaggedRows][];
            for (int i = 0; i < jaggedRows; i++)
            {
                int jaggedColumns = GetValidNumber($"Введите количество элементов в строке {i + 1}: ");
                jaggedArray[i] = new int[jaggedColumns];
                for (int j = 0; j < jaggedColumns; j++)
                {
                    Console.Write($"Введите элемент [{i}, {j}]: ");
                    jaggedArray[i][j] = GetValidNumber($"Введите элемент [{i}, {j}]: ");
                }
            }
        }

        static void GenerateRandomArrays(out int[] oneDimArray, out int[,] twoDimArray, out int[][] jaggedArray)
        {
            Random rand = new Random();

            Console.WriteLine("Генерация одномерного массива:");
            int size = GetValidNumber("Введите количество элементов: ");
            int minValue = 0;
            int maxValue = 0;
            do 
            {
                int minvalue = GetValidNumber("Введите минимальное значение для одномерного массива: ");
                int maxvalue = GetValidNumber("Введите максимальное значение для одномерного массива: ");
                if (minvalue > maxvalue)
                {
                    Console.WriteLine("Максимальное число не может быть меньше минимального, повторите ввод");
                }
                minValue = minvalue;
                maxValue = maxvalue;
            } while (minValue > maxValue);
            
            oneDimArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                oneDimArray[i] = rand.Next(minValue, maxValue + 1);
            }

            Console.WriteLine("\nГенерация двумерного массива:");
            int rows = GetValidNumber("Введите количество строк: ");
            int columns = GetValidNumber("Введите количество столбцов: ");
            minValue = 0;
            maxValue = 0;
            do
            {
                int minvalue = GetValidNumber("Введите минимальное значение для одномерного массива: ");
                int maxvalue = GetValidNumber("Введите максимальное значение для одномерного массива: ");
                if (minvalue > maxvalue)
                {
                    Console.WriteLine("Максимальное число не может быть меньше минимального, повторите ввод");
                }
                minValue = minvalue;
                maxValue = maxvalue;
            } while (minValue > maxValue);

            twoDimArray = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    twoDimArray[i, j] = rand.Next(minValue, maxValue + 1);
                }
            }

            Console.WriteLine("\nГенерация рваного массива:");
            int jaggedRows = GetValidNumber("Введите количество строк: ");
            jaggedArray = new int[jaggedRows][];
            minValue = 0;
            maxValue = 0;
            do
            {
                int minvalue = GetValidNumber("Введите минимальное значение для одномерного массива: ");
                int maxvalue = GetValidNumber("Введите максимальное значение для одномерного массива: ");
                if (minvalue > maxvalue)
                {
                    Console.WriteLine("Максимальное число не может быть меньше минимального, повторите ввод");
                }
                minValue = minvalue;
                maxValue = maxvalue;
            } while (minValue > maxValue);

            for (int i = 0; i < jaggedRows; i++)
            {
                int jaggedColumns = GetValidNumber($"Введите количество элементов в строке {i + 1}: ");
                jaggedArray[i] = new int[jaggedColumns];
                for (int j = 0; j < jaggedColumns; j++)
                {
                    jaggedArray[i][j] = rand.Next(minValue, maxValue + 1);
                }
            }
        }

        static int GetValidNumber(string prompt)
        {
            int number;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Ошибка: введите корректное числовое значение.");
                }
            }
        }
        static float GetValidNumber(string prompt, bool IsFloat)
        {
            float number;
            while (true)
            {
                Console.Write(prompt);
                if (float.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Ошибка: введите корректное число c плавающей точкой.");
                }
            }
        }

        static void AddElementsToEnd(ref int[] array)
        {//TODO: ВЫБОР СЛУЧАЙНЫЙ ИЛИ ВРУЧНУЮ ВВОД ДЛЯ 3-Х МАССИВОВ
            if (array == null)
            {
                Console.WriteLine("Массив не создан.");
                return;
            }

            while (true)
            {
                Console.Write("Сколько элементов добавить? ");
                int count = GetValidNumber("Введите количество элементов: ");
                int[] newElements = new int[count];

                for (int i = 0; i < count; i++)
                {
                    newElements[i] = GetValidNumber($"Введите элемент {i + 1}: ");
                }

                int[] newArray = new int[array.Length + count];
                array.CopyTo(newArray, 0);
                newElements.CopyTo(newArray, array.Length);
                array = newArray;

                Console.WriteLine("Массив после добавления элементов:");
                Console.WriteLine(string.Join(", ", array));

                Console.WriteLine("Выберите дальнейшее действие:");
                Console.WriteLine("1. Продолжить работу с одномерным массивом");
                Console.WriteLine("2. Вернуться в главное меню");
                Console.Write("Введите ваш выбор: ");
                int choice = GetValidNumber("");

                if (choice > 2)
                {
                    Console.WriteLine("Некорректная опция, повторите ввод");
                }
                if (choice < 1)
                {
                    Console.WriteLine("Некорректная опция, повторите ввод");
                }

                if (choice == 2)
                {
                    break;
                }
            }
        }

        static void RemoveColumns(ref int[,] array)
        {
            if (array == null)
            {
                Console.WriteLine("Массив не создан.");
                return;
            }

            while (true)
            {
                int k1 = GetValidNumber("Введите начальный столбец (порядковый номер): ") - 1;
                int k2 = GetValidNumber("Введите конечный столбец (порядковый номер): ") - 1;

                if (k1 < 0 || k2 >= array.GetLength(1) || k1 > k2)
                {
                    Console.WriteLine("Неверный диапазон столбцов.");
                    continue;
                }

                int columnsToRemove = k2 - k1 + 1;
                int[,] newArray = new int[array.GetLength(0), array.GetLength(1) - columnsToRemove];

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    int colIndex = 0;
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (j < k1 || j > k2)
                        {
                            newArray[i, colIndex] = array[i, j];
                            colIndex++;
                        }
                    }
                }

                array = newArray;

                Console.WriteLine("Двумерный массив после удаления столбцов:");
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write(array[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Выберите дальнейшее действие:");
                Console.WriteLine("1. Продолжить работу с двумерным массивом");
                Console.WriteLine("2. Вернуться в главное меню");
                Console.Write("Введите ваш выбор: ");
                int choice = GetValidNumber("");

                if (choice == 2)
                {
                    break;
                }
            }
        }

        static void AddRowToStart(ref int[][] array)
        {
            if (array == null)
            {
                Console.WriteLine("Массив не создан.");
                return;
            }

            while (true)
            {
                Console.Write("Сколько элементов в новой строке? ");
                int count = GetValidNumber("Введите количество элементов: ");
                int[] newRow = new int[count];

                for (int i = 0; i < count; i++)
                {
                    newRow[i] = GetValidNumber($"Введите элемент {i + 1}: ");
                }

                int[][] newArray = new int[array.Length + 1][];
                newArray[0] = newRow;
                array.CopyTo(newArray, 1);
                array = newArray;

                Console.WriteLine("Рваный массив после добавления строки:");
                foreach (var row in array)
                {
                    Console.WriteLine(string.Join(", ", row));
                }

                Console.WriteLine("Выберите дальнейшее действие:");
                Console.WriteLine("1. Продолжить работу с рваным массивом");
                Console.WriteLine("2. Вернуться в главное меню");
                Console.Write("Введите ваш выбор: ");
                int choice = GetValidNumber("");
                if (choice > 2)
                {
                    Console.WriteLine("Некорректная опция, повторите ввод");
                }
                if (choice < 1)
                {
                    Console.WriteLine("Некорректная опция, повторите ввод");
                }
                if (choice == 2)
                {
                    break;
                }
                
            }
        }

        static void PrintArrays(int[] oneDimArray, int[,] twoDimArray, int[][] jaggedArray)
        {
            Console.WriteLine("Одномерный массив:");
            if (oneDimArray != null)
            {
                Console.WriteLine(string.Join(", ", oneDimArray));
            }
            else
            {
                Console.WriteLine("Массив пуст.");
            }

            Console.WriteLine("\nДвумерный массив:");
            if (twoDimArray != null)
            {
                for (int i = 0; i < twoDimArray.GetLength(0); i++)
                {
                    for (int j = 0; j < twoDimArray.GetLength(1); j++)
                    {
                        Console.Write(twoDimArray[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Массив пуст.");
            }

            Console.WriteLine("\nРваный массив:");
            if (jaggedArray != null)
            {
                foreach (var row in jaggedArray)
                {
                    Console.WriteLine(string.Join(", ", row));
                }
            }
            else
            {
                Console.WriteLine("Массив пуст.");
            }
        }
    }

}
