using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

    [SerializeField]private AudioSource jumpSound;
    [SerializeField]public AudioSource deathSound;

    private UnityEngine.Object explosion; 
    
    public float force;

    Rigidbody2D PlaneRigid;

    public GameObject RestartButton; 
    void Start()
    {
        Time.timeScale = 0;
        PlaneRigid = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
        deathSound = GetComponent<AudioSource>();
        explosion = Resources.Load("Explosion");       
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaneRigid.velocity = Vector2.up * force;
            jumpSound.Play();
            Time.timeScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  
    {

        if (collision.collider.tag == "Enemy")         
        {                     
            GameObject explosionRef =(GameObject)Instantiate(explosion);
            explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            RestartButton.SetActive(true);
            deathSound.Play(); 
            Destroy(gameObject);
        }

    }    
}
