using System;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "BinarySearchTreeTask", menuName = "BinarySearchTree Task")]
    public class BinarySearchTreeTask : Task {
        [SerializeField] string lower_bound;
        [SerializeField] string upper_bound;
        public ReadingDataTask employee_data;
        public Data[] employees_to_be_added;
        [System.NonSerialized] public BinarySearchTree tree;

        public override void Execute() {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            employees_to_be_added = employee_data.employee_array;
            tree = new BinarySearchTree(employees_to_be_added[0]);
            for(int i = 1; i < employees_to_be_added.Length - 1; i++)
            {
                tree.InsertBasedOnLastEntranceEngine(employees_to_be_added[i]);
            }
            BFS(tree.GetRoot(), lower_bound, upper_bound);
            UnityEngine.Debug.Log(watch.ElapsedMilliseconds + " milliseconds");
            watch.Stop();

        }

        public void BFS(BSTNode root, string lower_bound, string upper_bound)
        {
            DateTime date_time_lower = DateTime.ParseExact(lower_bound, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime date_time_upper = DateTime.ParseExact(upper_bound, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            Queue<BSTNode> queue = new Queue<BSTNode>();
            queue.Enqueue(root);
            Queue<Data> employees_within_range = new Queue<Data>();

            while (queue.Count > 0)
            {
                BSTNode current_node = queue.Dequeue();
                if (current_node.GetLastEntranceInEngine() <= date_time_upper && current_node.GetLastEntranceInEngine() >= date_time_lower)
                {
                    employees_within_range.Enqueue(current_node.GetData());
                }
                if (current_node.left_child != null)
                {
                    queue.Enqueue(current_node.left_child);
                }
                if (current_node.right_child != null)
                {
                    queue.Enqueue(current_node.right_child);
                }
            }
            foreach (Data employee in employees_within_range) UnityEngine.Debug.Log(employee.name);
        }

        //Insert search function here

    public class BSTNode {
        private Data data;
        public BSTNode left_child = null;
        public BSTNode right_child = null;

        public DateTime GetLastEntranceInEngine() {
            DateTime converted_data = DateTime.ParseExact(data.lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            return converted_data;
        }

        public Data GetData()
            {
                return data;
            }

        public string GetName()
            {
                return data.name;
            }

        public BSTNode(Data input_data) {
            this.data = input_data;
        }
    }

    public class BinarySearchTree {
        private BSTNode root;

        public BinarySearchTree(Data root_data) {
            root = new BSTNode(root_data);
        }

        public BSTNode GetRoot()
            {
                return root;
            }
 
        public void InsertBasedOnLastEntranceEngine(Data input_data) {
            //assuming that values are unique
            BSTNode new_node = new BSTNode(input_data);
            BSTNode current_node = root;
            BSTNode last_node = root;
            while(current_node != null) { // Keep searching until we find an empty child slot
                if(ConvertDateTime(input_data) < current_node.GetLastEntranceInEngine() /*node we are examining*/) {
                    last_node = current_node;
                    current_node = current_node.left_child;
                }
                else {
                    last_node = current_node;
                    current_node = current_node.right_child;
                }
            }

            //we reached a point where lastParent has an empty child slot fitting newNode
            if(ConvertDateTime(input_data) < last_node.GetLastEntranceInEngine()) {
                last_node.left_child = new_node;
            }
            else {
                last_node.right_child = new_node;
            }
        }

        public DateTime ConvertDateTime(Data input_data)
            {
                DateTime date_time_to_return = DateTime.ParseExact(input_data.lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                return date_time_to_return;
            }
    }
 
    }
}
