using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject Pipes;        

    void Start()
    {
        StartCoroutine(Spawner());   
    }

    IEnumerator Spawner()           
    {
        while (true)               
        {
            yield return new WaitForSeconds(1);     
            float rand = Random.Range(-1f, 3.5f);     
            GameObject newPipes = Instantiate(Pipes, new Vector3(2, rand, 0), Quaternion.identity);     
            Destroy(newPipes, 10);  
        }
    }

}
