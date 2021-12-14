using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class SelectCustomer : MonoBehaviour
{
    public InputField inputCustName;
    public Customers cust;
    public static List<Customers> custList;

    void Start()
    {
        inputCustName = transform.Find("CustomerNameInput").GetComponent<InputField>();
        cust = new Customers();
    }

    public void OnEndEditCustName()
    {
        cust.custName = inputCustName.text;
    }

    public void OnBtnSelectCust()
    {
        SelectCustNameInCust();
        ItemCustomer.DestoryAllItem();
        for (int i = 0; i < custList.Count; i++)
        {
            ItemCustomer.AddItemCustomer(custList[i], i + 1);
        }
    }

    public void OnBtnSelectAll()
    {
        SelectAllCusts();
        ItemCustomer.DestoryAllItem();
        for (int i = 0; i < custList.Count; i++)
        {
            ItemCustomer.AddItemCustomer(custList[i], i + 1);
        }
    }

    void SelectCustNameInCust()
    {
        List<string> custInf;
        custList = new List<Customers>();
        DataSet ds = MySQLManager.ExecuteQuery("SELECT * FROM customers WHERE custName = '" + cust.custName + "';");
        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                custInf = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    custInf.Add(row[column] + "");
                }
                Customers custItem = new Customers(custInf);
                custList.Add(custItem);
            }
        }
    }

    void SelectAllCusts()
    {
        List<string> custInf;
        custList = new List<Customers>();
        DataSet ds = MySQLManager.ExecuteQuery("SELECT * FROM customers;");
        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                custInf = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    custInf.Add(row[column] + "");
                }
                Customers custItem = new Customers(custInf);
                custList.Add(custItem);
            }
        }
    }
}
