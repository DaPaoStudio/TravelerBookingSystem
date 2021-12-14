using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITitle : MonoBehaviour
{
    public void OnBtnInputDown()
    {
        SceneManager.LoadScene(1);
    }
    public void OnBtnOrderDown()
    {
        SceneManager.LoadScene(2);
    }
    public void OnBtnSelectDown()
    {
        SceneManager.LoadScene(3);
    }
    public void OnBtnSelectOrderDown()
    {
        SceneManager.LoadScene(4);
    }
}
