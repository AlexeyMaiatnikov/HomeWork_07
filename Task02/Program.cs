/*
Задача 50. Напишите программу реализующую метод,принимающий позиции элемента в двумерном массиве, и возвращающий значение этого элемента или же указание, что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
1;7 -> такого элемента в массиве нет
1;1 -> 9
*/

using static System.Console;
Clear();
Write("Введите размер матрицы и диапазон значений через пробел: ");
string[] parameters = ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
Write("Введите номер элемента через пробел: ");
string[] FindParameters = ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
double[,] array = GetMatrixArray(int.Parse(parameters[0]), int.Parse(parameters[1]), double.Parse(parameters[2]), double.Parse(parameters[3]));
PrintMatrixArray(array);
WriteLine(FindElementMatrixArray(array, int.Parse(FindParameters[0]), int.Parse(FindParameters[1])) ? $"Значение элемента равно {array[int.Parse(FindParameters[0]), int.Parse(FindParameters[1])]:f1}" : "Такого элемента в массиве нет");


double[,] GetMatrixArray(int rows, int columns, double minValue, double maxValue)
{
    Random rnd = new Random();
    double[,] resultArray = new double[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            resultArray[i, j] = rnd.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
    return resultArray;
}

bool FindElementMatrixArray(double[,] inArray, int FindRows, int FindColumns)
{
    if (inArray.GetLength(0) > FindRows && inArray.GetLength(1) > FindColumns)
    {
        return true;
    }
    else return false;
}

void PrintMatrixArray(double[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Write($"{inArray[i, j],4:f1} ");

        }
        WriteLine();
    }
}
