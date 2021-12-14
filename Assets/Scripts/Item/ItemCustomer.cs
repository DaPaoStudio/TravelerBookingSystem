using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCustomer : MonoBehaviour
{
    static List<GameObject> items = new List<GameObject>();
    public static GameObject item;
    static GameObject parent;
    static Vector3 itemLocalPos;
    static Vector2 contentSize;
    static float itemHeight;

    void Start()
    {
        item = GameObject.Find("Customer");
        parent = GameObject.Find("CustomerContent");
        contentSize = parent.GetComponent<RectTransform>().sizeDelta;
        itemHeight = item.GetComponent<RectTransform>().rect.height;
        itemLocalPos = item.transform.localPosition;
    }

    //添加列表项
    public static void AddItemCustomer(Customers customer, int index)
    {
        GameObject gameobject = Instantiate(item);
        gameobject.transform.Find("Num").GetComponent<Text>().text = index.ToString();
        gameobject.transform.Find("Name").GetComponent<Text>().text = customer.custName;
        gameobject.transform.Find("ID").GetComponent<Text>().text = customer.custID;
        gameobject.GetComponent<Transform>().SetParent(parent.GetComponent<Transform>(), false);
        gameobject.transform.localPosition = new Vector3(itemLocalPos.x, itemLocalPos.y - items.Count * itemHeight, 0);
        items.Add(gameobject);

        if (contentSize.y <= items.Count * itemHeight)//增加Content的高度
        {
            parent.GetComponent<RectTransform>().sizeDelta = new Vector2(contentSize.x, items.Count * itemHeight);
        }
    }

    public static void DestoryAllItem()
    {
        foreach (GameObject go in items)
        {
            DestroyImmediate(go);
        }
        items.Clear();
    }
}
