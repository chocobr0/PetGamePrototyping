using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    public Renderer sky;
    public Renderer distantMountains;
    public Renderer mountains;
    public Renderer distantTrees;
    public float skySpeed = 0.02f;
    public float distantMountainsSpeed = 0.03f;
    public float mountainsSpeed = 0.04f;
    public float distantTreesSpeed = 0.05f;
    public float offset = 0.0f;

    void Update()
    {
        float skyOffset = offset * skySpeed;
        float distantMountainsOffset = offset * distantMountainsSpeed;
        float mountainsOffset = offset * mountainsSpeed;
        float distantTreesOffset = offset * distantTreesSpeed;

        sky.material.mainTextureOffset = new Vector2(skyOffset, 0);
        distantMountains.material.mainTextureOffset = new Vector2(distantMountainsOffset, 0);
        mountains.material.mainTextureOffset = new Vector2(mountainsOffset, 0);
        distantTrees.material.mainTextureOffset = new Vector2(distantTreesOffset, 0);

    }
}
