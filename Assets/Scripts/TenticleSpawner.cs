using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenticleSpawner : MonoBehaviour
{
    public float waitTime = 5;

    public float minWaitTime = 3;
    public float maxWaitTime = 10;
    
    public GameObject tenticlePrefab;
    
    void Start()
    {
        StartCoroutine(SpawnTenticle());
    }
    
    IEnumerator SpawnTenticle()
    {
        yield return new WaitForSeconds(waitTime);
        while (true)
        {
            var position = new Vector3();
            position.x = Random.Range(-50, 50);
            position.z = Random.Range(-50, 50);
            position.y = transform.position.y;
            
            //spawn tenticle
            Instantiate(tenticlePrefab, position, Quaternion.identity);
            
            //set new wait time
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        }
    }
}
