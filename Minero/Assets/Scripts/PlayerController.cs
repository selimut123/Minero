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

    public GameObject EnemyHolder;

    public List<EnemyHealth> enemies = new List<EnemyHealth>();

    public List<GameObject> Bullets = new List<GameObject>();

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        joysticks = FindObjectOfType<FixedJoystick>();
        anim = GetComponentInChildren<Animator>();

        for (int i = 0; i < EnemyHolder.transform.childCount; i++)
        {
            enemies.Add(EnemyHolder.transform.GetChild(i).GetComponent<EnemyHealth>());
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (joysticks.Horizontal != 0 || joysticks.Vertical != 0)
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

    public void AE_AutoTargetEnemy()
    {
        if(enemies.Count != 0)
        {
            for(int j = 0; j < enemies.Count; j++)
            {
                if (enemies[j] == null)
                {
                    enemies.RemoveAt(j);
                }
            }
        }

        if(enemies.Count != 0)
        {
            //float distance = Vector3.Distance(transform.position, enemies[0].gameObject.transform.position);

            for (int i = 0; i < enemies.Count; i++)
            {
                target = enemies[i].gameObject;
                //if (Vector3.Distance(transform.position, enemies[i].gameObject.transform.position) < distance)
                //{
                //distance = Vector3.Distance(transform.position, enemies[i].gameObject.transform.position);
                //}
            }
            transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));

        }
    }

}
