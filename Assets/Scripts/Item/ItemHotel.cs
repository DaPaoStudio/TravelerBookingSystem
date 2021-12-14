using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHotel : MonoBehaviour
{
    static List<GameObject> items = new List<GameObject>();
    public static GameObject item;
    static GameObject parent;
    static Vector3 itemLocalPos;
    static Vector2 contentSize;
    static float itemHeight;

    void Start()
    {
        item = GameObject.Find("Hotel");
        parent = GameObject.Find("HotelContent");
        contentSize = parent.GetComponent<RectTransform>().sizeDelta;
        itemHeight = item.GetComponent<RectTransform>().rect.height;
        itemLocalPos = item.transform.localPosition;
    }

    //����б���
    public static void AddItemHotel(Hotels hotel, int index)
    {
        GameObject gameobject = Instantiate(item);
        gameobject.transform.Find("Num").GetComponent<Text>().text = index.ToString();
        gameobject.transform.Find("Location").GetComponent<Text>().text = hotel.LocationText;
        gameobject.transform.Find("Price").GetComponent<Text>().text = hotel.PriceText;
        gameobject.transform.Find("Name").GetComponent<Text>().text = hotel.NameText;
        gameobject.transform.Find("StarLevel").GetComponent<Text>().text = hotel.StarLevelText;
        gameobject.transform.Find("Rooms").GetComponent<Text>().text = hotel.RoomsText;
        gameobject.GetComponent<Transform>().SetParent(parent.GetComponent<Transform>(), false);
        gameobject.transform.localPosition = new Vector3(itemLocalPos.x, itemLocalPos.y - items.Count * itemHeight, 0);
        items.Add(gameobject);

        if (contentSize.y <= items.Count * itemHeight)//����Content�ĸ߶�
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
