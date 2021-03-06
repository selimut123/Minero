using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AE_ArrowAttack()
    {
        pc.AE_FireArrow();
    }
}
