using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] fruits;
    public float timespwan = 5;
    public float repetarSpawntime = 10;
    public Transform arist1;
    public Transform arist2;
    public Transform arist3;
    public Transform arist4;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spwanFruits",timespwan,repetarSpawntime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void spwanFruits(){
        UnityEngine.Vector3 spawnPosition = new UnityEngine.Vector3(0,0,0);
        spawnPosition = new UnityEngine.Vector3(Random.Range(arist1.position.x,arist2.position.x),Random.Range(arist3.position.y,arist4.position.y),0);

        GameObject fruit = Instantiate(fruits[Random.Range(0,fruits.Length)],spawnPosition,gameObject.transform.rotation);
    }
}
