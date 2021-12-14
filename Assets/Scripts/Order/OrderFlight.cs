using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class OrderFlight : MonoBehaviour
{
    public Dropdown dropDownFlights, dropDownCustomers;
    public Text time, city, price, seats;
    public Flights flight;
    public Customers customer;
    void Start()
    {
        dropDownFlights = transform.Find("FlightNum").GetComponent<Dropdown>();
        dropDownCustomers = transform.Find("CustomerName").GetComponent<Dropdown>();
        time = transform.Find("Time").GetComponent<Text>();
        city = transform.Find("City").GetComponent<Text>();
        price = transform.Find("Price").GetComponent<Text>();
        seats = transform.Find("Seats").GetComponent<Text>();
        flight = new Flights();
        customer = new Customers();
        SelectFlightNumInFlights();
        SelectCustNameInCustomers();
    }

    void SelectFlightNumInFlights()
    {
        List<string> flightNum = new List<string>();
        DataSet ds = MySQLManager.ExecuteQuery("SELECT flightNum From flights;");

        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    flightNum.Add(row[column] + "");
                }
            }
        }

        UIOrder.UpdateDropDown(dropDownFlights, flightNum);
        OnValueChangedFlightNum();
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
        DataSet ds = MySQLManager.ExecuteQuery("SELECT * From flights WHERE flightNum = '" + dropDownFlights.captionText.text + "'");//∂¡»°±Ì
        List<string> flightInf = new List<string>();
        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    flightInf.Add(row[column] + "");
                }
            }
        }
        Flights flight = new Flights(flightInf);
        time.text = flight.TimeText;
        city.text = flight.CityText;
        price.text = flight.PriceText;
        seats.text = "”‡∆± ˝£∫" + flight.SeatsText;
    }

    public void OnValueChangedFlightNum()
    {
        UpdateFlightInformation();
        flight.flightNum = dropDownFlights.captionText.text;
    }

    public void OnValueChangedCustomerName()
    {
        customer.custName = dropDownCustomers.captionText.text;
    }

    public void OnBtnOrderFlights()
    {
        MySQLManager.ExecuteQuery("INSERT INTO reservations(custName, resvType, resvName) VALUES ('" + customer.custName + "'" + ", 1 ,'" + flight.flightNum + "');");
        if (StaticData.isError == false)
        {
            UIOrder.EventOrderSuccess();
        }
    }
}
