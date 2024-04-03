using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    private float speed;
    private float troopsRate;
    private float dis;
    private Vector2 stPos;
    private Vector2 enPos;

    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.instance;
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Bullet"))
        {
            gameManager.effects.HelicopterDestroy(transform.position);
            StartCoroutine(IEDisable(collider.gameObject));
        }
    }


    private IEnumerator IEMove()
    {
        float journeyDistance = 0f;
        while (journeyDistance < dis)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, enPos, step);
            journeyDistance = Vector2.Distance(transform.position, stPos);
            SpawnTroop();
            yield return null;
        }

        gameObject.SetActive(false);
    }

    private IEnumerator IEDisable(GameObject bullet)
    {
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.SetActive(false);
        bullet.SetActive(false);
        gameManager.UpdateScore(4);
    }


    private void SpawnTroop()
    {
        if (gameObject.activeInHierarchy && gameManager && Random.value > troopsRate)
        {
            if (transform.position.x > -7f && transform.position.x < 7f)
            {
                Troop troop = gameManager.objectPooler.SpwanObject("Troop", transform.position).GetComponent<Troop>();
                troop.Active();
            }
        }
    }


    internal void Move(float troopsRate, float speed, Vector2 stPos, Vector2 enPos)
    {
        this.speed = speed;
        this.stPos = stPos;
        this.enPos = enPos;
        this.troopsRate = troopsRate;

        dis = Vector2.Distance(stPos, enPos);
        StopAllCoroutines();
        StartCoroutine(IEMove());
    }
}