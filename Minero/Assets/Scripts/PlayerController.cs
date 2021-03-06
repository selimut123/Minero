using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController cc;
    FixedJoystick joysticks;
    [SerializeField] float speed = 500;

    Animator anim;

    public GameObject ArrowPoint;
    public GameObject ArrowPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        joysticks = FindObjectOfType<FixedJoystick>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(joysticks.Horizontal != 0 || joysticks.Vertical != 0)
        {
            Vector3 pos = new Vector3(joysticks.Horizontal, -9.8f * Time.deltaTime, joysticks.Vertical);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(pos.x, 0, pos.z)), 2);
            cc.SimpleMove(pos * speed);
            if(anim.GetBool("isRunning") == false)
            {
                anim.SetBool("isRunning", true);
            }
            if (anim.GetBool("IsAttacking") == true)
            {
                anim.SetBool("IsAttacking", false);
            }
        }
        else
        {
            if (anim.GetBool("isRunning") == true)
            {
                anim.SetBool("isRunning", false);
            }
            if (anim.GetBool("IsAttacking") == false)
            {
                anim.SetBool("IsAttacking", true);
            }
        }
    }

    public void AE_FireArrow()
    {
        GameObject ArrowObj = Instantiate(ArrowPrefab, ArrowPoint.transform.position, ArrowPoint.transform.rotation);
    }

}
