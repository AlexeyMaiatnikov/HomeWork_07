/*
Задача 52. Напишите программу реализующую методы, формирования двумерного массива и массива средних арифметических значений каждого столбца.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/


using static System.Console;
Clear();
Write("Введите размер матрицы и диапазон значений через пробел: ");
string[] parameters = ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
double[,] array = GetMatrixArray(int.Parse(parameters[0]), int.Parse(parameters[1]), double.Parse(parameters[2]), double.Parse(parameters[3]));
PrintMatrixArray(array);
PrintArray(AverageArray(array));



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

double[] AverageArray(double[,] inArray)
{
    int length = 0;
    double[] resultArray = new double[inArray.GetLength(1)];
    for (int i = 0; i < inArray.GetLength(1); i++)
    {
        for (int j = 0; j < inArray.GetLength(0); j++)
        {
            resultArray[length] = resultArray[length] + inArray[j, i];

        }
        resultArray[length] = resultArray[length] / inArray.GetLength(0);
        length++;
    }

    return resultArray;
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
void PrintArray(double[] inArray)
{
    Write("Среднее арифметическое каждого столбца: [");
    for (int i = 0; i < inArray.Length - 1; i++)
    {
        Write($"{inArray[i]:f2} ");
    }
    Write($"{inArray[inArray.Length - 1]:f2}]");
}