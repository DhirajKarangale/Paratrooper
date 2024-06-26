using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] Transform shooter;
    [SerializeField] float rotationSpeed;
    [SerializeField] float rotationOffset;

    [Header("Shooting")]
    [SerializeField] Transform shootPoint;
    [SerializeField] float shootForce;

    private GameManager gameManager;
    private ObjectPooler objectPooler;


    private void Start()
    {
        gameManager = GameManager.instance;
        objectPooler = gameManager.objectPooler;
    }

    private void Update()
    {
        Rotate();
        Shoot();
    }


    private IEnumerator IEDisable(GameObject obj)
    {
        yield return new WaitForSecondsRealtime(2);
        obj.SetActive(false);
    }


    private void Rotate()
    {
        float input = -Input.GetAxisRaw("Horizontal");
        if (input != 0)
        {
            float angle = rotationOffset * input;
            float curr = shooter.rotation.eulerAngles.z;
            float speed = rotationSpeed * Time.deltaTime;

            Quaternion rot = Quaternion.Euler(0f, 0f, Mathf.LerpAngle(curr, angle, speed));
            shooter.rotation = rot;
        }
    }

    private void Shoot()
    {
        if (!gameManager.isGameOver && Input.GetButtonDown("Jump"))
        {
            Rigidbody2D bullet = objectPooler.SpwanObject("Bullet", shootPoint.position);
            gameManager.effects.Shoot();
            bullet.AddForce(shootPoint.up * shootForce);
            StartCoroutine(IEDisable(bullet.gameObject));
        }
    }
}