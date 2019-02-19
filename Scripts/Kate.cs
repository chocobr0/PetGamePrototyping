using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kate : MonoBehaviour
{

    public float speed;
    public float seperationDistance;
    private Transform target;
    private Animator animator;
    private float timeBtwShots;
    public float startTimeBtwnShots;
    public GameObject projectile;
    public bool visibility;
    private Renderer kateRenderer;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        kateRenderer = gameObject.GetComponent<Renderer>();
        timeBtwShots = startTimeBtwnShots;
    }

    // Update is called once per frame
    void Update()
    {
        // Distance between Kate and User
        seperationDistance = (transform.position - target.position).magnitude;
        DemonAnimSetter(seperationDistance);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
       
        if (timeBtwShots <= 0)
        {
            if(!kateRenderer.isVisible)
                Instantiate(projectile, transform.position, Quaternion.identity);

            timeBtwShots = startTimeBtwnShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }

    // Conditionals to change anim the closer Kate gets to User
    void DemonAnimSetter(float currentDistanceApart)
    {
        if(currentDistanceApart < 4) // !!! THESE CONDITIONALS NEED TO BE MORE DYNAMIC OR IMA SPANK U !!!
        {
            animator.SetBool("is2Close", true);
            animator.SetBool("is3Close", false);
        }
        //else if(currentDistanceApart < 3)
        //{
        //    animator.SetBool("is3Close", true);
        //}
        else
        {
            animator.SetBool("is2Close", false);
        }
    }

}
