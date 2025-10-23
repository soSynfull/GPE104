using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Bullet bulletToShoot;
    public Transform firePoint;
    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
       if (bulletToShoot == null)
        {
            Debug.LogError("Bullet prefab is not assigned");
            return;
        }

       if (firePoint == null)
        {
            Debug.LogError("FirePoint is not assigned!");
            return;
        }

        Instantiate(bulletToShoot, firePoint.position, firePoint.rotation);
    }

    public void Shoot(Bullet bulletToShoot)
    {

        //Instantiate the bullet we plan to shoot
        Bullet theBullet = Instantiate<Bullet>(bulletToShoot, firePoint.position, firePoint.rotation );

        audioSource.Play();
    }
    
}
