using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddHotel : MonoBehaviour
{
    public InputField inputHotelLocation, inputHotelPrice, inputHotelName, inputRooms;
    public Hotels hotel;
    void Awake()
    {
        inputHotelLocation = transform.Find("HotelLocation").GetComponent<InputField>();
        inputHotelPrice = transform.Find("HotelPrice").GetComponent<InputField>();
        inputHotelName = transform.Find("HotelName").GetComponent<InputField>();
        inputRooms = transform.Find("HotelRooms").GetComponent<InputField>();
        hotel = new Hotels();
        hotel.starLevel = "¡î¡î¡î¡î¡î";
    }

    public void OnEndEditLocation()
    {
        hotel.location = inputHotelLocation.text;
    }

    public void OnEndEditPrice()
    {
        hotel.price = inputHotelPrice.text;
    }

    public void OnEndEditName()
    {
        hotel.name = inputHotelName.text;
    }

    public void OnEndEditNums()
    {
        hotel.numRooms = inputRooms.text;
        hotel.numAvail = inputRooms.text;
    }

    public void OnBtnAdd()
    {
        if (hotel.location != null)
        {
            MySQLManager.ExecuteQuery("INSERT INTO hotels VALUES " +
                "('" + hotel.location + "',"
                + "'" + hotel.name + "',"
                + "'" + hotel.starLevel + "',"
                + hotel.price + ","
                + hotel.numRooms + ","
                + hotel.numAvail + ");"
                );
            if (StaticData.isError == false)
            {
                UIInput.EventAddSuccess();
            }
        }
    }
}
