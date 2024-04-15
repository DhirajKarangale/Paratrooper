using UnityEngine;

public class Effects : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] ParticleSystem psFall;
    [SerializeField] ParticleSystem psSmoke;
    [SerializeField] ParticleSystem psBlood;
    [SerializeField] ParticleSystem psDestroy;
    [SerializeField] ParticleSystem psExplosion;
    [SerializeField] ParticleSystem psLargeMetal;
    [SerializeField] ParticleSystem psSmallMetal;

    [Header("Sound")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clipHurt;
    [SerializeField] AudioClip clipShoot;
    [SerializeField] AudioClip clipDestroy;


    internal void TroopDestroy(Vector3 pos)
    {
        psSmoke.transform.position = pos;
        psBlood.transform.position = pos;
        psSmallMetal.transform.position = pos;

        psSmoke.Play();
        psBlood.Play();
        psSmallMetal.Play();
        audioSource.PlayOneShot(clipHurt);
    }

    internal void HelicopterDestroy(Vector3 pos)
    {
        psSmoke.transform.position = pos;
        psDestroy.transform.position = pos;
        psExplosion.transform.position = pos;
        psLargeMetal.transform.position = pos;

        psSmoke.Play();
        psDestroy.Play();
        psExplosion.Play();
        psLargeMetal.Play();
        audioSource.PlayOneShot(clipDestroy);
    }

    internal void TurretDestroy(Vector3 pos)
    {
        psSmoke.transform.position = pos;
        psDestroy.transform.position = pos;
        psSmallMetal.transform.position = pos;

        psSmoke.Play();
        psDestroy.Play();
        psSmallMetal.Play();
        audioSource.PlayOneShot(clipDestroy);
    }

    internal void Shoot()
    {
        audioSource.PlayOneShot(clipShoot);
    }
}