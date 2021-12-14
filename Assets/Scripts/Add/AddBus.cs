using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBus : MonoBehaviour
{
    public InputField inputBusLocation, inputBusPrice, inputBusName, inputBusSeats;
    public Buses bus;
    void Awake()
    {
        inputBusLocation = transform.Find("BusLocation").GetComponent<InputField>();
        inputBusPrice = transform.Find("BusPrice").GetComponent<InputField>();
        inputBusName = transform.Find("BusName").GetComponent<InputField>();
        inputBusSeats = transform.Find("BusSeats").GetComponent<InputField>();
        bus = new Buses();
    }

    public void OnEndEditLocation()
    {
        bus.location = inputBusLocation.text;
    }

    public void OnEndEditPrice()
    {
        bus.price = inputBusPrice.text;
    }

    public void OnEndEditName()
    {
        bus.name = inputBusName.text;
    }

    public void OnEndEditNums()
    {
        bus.numBus = inputBusSeats.text;
        bus.numAvail = inputBusSeats.text;
    }

    public void OnBtnAdd()
    {
        if (bus.location != null)
        {
            MySQLManager.ExecuteQuery("INSERT INTO bus VALUES " +
                "('" + bus.location + "',"
                + "'" + bus.name + "',"
                + bus.price + ","
                + bus.numBus + ","
                + bus.numAvail + ");"
                );
            if (StaticData.isError == false)
            {
                UIInput.EventAddSuccess();
            }
        }
    }
}
