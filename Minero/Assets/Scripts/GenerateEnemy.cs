using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public GameObject theEnemy;
    public Transform EnemyHolder;
    public int xPos;
    public int zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount < 5)
        {
            xPos = Random.Range(-10, 7);
            zPos = Random.Range(17, 24);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity,EnemyHolder);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
