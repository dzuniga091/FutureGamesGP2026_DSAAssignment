using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class TaskQueue <T>
{
    private List<T> core_list;

    public TaskQueue()
    {
        core_list = new List<T>();
    }

    public void Enqueue(T item_to_add) 
    {
        core_list.Insert(0, item_to_add);
    }

    public T Dequeue() 
    {
        if(core_list.Count == 0) throw new Exception("Nothing in queue to remove");
        T end_of_queue = core_list.Last();
        core_list.Remove(core_list.Last());
        return end_of_queue;
    }

    public T Peek() 
    {
        if(core_list.Count == 0) throw new Exception("Nothing in queue to peek at");
        return core_list.Last();
    }
}
