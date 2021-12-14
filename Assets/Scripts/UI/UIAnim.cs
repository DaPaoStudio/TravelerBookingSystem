using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public static class UIAnim
{
    const float globalFadeSpeed = 0.5f;
    public static void SetCanvansActive(GameObject gameObject, float fadeSpeed = globalFadeSpeed)
    {
        gameObject.GetComponent<CanvasGroup>().DOFade(1f, fadeSpeed);
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameObject.GetComponent<CanvasGroup>().interactable = true;
    }
    public static void SetCanvansDisActive(GameObject gameObject, float fadeSpeed = globalFadeSpeed)
    {
        gameObject.GetComponent<CanvasGroup>().DOFade(0f, fadeSpeed);
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        gameObject.GetComponent<CanvasGroup>().interactable = false;
    }

    public static void UIHideAll(List<GameObject> gameObjects)
    {
        foreach (var item in gameObjects)
        {
            item.GetComponent<CanvasGroup>().alpha = 0f;
            item.GetComponent<CanvasGroup>().blocksRaycasts = false;
            item.GetComponent<CanvasGroup>().interactable = false;
        }
    }
}
