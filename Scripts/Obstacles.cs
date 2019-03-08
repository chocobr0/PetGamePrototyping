using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private GameObject obstacle;
    private Transform playerTransform;
    private Rigidbody2D playerRBody;
    private Transform demonTransform;
    private float distanceBetweenDemonAndPlayer;
    private Renderer demonRenderer;
    private Renderer obstacleRenderer;
    private Collider2D obstacleCollider;
    public bool isPlayerColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerRBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        demonTransform = GameObject.FindGameObjectWithTag("Kate").GetComponent<Transform>();
        demonRenderer = GameObject.FindGameObjectWithTag("Kate").GetComponent<Renderer>();

        obstacleRenderer = GetComponent<Renderer>();
        obstacleCollider = GetComponent<Collider2D>();
        obstacleRenderer.enabled = false;
        obstacleCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetweenDemonAndPlayer = (demonTransform.position - playerTransform.position).magnitude;
        //If Demon is off screen or too close to Player then enable obstacles
        if ((!demonRenderer.isVisible) || (distanceBetweenDemonAndPlayer < 4) || (distanceBetweenDemonAndPlayer > 7))
        {
            obstacleRenderer.enabled = true;
            obstacleCollider.enabled = true;
        }
        else
        {
            obstacleRenderer.enabled = false;
            obstacleCollider.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        isPlayerColliding |= Col.gameObject.tag == "Player"; 
        playerRBody.drag = 700;
    }

    void OnCollisionExit2D(Collision2D Col)
    {
        isPlayerColliding |= Col.gameObject.tag == "Player";
        playerRBody.drag = 0;
    }
}
