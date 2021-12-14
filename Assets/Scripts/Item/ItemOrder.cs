using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOrder : MonoBehaviour
{
    static List<GameObject> items = new List<GameObject>();
    public static GameObject item;
    static GameObject parent;
    static Vector3 itemLocalPos;
    static Vector2 contentSize;
    static float itemHeight;

    void Start()
    {
        item = gameObject;
        parent = GameObject.Find("OrderContent");
        contentSize = parent.GetComponent<RectTransform>().sizeDelta;
        itemHeight = item.GetComponent<RectTransform>().rect.height;
        itemLocalPos = item.transform.localPosition;
    }

    //添加列表项
    public static void AddItemResv(Resvs resv, int index)
    {
        GameObject gameobject = Instantiate(item);
        //GameObject gameobject = Resources.Load("Prefabs/Order") as GameObject;
        gameobject.transform.Find("Num").GetComponent<Text>().text = index.ToString();
        gameobject.transform.Find("CustName").GetComponent<Text>().text = resv.CustNameText;
        gameobject.transform.Find("ResvType").GetComponent<Text>().text = resv.ResvTypeText;
        gameobject.transform.Find("ResvName").GetComponent<Text>().text = resv.ResvNameText;
        gameobject.transform.Find("ResvKey").GetComponent<Text>().text = resv.ResvKeyText;
        gameobject.GetComponent<Transform>().SetParent(parent.GetComponent<Transform>(), false);
        gameobject.transform.localPosition = new Vector3(itemLocalPos.x, itemLocalPos.y - items.Count * itemHeight, 0);
        items.Add(gameobject);

        if (contentSize.y <= items.Count * itemHeight)//增加Content的高度
        {
            parent.GetComponent<RectTransform>().sizeDelta = new Vector2(contentSize.x, items.Count * itemHeight);
        }
    }
}
