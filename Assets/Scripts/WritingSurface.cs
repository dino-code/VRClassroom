using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WritingSurface : MonoBehaviour
{
    private int textureSize = 2048;
    private int penSize = 10;
    private Texture2D texture;
    private Color[] color;

    private bool touching, touchingLast;
    private float posX, posY, lastX, lastY;
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        this.texture = new Texture2D(textureSize, textureSize);
        renderer.material.mainTexture = this.texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (touching == true)
        {
            Debug.Log(posX);
        }
    }
}
