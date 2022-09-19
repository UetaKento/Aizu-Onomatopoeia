using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandTouchEffect : MonoBehaviour
{
    private bool isMouseEnter = false;
    public Canvas canvas;
    public Text targetText;

    private Vector3 beforeMousePosition;
    private Vector3 afterMousePosition;

    private float hideThreshold; //マウスが動かなくなったらTime.deltaTimeでこの値が蓄積していき、特定の値より大きくなったらTextを隠す。

    // Start is called before the first frame update
    void Start()
    {
        beforeMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        //afterMousePosition = Input.mousePosition;
        //if (isMouseEnter)
        //{
        //    if (beforeMousePosition != afterMousePosition)
        //    {
        //        DisplayText("見える化！");
        //        Debug.Log("beforeMousePosition " + beforeMousePosition + " / " + "afterMousePosition " + afterMousePosition);
        //    }
        //    else
        //    {
        //        DisplayText(" ");
        //    }
        //}
        //else
        //{

        //}
        //beforeMousePosition = afterMousePosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit!!!");
        foreach (ContactPoint point in collision.contacts)
        {
            //衝突位置
            Debug.Log(point);
        }
    }

    private void OnCollisionStay(Collision collision)
    {

    }

    private void DisplayText(string inputText)
    {
        Vector2 MousePos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.GetComponent<RectTransform>(),
            Input.mousePosition,
            canvas.worldCamera,
            out MousePos);

        targetText.GetComponent<RectTransform>().anchoredPosition = new Vector2(
            MousePos.x,
            MousePos.y);
        targetText.text = inputText;
    }
}
