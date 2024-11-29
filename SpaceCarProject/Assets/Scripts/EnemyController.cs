using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody enemyRigidbody;
    bool isEnemyShipActive; //isEnemeyShipActive ile uzay aracına enemy veya top geldiginde durar ve bir daha gelmez. Yani ust uste yenilmis olmayiz.

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        isEnemyShipActive = true;
    }

    void Start()
    {
        enemyRigidbody.velocity = Vector3.back * 30;
        Destroy(gameObject, 2.5f);
    }

    void Update()
    {
        
    }


    //Bu metot ile üretilen dusman gemilerin finish wall'a degdiginde yok olmasini sagladik
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet") 
        {
            GameManager.instance.IncreaseScore();
            isEnemyShipActive = false;
            Destroy(collision.gameObject); //Degen gameObject'i yok eder, burada game object mermi bullet
        }
        if(collision.gameObject.tag == "SpaceShip" && isEnemyShipActive == true)
        {
            isEnemyShipActive = false;
            GameManager.instance.SpaceShipGotShoot();
        }
    }
}
