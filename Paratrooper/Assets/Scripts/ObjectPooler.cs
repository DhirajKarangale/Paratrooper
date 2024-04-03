using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public List<Pool> pools;

    private Dictionary<string, Queue<Rigidbody2D>> poolDictonary;
    private Rigidbody2D poolItem;

    private void Awake()
    {
        SpawnPool();
    }

    private void SpawnPool()
    {
        poolDictonary = new Dictionary<string, Queue<Rigidbody2D>>();

        foreach (Pool pool in pools)
        {
            Queue<Rigidbody2D> objectPool = new Queue<Rigidbody2D>();

            for (int i = 0; i < pool.size; i++)
            {
                poolItem = Instantiate(pool.prefab);
                poolItem.transform.SetParent(this.transform);
                poolItem.gameObject.SetActive(false);
                objectPool.Enqueue(poolItem);
            }

            poolDictonary.Add(pool.tag, objectPool);
        }
    }


    public Rigidbody2D SpwanObject(string tag, Vector3 pos)
    {
        poolItem = poolDictonary[tag].Dequeue();
        poolItem.transform.localPosition = pos;
        poolItem.velocity = Vector3.zero;
        poolItem.transform.rotation = Quaternion.identity;
        poolItem.gameObject.SetActive(true);

        poolDictonary[tag].Enqueue(poolItem);

        return poolItem;
    }
}


[System.Serializable]
public class Pool
{
    public string tag;
    public int size;
    public Rigidbody2D prefab;
}