using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class SelectFlight : MonoBehaviour
{
    public InputField inputFlightNum;
    public Flights flight;
    public static List<Flights> flightList;

    void Start()
    {
        inputFlightNum = transform.Find("FlightNumInput").GetComponent<InputField>();
        flight = new Flights();
    }

    public void OnEndEditFlightNum()
    {
        flight.flightNum = inputFlightNum.text;
    }

    public void OnBtnSelectFlight()
    {
        SelectFlightNumInFlights();
        ItemFlight.DestoryAllItem();
        for (int i = 0; i < flightList.Count; i++)
        {
            ItemFlight.AddItemFlight(flightList[i], i + 1);
        }
    }

    public void OnBtnSelectAll()
    {
        SelectAllFlights();
        ItemFlight.DestoryAllItem();
        for (int i = 0; i < flightList.Count; i++)
        {
            ItemFlight.AddItemFlight(flightList[i], i + 1);
        }
    }

    void SelectFlightNumInFlights()
    {
        List<string> flightInf;
        flightList = new List<Flights>();
        DataSet ds = MySQLManager.ExecuteQuery("SELECT * FROM flights WHERE flightNum = '" + flight.flightNum + "';");
        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                flightInf = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    flightInf.Add(row[column] + "");
                }
                Flights flightItem = new Flights(flightInf);
                flightList.Add(flightItem);
            }
        }
    }

    void SelectAllFlights()
    {
        List<string> flightInf;
        flightList = new List<Flights>();
        DataSet ds = MySQLManager.ExecuteQuery("SELECT * FROM flights;");
        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                flightInf = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    flightInf.Add(row[column] + "");
                }
                Flights flightItem = new Flights(flightInf);
                flightList.Add(flightItem);
            }
        }
    }
}
