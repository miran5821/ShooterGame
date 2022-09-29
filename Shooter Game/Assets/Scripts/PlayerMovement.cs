using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float minX, maxX, minZ, maxZ;
    public GameObject bullet, bulletSpawnerPosition;

    public GameObject explosion;

    public float nextShoot = 0.5f;
    float timer;

    public Transform playerTransform;

    public GameObject gameOverImage, gameOverText,restartBtn,menuBtn,hightScoreText,hightScoreValue;

    AudioSource audioSource;
   public AudioClip deathSound;

    CameraFollow cam;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }
    // scripti kalıyordu onu yok etmek için yazdım
    // find dışında bişey gelmedi aklıma sonra sövme bana

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.Translate(horizontal * Time.deltaTime * speed, 0, vertical * Time.deltaTime * speed);

        transform.position = new Vector3(Mathf.Clamp(playerTransform.position.x, minX, maxX), transform.position.y,Mathf.Clamp(playerTransform.position.z,minZ,maxZ));

        if (Input.GetButton("Fire1") && timer>nextShoot) // sürekliliği olursa değiştir
        {
            Shoot();
        }
        
    }
    void Shoot()
    {
        Instantiate(bullet, bulletSpawnerPosition.transform.position, Quaternion.identity);
        audioSource.Play();
        timer = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
          GameObject creatObj =  Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(creatObj, 2f);
            gameOverImage.SetActive(true);
            gameOverText.SetActive(true);
            restartBtn.SetActive(true);
            menuBtn.SetActive(true);
            hightScoreText.SetActive(true);
            hightScoreValue.SetActive(true); 
            AudioSource.PlayClipAtPoint(deathSound, transform.position);   
            cam.enabled = false;
            Destroy(other.gameObject);
            Destroy(gameObject);
            Time.timeScale = 0;
        }
       
    }
}
