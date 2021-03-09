using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveText : MonoBehaviour
{
    public GameObject enemyHolder;
    private Text changingText;
    private int index;
    void Start()
    {
        changingText = GameObject.Find("Canvas/Text").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        index = enemyHolder.GetComponent<WaveSpawner>().nextWave;
        changingText.text = enemyHolder.GetComponent<WaveSpawner>().wave[index].name;
    }
}
