using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCustomer : MonoBehaviour
{
    public InputField inputName, inputID;
    public Customers customer;
    void Awake()
    {
        inputName = transform.Find("CustomerName").GetComponent<InputField>();
        inputID = transform.Find("CustomerID").GetComponent<InputField>();
        customer = new Customers();
    }

    void Update()
    {

    }

    public void OnEndEditName()
    {
        customer.custName = inputName.text;
    }

    public void OnEndEditID()
    {
        customer.custID = inputID.text;
    }

    public void OnBtnAdd()
    {
        if (customer.custName != null && customer.custID != null)
        {
            MySQLManager.ExecuteQuery("INSERT INTO customers VALUES ('" + customer.custID + "'"+ ",'"+ customer.custName+ "');");
            if(StaticData.isError == false)
            {
                UIInput.EventAddSuccess();
            }
        }
    }
}
