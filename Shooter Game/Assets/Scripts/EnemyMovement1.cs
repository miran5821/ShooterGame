using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    public GameObject enemyBullet, bulletSpawnerPosition;
    public float nextShoot = 0.5f;
    float timer;

    public GameObject explosion;
   public AudioClip deathSound;

    public Transform startPosition,pos1,pos2;
    Vector3 nextPos;
    public float speed;
    void Start()
    {
        nextPos = startPosition.position;
    }

   
    void Update()
    {
        timer += Time.deltaTime;

        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        else if (transform.position== pos2.position)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos , speed * Time.deltaTime);

        if (timer > nextShoot)
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
            Destroy(creatObj, 1f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
      
    }
}
