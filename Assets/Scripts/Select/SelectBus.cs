using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class SelectBus : MonoBehaviour
{
    public InputField inputBusLocation;
    public Buses bus;
    public static List<Buses> busList;

    void Start()
    {
        inputBusLocation = transform.Find("BusLocationInput").GetComponent<InputField>();
        bus = new Buses();
    }

    public void OnEndEditBusLocation()
    {
        bus.location = inputBusLocation.text;
    }

    public void OnBtnSelectBus()
    {
        SelectBusLocationInBuses();
        ItemBus.DestoryAllItem();
        for (int i = 0; i < busList.Count; i++)
        {
            ItemBus.AddItemBus(busList[i], i + 1);
        }
    }

    public void OnBtnSelectAll()
    {
        SelectAllBuses();
        ItemBus.DestoryAllItem();
        for (int i = 0; i < busList.Count; i++)
        {
            ItemBus.AddItemBus(busList[i], i + 1);
        }
    }

    void SelectBusLocationInBuses()
    {
        List<string> busInf;
        busList = new List<Buses>();
        DataSet ds = MySQLManager.ExecuteQuery("SELECT * FROM bus WHERE location = '" + bus.location + "';");
        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                busInf = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    busInf.Add(row[column] + "");
                }
                Buses busItem = new Buses(busInf);
                busList.Add(busItem);
            }
        }
    }

    void SelectAllBuses()
    {
        List<string> busInf;
        busList = new List<Buses>();
        DataSet ds = MySQLManager.ExecuteQuery("SELECT * FROM bus;");
        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                busInf = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    busInf.Add(row[column] + "");
                }
                Buses busItem = new Buses(busInf);
                busList.Add(busItem);
            }
        }
    }
}
