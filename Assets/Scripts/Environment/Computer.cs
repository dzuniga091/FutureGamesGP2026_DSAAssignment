using Environment.Tasks;
using NUnit.Framework.Internal;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField] private Task testTask = null; // Put your stack/queue here :)
        [SerializeField] private Task Task1 = null;
        [SerializeField] private Task Task2 = null;
        [SerializeField] private Task Task3 = null;
        TaskQueue<Task> task_queue;

        private void Awake() {
            task_queue = new TaskQueue<Task>();
            task_queue.Enqueue(testTask);
            task_queue.Enqueue(Task1);
            task_queue.Enqueue(Task2);
            task_queue.Enqueue(Task3);
            Debug.Log(task_queue);
        }

        public void OnInteract() {
            Task current_task = task_queue.Peek();
            current_task.Execute();
            task_queue.Dequeue();
        }
    }
}
