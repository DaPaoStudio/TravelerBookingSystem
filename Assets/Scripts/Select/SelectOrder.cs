using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class SelectOrder : MonoBehaviour
{
    public InputField inputName;
    public Customers customer;
    public static List<Resvs> resvList;

    void Start()
    {
        inputName = transform.Find("CustomerNameInput").GetComponent<InputField>();
        customer = new Customers();
    }

    public void OnEndEditCustName()
    {
        customer.custName = inputName.text;
    }

    public void OnBtnSelectOrder()
    {
        SelectCustNameInResvs();
        for (int i = 0; i < resvList.Count; i++)
        {
            ItemOrder.AddItemResv(resvList[i], i + 1);
        }
    }

    void SelectCustNameInResvs()
    {
        List<string> resvInf;
        resvList = new List<Resvs>();
        DataSet ds = MySQLManager.ExecuteQuery("SELECT * FROM reservations WHERE custName = '" + customer.custName + "';");

        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                resvInf = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    resvInf.Add(row[column] + "");
                }
                Resvs resvItem = new Resvs(resvInf);
                resvList.Add(resvItem);
            }
        }
    }
}
