using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInput : MonoBehaviour
{
    public GameObject flightPanel, hotelPanel, busPanel, customerPanel, success, error;
    public List<GameObject> panels;
    public static bool issuccuss = false;
    // Start is called before the first frame update
    void Start()
    {
        flightPanel = transform.Find("FlightPanel").gameObject;
        hotelPanel = transform.Find("HotelPanel").gameObject;
        busPanel = transform.Find("BusPanel").gameObject;
        customerPanel = transform.Find("CustomerPanel").gameObject;
        success = transform.Find("Success").gameObject;
        error = transform.Find("Error").gameObject;
        panels.Add(flightPanel);
        panels.Add(hotelPanel);
        panels.Add(busPanel);
        panels.Add(customerPanel);
        UIAnim.UIHideAll(panels);
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticData.isError)
        {
            StartCoroutine(ShowError());
            StaticData.isError = false;
        }
        if (issuccuss)
        {
            StartCoroutine(ShowSuccsee());
            issuccuss = false;
        }
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

    public static void EventAddSuccess()
    {
        issuccuss = true;
    }

    IEnumerator ShowSuccsee()
    {
        UIAnim.SetCanvansActive(success);
        yield return new WaitForSecondsRealtime(1f);
        UIAnim.SetCanvansDisActive(success);
    }
    IEnumerator ShowError()
    {
        UIAnim.SetCanvansActive(error);
        yield return new WaitForSecondsRealtime(1f);
        UIAnim.SetCanvansDisActive(error);
    }
}
