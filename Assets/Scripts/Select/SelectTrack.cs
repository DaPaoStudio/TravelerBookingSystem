using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class SelectTrack : MonoBehaviour
{
    public InputField inputName;
    public Customers customer;
    public static List<Tracks> trackList;

    void Start()
    {
        inputName = transform.Find("CustomerNameInput").GetComponent<InputField>();
        customer = new Customers();
    }

    public void OnEndEditCustName()
    {
        customer.custName = inputName.text;
    }

    public void OnBtnSelectTrack()
    {
        SelectCustNameInTrack();
        for (int i = 0; i < trackList.Count; i++)
        {
            ItemTrack.AddItemTrack(trackList[i], i + 1);
        }
    }

    void SelectCustNameInTrack()
    {
        List<string> trackInf;
        trackList = new List<Tracks>();
        DataSet ds = MySQLManager.ExecuteQuery("call trackOf('" + customer.custName + "');");

        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                trackInf = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    trackInf.Add(row[column] + "");
                }
                Tracks trackItem = new Tracks(trackInf);
                trackList.Add(trackItem);
            }
        }
    }
}
