using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace prak5
{
    public partial class MainWindow : Window
    {
        private int[,] _array1;
        private int[,] _array2;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void GenerateArray_Click(object sender, RoutedEventArgs e)
        {
            _array1 = GenerateRandomArray();
            _array2 = GenerateRandomArray();
            DisplayArray(_array1, dataArrayGrid);
            DisplayArray(_array2, dataArrayGrid);

            var result1 = CalculateResult.FindColumnsWithMultiple(_array1);
            var result2 = CalculateResult.FindColumnsWithMultiple(_array2);

            resultTextBox.Text = $"Массив 1: {result1}{Environment.NewLine}Массив 2: {result2}";
        }
        private static int[,] GenerateRandomArray()
        {
            int[,] array = new int[10, 10];
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    array[i, j] = random.Next(1, 8);
                }
            }

            return array;
        }

        private static void DisplayArray(int[,] array, DataGrid dataGrid)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            dataGrid.Columns.Clear();

            for (int i = 0; i < columns; i++)
            {
                dataGrid.Columns.Add(new DataGridTextColumn
                {
                    Binding = new System.Windows.Data.Binding($"[{i}]"),
                    Header = $"Column {i + 1}"
                });
            }

            dataGrid.Items.Clear();

            for (int i = 0; i < rows; i++)
            {
                dataGrid.Items.Add(new ArrayRow(array, i));
            }

        }

        public class ArrayRow
        {
            private int[,] array;
            private int row;

            public ArrayRow(int[,] array, int row)
            {
                this.array = array;
                this.row = row;
            }

            public int this[int column] => array[row, column];
        }

    }
}



