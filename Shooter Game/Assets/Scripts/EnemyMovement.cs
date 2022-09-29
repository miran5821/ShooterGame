using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public GameObject enemyBullet, bulletSpawnerPosition;
    public float nextShoot = 0.5f;
    float timer;

    public GameObject explosion;

   public AudioClip deathSound;

    void Start()
    {
        
    }

   
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        if (timer>nextShoot)
        {
            EnemyShoot();
        }
    }
    void EnemyShoot()
    {
        Instantiate(enemyBullet, bulletSpawnerPosition.transform.position, Quaternion.identity);
        timer = 0;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject creatObj = Instantiate(explosion, transform.position, Quaternion.identity);
            ScoreManager.score += 10;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Destroy(creatObj, 2f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
