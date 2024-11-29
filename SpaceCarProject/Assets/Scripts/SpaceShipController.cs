using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    Vector3 firstPos;
    Vector3 lastPos;
    float movingSidesSpeed = 0.07f;
    float maxPosition = 7.51f;
    public GameObject bullet;
    public Transform bulletPoint;
    bool isShootingOn;
    private float bulletSpeed = 60f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   //GetMouseButton'ları yazarken parantez icinde 0 yazdik
   //0 - sol fare dumesi
   //1 - sag fare dumesi
   //2 - farenin tekerligi
    void Update()
    {
        //Eger shooting olmazsa geri doner ve calismaz
        if(isShootingOn == false)
        {
            return;
        }

        float xValue = 0;
        //Eger uzay aracina dokunursa koordinatlari al
        //Uzun tıklı oldugunda else if'e girer ve yeni koordinatları alır
        if (Input.GetMouseButtonDown(0)){
            firstPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            lastPos = Input.mousePosition;
            float difference = lastPos.x - firstPos.x;
            xValue = difference * movingSidesSpeed;
        }

        //Mouse'dan elini cektiginde koordinatlar sifirlanir

        if (Input.GetMouseButtonUp(0))
        {
            firstPos = Vector3.zero;
            lastPos = Vector3.zero;
            xValue = 0;
        }

        transform.Translate(xValue * Time.deltaTime, 0, 0);
        float newXValue = Mathf.Clamp(transform.position.x, -maxPosition, maxPosition);
        transform.position = new Vector3(newXValue, transform.position.y, transform.position.z);
    }

    //Mermi uretilir ve 3 saniye sonra yok edilir
    private void CreateBullet()
    {
        GameObject bulletGameObject = Instantiate(bullet, bulletPoint.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bulletGameObject.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = Vector3.forward * bulletSpeed; 
        Destroy(bulletGameObject, 3f);
    }

    IEnumerator SpawnBullets()
    {
        while (isShootingOn)
        {
            CreateBullet();
            yield return new WaitForSeconds(0.7f);
        }
    }

    public void StartSpaceShip()
    {
        isShootingOn = true;
        StartCoroutine(SpawnBullets());
    }

    public void StopSpaceShip()
    {
        isShootingOn = false;
    }
}
