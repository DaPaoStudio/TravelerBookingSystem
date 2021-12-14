using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public bool isClick;
    public float deltaTime = 0;
    public float gapTime = 2f;

    //按钮2.5秒内只能点击一次 防止连续点击报错
    void Update()
    {
        if (isClick)
        {
            deltaTime += Time.unscaledDeltaTime;
            if (deltaTime > gapTime)
            {
                deltaTime = 0;
                GetComponent<Button>().interactable = true;
                isClick = false;
            }
        }
    }

    public void OnClick()
    {
        isClick = true;
        GetComponent<Button>().interactable = false;
    }
}
