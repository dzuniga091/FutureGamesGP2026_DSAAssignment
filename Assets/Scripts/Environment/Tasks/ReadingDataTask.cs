using System;
using System.Data.Common;
using System.IO;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "ReadingData Task", menuName = "ReadingData Task")]
    public class ReadingDataTask : Task{
        [SerializeField] string file_name;
        string Json;
        string file_path;
        public Data[] employee_array;
        public override void Execute() {
            SaveToArray(Read());
        }

        public object Read() {
            file_path = Path.Combine(Application.streamingAssetsPath, file_name);
            Json = File.ReadAllText(file_path);
            EmployeeList employee_data = JsonUtility.FromJson<EmployeeList>(Json);
            return employee_data.employees;
        }

        public object SaveToArray(object input = null) {
            Data[] employees_from_json = input as Data[];

            employee_array = new Data[employees_from_json.Length];
            for (int i = 0; i < employees_from_json.Length; i++) {
                employee_array[i] = employees_from_json[i];
            }
            return(employee_array);
        }
    }


        [Serializable]
        public class EmployeeList {
            public Data[] employees;
        }

        [Serializable]
        public class Data {
            public string name;
            public int employeeId;
            public bool hasEngineRoomClearance;
            public string lastEntranceInEngineRoom;
            public string lastExitFromEngineRoom;
        }
}

