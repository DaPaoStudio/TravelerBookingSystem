using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTrack : MonoBehaviour
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
        parent = GameObject.Find("TrackContent");
        contentSize = parent.GetComponent<RectTransform>().sizeDelta;
        itemHeight = item.GetComponent<RectTransform>().rect.height;
        itemLocalPos = item.transform.localPosition;
    }

    //添加列表项
    public static void AddItemTrack(Tracks track, int index)
    {
        GameObject gameobject = Instantiate(item);
        gameobject.transform.Find("Num").GetComponent<Text>().text = index.ToString();
        gameobject.transform.Find("FlightNum").GetComponent<Text>().text = track.FlightNumText;
        gameobject.transform.Find("Price").GetComponent<Text>().text = track.PriceText;
        gameobject.transform.Find("Time").GetComponent<Text>().text = track.TimeText;
        gameobject.transform.Find("City").GetComponent<Text>().text = track.CityText;
        gameobject.GetComponent<Transform>().SetParent(parent.GetComponent<Transform>(), false);
        gameobject.transform.localPosition = new Vector3(itemLocalPos.x, itemLocalPos.y - items.Count * itemHeight, 0);
        items.Add(gameobject);

        if (contentSize.y <= items.Count * itemHeight)//增加Content的高度
        {
            parent.GetComponent<RectTransform>().sizeDelta = new Vector2(contentSize.x, items.Count * itemHeight);
        }
    }
}
