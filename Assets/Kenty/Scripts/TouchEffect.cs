using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffect : MonoBehaviour
{
    private bool isMouseEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseEnter)
        {
            this.gameObject.GetComponent<Renderer>().material.color += new Color(-0.01f, -0.01f, -0.01f, 0);
            Debug.Log("マウスは中にある\n");
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material.color -= new Color(-0.01f, -0.01f, -0.01f, 0);
            Debug.Log("マウスは外にある\n");
        }
    }
    private void OnMouseEnter()
    {
        isMouseEnter = true;
    }

    private void OnMouseExit()
    {
        isMouseEnter = false;
    }
}
