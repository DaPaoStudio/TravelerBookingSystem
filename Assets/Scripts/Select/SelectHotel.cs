using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class SelectHotel : MonoBehaviour
{
    public InputField inputHotelLocation;
    public Hotels hotel;
    public static List<Hotels> hotelList;

    void Start()
    {
        inputHotelLocation = transform.Find("HotelLocationInput").GetComponent<InputField>();
        hotel = new Hotels();
    }

    public void OnEndEditHotelLocation()
    {
        hotel.location = inputHotelLocation.text;
    }

    public void OnBtnSelectHotel()
    {
        SelectHotelLocationInHotels();
        ItemHotel.DestoryAllItem();
        for (int i = 0; i < hotelList.Count; i++)
        {
            ItemHotel.AddItemHotel(hotelList[i], i + 1);
        }
    }

    public void OnBtnSelectAll()
    {
        SelectAllHotels();
        ItemHotel.DestoryAllItem();
        for (int i = 0; i < hotelList.Count; i++)
        {
            ItemHotel.AddItemHotel(hotelList[i], i + 1);
        }
    }

    void SelectHotelLocationInHotels()
    {
        List<string> hotelInf;
        hotelList = new List<Hotels>();
        DataSet ds = MySQLManager.ExecuteQuery("SELECT * FROM hotels WHERE location = '" + hotel.location + "';");
        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                hotelInf = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    hotelInf.Add(row[column] + "");
                }
                Hotels hotelItem = new Hotels(hotelInf);
                hotelList.Add(hotelItem);
            }
        }
    }

    void SelectAllHotels()
    {
        List<string> hotelInf;
        hotelList = new List<Hotels>();
        DataSet ds = MySQLManager.ExecuteQuery("SELECT * FROM hotels;");
        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                hotelInf = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    hotelInf.Add(row[column] + "");
                }
                Hotels hotelItem = new Hotels(hotelInf);
                hotelList.Add(hotelItem);
            }
        }
    }
}
