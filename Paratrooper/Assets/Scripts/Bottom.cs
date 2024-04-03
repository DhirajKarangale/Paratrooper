using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bottom : MonoBehaviour
{
    [SerializeField] Transform[] troopsPos;

    private HashSet<Troop> troops;
    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.instance;
        troops = new HashSet<Troop>();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Troop troop = collider.GetComponent<Troop>();
        if (troop && !gameManager.isGameOver)
        {
            troops.Add(troop);
            Check();
        }
    }


    private void Check()
    {
        if (troops.Count >= 4)
        {
            List<Troop> sortedTroops = new List<Troop>(troops);
            sortedTroops.Sort((a, b) => Vector3.Distance(a.transform.position, Vector3.zero).CompareTo(Vector3.Distance(b.transform.position, Vector3.zero)));
            gameManager.isGameOver = true;

            Troop troop1 = sortedTroops[0];
            Troop troop2 = sortedTroops[1];
            Troop troop3 = sortedTroops[2];
            Troop troop4 = sortedTroops[3];

            troop1.Move(troopsPos[0].position, 0f);
            troop2.Move(troopsPos[1].position, 0.1f);
            troop3.Move(troopsPos[2].position, 0.2f);
            troop4.Move(troopsPos[3].position, 0.3f);

            gameManager.GameOver();
        }
    }
}