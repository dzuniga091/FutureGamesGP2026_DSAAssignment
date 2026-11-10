using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "BinarySearchTreeTask", menuName = "BinarySearchTree Task")]
    public class BinarySearchTreeTask : Task {
        public SortingEmployeeTask employee_data;
        public Data[] employees_to_be_searched;

        public override void Execute() {
        
        }
    }
}
