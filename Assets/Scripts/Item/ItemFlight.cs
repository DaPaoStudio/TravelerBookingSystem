using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFlight : MonoBehaviour
{
    static List<GameObject> items = new List<GameObject>();
    public static GameObject item;
    static GameObject parent;
    static Vector3 itemLocalPos;
    static Vector2 contentSize;
    static float itemHeight;

    void Awake()
    {
        item = GameObject.Find("Flight");
        parent = GameObject.Find("FlightContent");
        contentSize = parent.GetComponent<RectTransform>().sizeDelta;
        itemHeight = item.GetComponent<RectTransform>().rect.height;
        itemLocalPos = item.transform.localPosition;
    }

    void OnEnable()
    {
        Awake();
    }

    //添加列表项
    public static void AddItemFlight(Flights flight, int index)
    {
        GameObject gameobject = Instantiate(item);
        gameobject.transform.Find("Num").GetComponent<Text>().text = index.ToString();
        gameobject.transform.Find("FlightNum").GetComponent<Text>().text = flight.FlightNumText;
        gameobject.transform.Find("Price").GetComponent<Text>().text = flight.PriceText;
        gameobject.transform.Find("Time").GetComponent<Text>().text = flight.TimeText;
        gameobject.transform.Find("City").GetComponent<Text>().text = flight.CityText;
        gameobject.transform.Find("Seats").GetComponent<Text>().text = flight.SeatsText;
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
            Destroy(go);
        }
        items.Clear();
    }
}
