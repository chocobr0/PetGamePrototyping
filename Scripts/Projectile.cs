using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    private Renderer projectileRenderer;

    void Start()
    {
        projectileRenderer = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0, Camera.main.transform);
    }

}
