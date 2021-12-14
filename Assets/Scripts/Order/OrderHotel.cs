using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class OrderHotel : MonoBehaviour
{
    public Dropdown dropDownHotels, dropDownCustomers;
    public Text hotelName, starLevel, price, rooms;
    public Hotels hotel;
    public Customers customer;
    void Start()
    {
        dropDownHotels = transform.Find("HotelLocation").GetComponent<Dropdown>();
        dropDownCustomers = transform.Find("CustomerName").GetComponent<Dropdown>();
        hotelName = transform.Find("Name").GetComponent<Text>();
        starLevel = transform.Find("StarLevel").GetComponent<Text>();
        price = transform.Find("Price").GetComponent<Text>();
        rooms = transform.Find("Rooms").GetComponent<Text>();
        hotel = new Hotels();
        customer = new Customers();
        SelectHotelLocationInHotels();
        SelectCustNameInCustomers();
    }

    void SelectHotelLocationInHotels()
    {
        List<string> hotelInf = new List<string>();
        DataSet ds = MySQLManager.ExecuteQuery("SELECT location From hotels;");

        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    hotelInf.Add(row[column] + "");
                }
            }
        }

        UIOrder.UpdateDropDown(dropDownHotels, hotelInf);
        OnValueChangedHotelLocation();
    }

    void SelectCustNameInCustomers()
    {
        List<string> custName = new List<string>();
        DataSet ds = MySQLManager.ExecuteQuery("SELECT custName From customers;");

        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    custName.Add(row[column] + "");
                }
            }
        }
        UIOrder.UpdateDropDown(dropDownCustomers, custName);
        OnValueChangedCustomerName();
    }

    public void UpdateFlightInformation()
    {
        DataSet ds = MySQLManager.ExecuteQuery("SELECT * From hotels WHERE location = '" + dropDownHotels.captionText.text + "'");//读取表
        List<string> hotelInf = new List<string>();
        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    hotelInf.Add(row[column] + "");
                }
            }
        }
        Hotels hotelItem = new Hotels(hotelInf);
        hotelName.text = hotelItem.NameText;
        starLevel.text = hotelItem.StarLevelText;
        price.text = hotelItem.PriceText;
        rooms.text = "剩余房间：" + hotelItem.RoomsText;
    }

    public void OnValueChangedHotelLocation()
    {
        UpdateFlightInformation();
        hotel.location = dropDownHotels.captionText.text;
    }

    public void OnValueChangedCustomerName()
    {
        customer.custName = dropDownCustomers.captionText.text;
    }

    public void OnBtnOrderHotel()
    {
        MySQLManager.ExecuteQuery("INSERT INTO reservations(custName, resvType, resvName) VALUES ('" + customer.custName + "'" + ", 2 ,'" + hotel.location + "');");
        if (StaticData.isError == false)
        {
            UIOrder.EventOrderSuccess();
        }
    }
}
