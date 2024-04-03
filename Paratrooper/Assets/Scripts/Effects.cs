using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] ParticleSystem psFall;
    [SerializeField] ParticleSystem psSmoke;
    [SerializeField] ParticleSystem psBlood;
    [SerializeField] ParticleSystem psDestroy;
    [SerializeField] ParticleSystem psExplosion;
    [SerializeField] ParticleSystem psLargeMetal;
    [SerializeField] ParticleSystem psSmallMetal;


    internal void TroopDestroy(Vector3 pos)
    {
        psSmoke.transform.position = pos;
        psBlood.transform.position = pos;
        psSmallMetal.transform.position = pos;

        psSmoke.Play();
        psBlood.Play();
        psSmallMetal.Play();
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
    }
}