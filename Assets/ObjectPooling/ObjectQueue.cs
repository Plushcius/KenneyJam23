using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectQueue : MonoBehaviour
{
    Queue<AnimationObject> q = new Queue<AnimationObject>();
    int _maxQueueSize = 10;
    // objects are prepopulated in unity
    public GameObject[] objects;

    private void Start()
    {
        _maxQueueSize = objects.Length;
        var x = q.Dequeue();
        print(q.Dequeue());

    }

    void DoStuff()
    {
        if (q.Count < _maxQueueSize)
        {
            q.Enqueue(new AnimationObject(StartCoroutine(Animate(null, objects[q.Count], null)), objects[q.Count]));
        }
        else
        {
            var x = q.Dequeue();
            q.Enqueue(new AnimationObject(StartCoroutine(Animate(x.PreviousCR, x.Target, null)), x.Target));
        }

    }

    IEnumerator Animate(Coroutine previousCR, GameObject target, string settings)
    {
        if (previousCR != null)
            StopCoroutine(previousCR);

        // logic
        yield return null;
    }

}

public class AnimationObject
{
    public Coroutine PreviousCR { get; set; }
    public GameObject Target { get; set; }

    public AnimationObject(Coroutine previousCr, GameObject target)
    {
        PreviousCR = previousCr;
        Target = target;
    }
}
