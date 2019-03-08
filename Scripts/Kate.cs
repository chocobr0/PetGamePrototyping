using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kate : MonoBehaviour
{

    public float speed;
    public float seperationDistance;
    private Transform playerTransform;
    private Animator animator;
    private float timeBtwShots;
    public float startTimeBtwnShots;
    //public GameObject projectile;
    public bool visibility;
    private Renderer kateRenderer;

    public float GetSpeed()
    {
        return speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        kateRenderer = gameObject.GetComponent<Renderer>();
        //timeBtwShots = startTimeBtwnShots;
    }

    // Update is called once per frame
    void Update()
    {
        // Distance between Kate and User
        seperationDistance = (transform.position - playerTransform.position).magnitude;
        DemonAnimSetter(seperationDistance);
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed*Time.deltaTime);
    }

    // Conditionals to change anim the closer Kate gets to User
    void DemonAnimSetter(float currentDistanceApart)
    {
        if(currentDistanceApart < 4)
        {
            animator.SetBool("is2Close", true);
        }
        else
        {
            animator.SetBool("is2Close", false);
        }
    }

}
