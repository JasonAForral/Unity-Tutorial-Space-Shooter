using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
    public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
    public string textureName = "_MainTex";
    private Renderer renderer;

    public Vector2 uvOffset = Vector2.zero;

    public static BGScroller instance;

    void Start ()
    {
        checkSingleton();
        DontDestroyOnLoad(this);
    

        renderer = GetComponent<Renderer>();
    }

    void checkSingleton ()
    {
        if (null == instance)
        {
            instance = this;
        }
        else //if (this != instance)
            Destroy(this);

    }

    void LateUpdate ()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime);
        if (renderer.enabled)
        {
            renderer.sharedMaterials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }

    void OnDisable ()
    {
        checkSingleton();
    }
}