using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DataStructureScript <T> : MonoBehaviour
{
    private Queue<T> priv_queue;
    public DataStructureScript() {
        priv_queue = new Queue<T>();
    }
}
