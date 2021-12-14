using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelect : MonoBehaviour
{
    public GameObject flightPanel, hotelPanel, busPanel, customerPanel;
    public List<GameObject> panels;
    void Start()
    {
        flightPanel = transform.Find("FlightPanel").gameObject;
        hotelPanel = transform.Find("HotelPanel").gameObject;
        busPanel = transform.Find("BusPanel").gameObject;
        customerPanel = transform.Find("CustomerPanel").gameObject;
        panels.Add(flightPanel);
        panels.Add(hotelPanel);
        panels.Add(busPanel);
        panels.Add(customerPanel);
        UIAnim.UIHideAll(panels);
    }

    public void OnBtnFlight()
    {
        UIAnim.UIHideAll(panels);
        UIAnim.SetCanvansActive(flightPanel);
    }

    public void OnBtnHotel()
    {
        UIAnim.UIHideAll(panels);
        UIAnim.SetCanvansActive(hotelPanel);
    }

    public void OnBtnBus()
    {
        UIAnim.UIHideAll(panels);
        UIAnim.SetCanvansActive(busPanel);
    }

    public void OnBtnCustomer()
    {
        UIAnim.UIHideAll(panels);
        UIAnim.SetCanvansActive(customerPanel);
    }

}
