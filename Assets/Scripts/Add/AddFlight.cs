using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddFlight : MonoBehaviour
{
    public InputField inputFlightNum, inputFlightPrice, inputFlightFromCity, inputFlightArivCity;
    public InputField inputFlightTakeOffTime, inputFlightLandOnTime, inputFlightSeats;
    public Flights flight;
    void Awake()
    {
        inputFlightNum = transform.Find("FlightNum").GetComponent<InputField>();
        inputFlightPrice = transform.Find("FlightPrice").GetComponent<InputField>();
        inputFlightFromCity = transform.Find("FlightFromCity").GetComponent<InputField>();
        inputFlightArivCity = transform.Find("FlightArivCity").GetComponent<InputField>();
        inputFlightTakeOffTime = transform.Find("FlightTakeOffTime").GetComponent<InputField>();
        inputFlightLandOnTime = transform.Find("FlightLandOnTime").GetComponent<InputField>();
        inputFlightSeats = transform.Find("FlightSeats").GetComponent<InputField>();
        flight = new Flights();
    }

    public void OnEndEditFlightNum()
    {
        flight.flightNum = inputFlightNum.text;
    }

    public void OnEndEditPrice()
    {
        flight.price = inputFlightPrice.text;
    }

    public void OnEndEditFromCity()
    {
        flight.fromCity = inputFlightFromCity.text;
    }

    public void OnEndEditArivCity()
    {
        flight.arivCity = inputFlightArivCity.text;
    }
    public void OnEndEditTakeOffTime()
    {
        flight.takeOffTime = inputFlightTakeOffTime.text;
    }

    public void OnEndEditLandOnTime()
    {
        flight.landOnTime = inputFlightLandOnTime.text;
    }

    public void OnEndEditSeats()
    {
        flight.numSeats = inputFlightSeats.text;
        flight.numAvail = inputFlightSeats.text;
    }

    public void OnBtnAdd()
    {
        if (flight.flightNum != null)
        {
            MySQLManager.ExecuteQuery("INSERT INTO flights VALUES " +
                "('" + flight.flightNum + "',"
                + flight.price + ","
                + flight.numSeats + ","
                + flight.numAvail + ","
                + "'" + flight.takeOffTime + "',"
                + "'" + flight.landOnTime + "',"
                + "'" + flight.fromCity + "',"
                + "'" + flight.arivCity + "');");
            if (StaticData.isError == false)
            {
                UIInput.EventAddSuccess();
            }
        }
    }
}
