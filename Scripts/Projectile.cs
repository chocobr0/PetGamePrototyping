using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    private Renderer projectileRenderer;


    // Start is called before the first frame update
    void Start()
    {
        projectileRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0, Camera.main.transform);

        // Destroys projectile if off screen
        //if (!projectileRenderer.isVisible)
            //Destroy(gameObject); // !!! MAKE THIS WORK IDSGJASGDSG !!!
    }

}
