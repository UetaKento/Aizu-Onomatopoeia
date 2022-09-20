using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandTouchEffect : MonoBehaviour
{
    //public Canvas overrayCanvas;
    [SerializeField]
    Camera targetCamera;
    [SerializeField]
    private Text targetText;
    [SerializeField]
    private string displayWord = "ツルツル";
    [SerializeField]
    private int scaleupRatio = 10000;

    private float hideThreshold; //マウスが動かなくなったらTime.deltaTimeでこの値が蓄積していき、特定の値より大きくなったらTextを隠す。

    // Start is called before the first frame update
    void Start()
    {
        if (scaleupRatio < 0 || targetText == null)
        {
            Debug.Log("初期化失敗");
            return;
        }
        targetText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint point in collision.contacts)
        {
            Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(
                targetCamera,
                point.point
                );

            //ハンドトラッキングで手が動いている座標は非常に小さな値なので、screenPosも小さな値になってしまう。なので * scaleupRatioをする必要あり。
            targetText.GetComponent<RectTransform>().anchoredPosition = new Vector2(
            screenPos.x * scaleupRatio,
            screenPos.y * scaleupRatio);

            targetText.text = displayWord;

        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    targetText.text = "";
    //}

}
