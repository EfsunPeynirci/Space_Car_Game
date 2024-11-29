using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public GameObject enemyShip;
    public List <Transform> spawnPointList;
    public bool isEnemyShip;
    
    void Start()
    {
        
    }

    
    void Update()
    {

    }

    private void CreateEnemyShip()
    {
        //Random ile farkli yerlerden enemy ship controllerın gelmesini sagliyoruz.
        int randomNumber = Random.Range(0, spawnPointList.Count);
        //Instantiate ile Prefabs dosyasının altındaki objeden üretmemmizi sagliyor
        GameObject enemy = Instantiate(enemyShip, spawnPointList[randomNumber].position, Quaternion.identity);
    }

    //IEnumartor ve Courine ile belli zamanlar icinde uretim yapariz
    IEnumerator SpawnEnemyShip()
    {
        while (isEnemyShip)
        {
            CreateEnemyShip();
            yield return new WaitForSeconds(0.7f); //2 saniyede 1 enemy ship uretilir
        }
    }

    public void StartCreatingEnemyShip()
    {
        isEnemyShip = true;
        StartCoroutine(SpawnEnemyShip());
    }

    public void StopCreatingEnemyShip()
    {
        isEnemyShip = false;
    }
}
