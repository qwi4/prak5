using prak5;

public static class CalculateResult
{
    public static string FindColumnsWithMultiple(int[,] array)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);
        string result = "";

        for (int j = 0; j < columns; j++)
        {
            bool containsMultiple = false;

            for (int i = 0; i < rows; i++)
            {
                if (array[i, j] % 5 == 0 || array[i, j] % 7 == 0)
                {
                    containsMultiple = true;
                    result = $"{result}, строка {i + 1}";
                    break;
                }
            }

            if (containsMultiple)
            {
                result = $"{result}, Столбец {j + 1}";
            }
        }

        if (string.IsNullOrEmpty(result))
        {
            result = "Нет столбцов, которые делятся на 5 или 7";
        }
        else
        {
            result = result.TrimStart(',', ' ');
        }

        return result;
    }
}