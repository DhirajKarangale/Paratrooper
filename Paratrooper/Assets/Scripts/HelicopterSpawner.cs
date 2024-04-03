using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class HelicopterSpawner : MonoBehaviour
{
    [SerializeField] float x;
    [SerializeField] float rate;
    [SerializeField] float minY, maxY;
    [SerializeField] internal float speed;
    [SerializeField] internal float troopsRate;

    private ObjectPooler objectPooler;


    private void Start()
    {
        objectPooler = GameManager.instance.objectPooler;
        StartCoroutine(IESpawn());
    }


    private IEnumerator IESpawn()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSecondsRealtime(rate);
        }
    }


    private void Spawn()
    {
        bool isRight = Random.value > 0.5f;
        float y = Random.Range(minY, maxY);
        Vector2 stPos = new Vector2(-x, y);
        Vector2 enPos = new Vector2(x, y);


        if (isRight)
        {
            Vector2 temp = stPos;
            stPos = enPos;
            enPos = temp;
        }

        Helicopter helicopter = objectPooler.SpwanObject("Helicopter", stPos).GetComponent<Helicopter>();
        helicopter.transform.localScale = new Vector3(isRight ? -1 : 1, 1, 1);
        helicopter.Move(troopsRate, speed, stPos, enPos);
    }
}