using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{
    public GameObject normalObject, importantObject;
    private ObjectPool<GameObject> _pool;
    public Transform normalObjectParent, importantObjectParent;
    public float destroyTime = 1f, distanceNormal = 3, distanceImportant = 2;
    public bool usePool = false;

    void Start()
    {
        _pool = new ObjectPool<GameObject>(
            () => { return Instantiate(normalObject); },
            onGet => { onGet.SetActive(true); },
            onRelease => { onRelease.SetActive(false); },
            onDestroy => { Destroy(onDestroy); },
            collectionCheck: false,
            defaultCapacity: 10,
            maxSize: 10);

        InvokeRepeating(nameof(SpawnStuff), 1f, 0.2f);
    }

    void SpawnStuff()
    {
        for (int i = 0; i < 10; i++)
        {
            if (usePool)
            {
                var x = _pool.Get();
                x.transform.position = Random.insideUnitSphere * distanceNormal;
                x.transform.parent = normalObjectParent;
                StartCoroutine(DelayedRelease(x));
            }
            else
            {
                var x = Instantiate(normalObject);
                x.transform.position = Random.insideUnitSphere * distanceNormal;
                x.transform.parent = normalObjectParent;
                Destroy(x, destroyTime);
            }
        }
    }

    private IEnumerator DelayedRelease(GameObject obj)
    {
        yield return new WaitForSeconds(destroyTime);
        _pool.Release(obj);
    }

    void Update()
    {

    }
}
