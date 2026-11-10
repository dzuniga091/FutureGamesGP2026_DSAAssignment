using System;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "SortingEmployee Task", menuName = "SortingEmployee Task")]
    public class SortingEmployeeTask : Task
    { // Sorting based on lastEntranceInEngineRoom
        public DateTime[] employee_engine_entrances;
        public Data[] sorted_employees;
        public ReadingDataTask employee_data;

        public override void Execute()
        {
            Data[] employees_to_be_sorted = employee_data.employee_array;
            employee_engine_entrances = new DateTime[employees_to_be_sorted.Length];
            sorted_employees = new Data[employees_to_be_sorted.Length];

            for (int i = 0; i < employees_to_be_sorted.Length; i++)
            {
                employee_engine_entrances[i] = DateTime.ParseExact(employees_to_be_sorted[i].lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }

            mergesort(employee_engine_entrances, 0, employee_engine_entrances.Length - 1);

            for (int i = 0; i < employee_engine_entrances.Length; i++)
            {
                for (int j = 0; j < employees_to_be_sorted.Length; j++)
                {
                    if (employee_engine_entrances[i].ToString("yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) == employees_to_be_sorted[j].lastEntranceInEngineRoom)
                    {
                        sorted_employees[i] = employees_to_be_sorted[j];
                    }
                }
            }
        }

        public void mergesort(DateTime[] input_array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                mergesort(input_array, left, middle);
                mergesort(input_array, middle + 1, right);
                merge(input_array, left, middle, right);
            }
        }

        public void merge(DateTime[] input_array, int left, int middle, int right)
        {
            int size_left = (middle - left + 1);
            int size_right = right - middle;
            DateTime[] left_array = new DateTime[size_left];
            DateTime[] right_array = new DateTime[size_right];
            for (int a = 0; a < size_left; a++)
            {
                left_array[a] = input_array[a + left];
            }
            for (int a = 0; a < size_right; a++)
            {
                right_array[a] = input_array[a + middle + 1];
            }

            int i = 0;
            int j = 0;
            int k = left;

            while (i < size_left && j < size_right)
            {
                if (left_array[i] <= right_array[j])
                {
                    input_array[k] = left_array[i];
                    i++;
                }
                else
                {
                    input_array[k] = right_array[j];
                    j++;
                }
                k++;
            }

            while (i < size_left)
            {
                input_array[k] = left_array[i];
                i++;
                k++;
            }

            while (j < size_right)
            {
                input_array[k] = right_array[j];
                j++;
                k++;
            }
        }
    }
}
