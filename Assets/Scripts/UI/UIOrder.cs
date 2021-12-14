using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class UIOrder : MonoBehaviour
{
    public GameObject flightPanel, hotelPanel, busPanel, success, error;
    public List<GameObject> panels;
    public static bool issuccuss = false;
    // Start is called before the first frame update
    void Start()
    {
        flightPanel = transform.Find("FlightPanel").gameObject;
        hotelPanel = transform.Find("HotelPanel").gameObject;
        busPanel = transform.Find("BusPanel").gameObject;
        success = transform.Find("Success").gameObject;
        error = transform.Find("Error").gameObject;
        panels.Add(flightPanel);
        panels.Add(hotelPanel);
        panels.Add(busPanel);
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

    public static void EventOrderSuccess()
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

    public static void UpdateDropDown(Dropdown dropDown, List<string> listString)
    {
        //清空下下拉框数据
        dropDown.options.Clear();
        Dropdown.OptionData tempData;
        for (int i = 0; i < listString.Count; i++)
        {
            tempData = new Dropdown.OptionData();
            tempData.text = listString[i];
            dropDown.options.Add(tempData);
        }
        //把第一条数据显示为默认
        dropDown.captionText.text = listString[0];
    }
}
