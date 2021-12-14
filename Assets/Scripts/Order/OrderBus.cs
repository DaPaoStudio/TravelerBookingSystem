using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class OrderBus : MonoBehaviour
{
    public Dropdown dropDownBus, dropDownCustomers;
    public Text busName, price, seats;
    public Buses bus;
    public Customers customer;
    void Start()
    {
        dropDownBus = transform.Find("BusLocation").GetComponent<Dropdown>();
        dropDownCustomers = transform.Find("CustomerName").GetComponent<Dropdown>();
        busName = transform.Find("Name").GetComponent<Text>();
        price = transform.Find("Price").GetComponent<Text>();
        seats = transform.Find("Seats").GetComponent<Text>();
        bus = new Buses();
        customer = new Customers();
        SelectBusLocationInBuses();
        SelectCustNameInCustomers();
    }

    void SelectBusLocationInBuses()
    {
        List<string> busInf = new List<string>();
        DataSet ds = MySQLManager.ExecuteQuery("SELECT location From bus;");

        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    busInf.Add(row[column] + "");
                }
            }
        }

        UIOrder.UpdateDropDown(dropDownBus, busInf);
        OnValueChangedBusLocation();
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

    public void UpdateBusInformation()
    {
        DataSet ds = MySQLManager.ExecuteQuery("SELECT * From bus WHERE location = '" + dropDownBus.captionText.text + "'");//∂¡»°±Ì
        List<string> busInf = new List<string>();
        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    busInf.Add(row[column] + "");
                }
            }
        }
        Buses busItem = new Buses(busInf);
        busName.text = busItem.NameText;
        price.text = busItem.PriceText;
        seats.text = "”‡∆±£∫" + busItem.SeatsText;
    }

    public void OnValueChangedBusLocation()
    {
        UpdateBusInformation();
        bus.location = dropDownBus.captionText.text;
    }

    public void OnValueChangedCustomerName()
    {
        customer.custName = dropDownCustomers.captionText.text;
    }

    public void OnBtnOrderBus()
    {
        MySQLManager.ExecuteQuery("INSERT INTO reservations(custName, resvType, resvName) VALUES ('" + customer.custName + "'" + ", 3 ,'" + bus.location + "');");
        if (StaticData.isError == false)
        {
            UIOrder.EventOrderSuccess();
        }
    }
}
