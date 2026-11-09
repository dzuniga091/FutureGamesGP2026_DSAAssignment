using System;
using System.Globalization;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "BinarySort Task", menuName = "BinarySort Task")]
    public class BinarySearchTask : Task
    {
        [SerializeField] string lower_bound;
        [SerializeField] string upper_bound;
        public Data[] employees_to_be_searched;

        public override object Execute(object input = null)
        {
            Data[] employees_to_be_searched = input as Data[];
            BinaryRange(employees_to_be_searched, lower_bound, upper_bound);
            return null;
        }

        public int BinarySearch(DateTime[] input_array, String input_string) // up here we probably will need DateTime parameters titled min and max
        {
            DateTime date_time_to_be_found = DateTime.ParseExact(input_string, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            int low = 0;
            int high = input_array.Length - 1;
            while (low <= high) 
            {
                int median = low + ((high - low) / 2);
                if (input_array[median] == date_time_to_be_found)
                {
                    Debug.Log("Found " + date_time_to_be_found + " at index: " + median);
                    return median;
                }

                if (input_array[median] < date_time_to_be_found)
                {
                    low = median + 1;
                }
                else
                {
                    high = median - 1;
                }
            }
            return -1;
        }

        public Data[] BinaryRange(Data[] input_array, String lower_bound, String upper_bound)
        {
            Debug.Log(input_array.Length);
            DateTime[] engine_entrances = new DateTime[input_array.Length];
            for (int i = 0; i < input_array.Length; i++)
            {
                engine_entrances[i] = DateTime.ParseExact(input_array[i].lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
            int start_index = BinarySearch(engine_entrances, lower_bound);
            int end_index = BinarySearch(engine_entrances, upper_bound);
            Data[] resulting_array = new Data[(end_index - start_index) + 1];
            Array.Copy(input_array, start_index, resulting_array, 0, resulting_array.Length);
            foreach (Data a in resulting_array) Debug.Log(a.name);
            return resulting_array;
        }
    }
}
