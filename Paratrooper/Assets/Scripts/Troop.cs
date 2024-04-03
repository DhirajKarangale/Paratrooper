using UnityEngine;
using System.Collections;

public class Troop : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] GameObject objParachute;

    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (objParachute.activeInHierarchy) RemoveParachute();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Bullet"))
        {
            gameManager.effects.TroopDestroy(transform.position);
            StartCoroutine(IEDisable(collider.gameObject));
        }
    }
    

    private IEnumerator IEDisable(GameObject bullet)
    {
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.SetActive(false);
        bullet.SetActive(false);
        gameManager.UpdateScore(6);
    }


    private void RemoveParachute()
    {
        objParachute.SetActive(false);
        boxCollider.offset = new Vector2(0, 0);
        boxCollider.size = new Vector2(0.2f, 0.5f);
    }

    internal void Active()
    {
        objParachute.SetActive(true);
        boxCollider.offset = new Vector2(0, 0.35f);
        boxCollider.size = new Vector2(1, 1.2f);
    }
}