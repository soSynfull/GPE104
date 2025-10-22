using UnityEngine;

public class Bullet : MonoBehaviour
{
    //This is being utilized if a game object is classified as a bullet
    public DamageOnCollision damageOnCollisionComponent;
    public BulletMover bulletMoverComponent;

    public void Awake()
    {
        //Load our Component Variables
        damageOnCollisionComponent = GetComponent<DamageOnCollision>();
        bulletMoverComponent = GetComponent<BulletMover>();
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
