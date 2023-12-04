using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControl : MonoBehaviour
{
    private MeshRenderer mr;
    private Material mater;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mater = mr.material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offsetM = mater.mainTextureOffset;
        offsetM.x = transform.position.x;
        offsetM.y = transform.position.y;
            mater.mainTextureOffset = offsetM;
        
    }
}
