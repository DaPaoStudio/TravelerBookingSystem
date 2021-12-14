using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectOrder : MonoBehaviour
{
    public GameObject trackPanel, orderPanel;
    public List<GameObject> panels;
    void Start()
    {
        trackPanel = transform.Find("TrackPanel").gameObject;
        orderPanel = transform.Find("OrderPanel").gameObject;
        panels.Add(trackPanel);
        panels.Add(orderPanel);
        UIAnim.UIHideAll(panels);
    }

    public void OnBtnTrack()
    {
        UIAnim.UIHideAll(panels);
        UIAnim.SetCanvansActive(trackPanel);
    }

    public void OnBtnOrder()
    {
        UIAnim.UIHideAll(panels);
        UIAnim.SetCanvansActive(orderPanel);
    }
}
