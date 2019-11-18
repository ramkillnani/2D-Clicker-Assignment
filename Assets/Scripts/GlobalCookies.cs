using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCookies : MonoBehaviour
{
    public static int cookieCount;
    public GameObject cookieDisplay;
    public int internalCookie;

    void Update()
    {
        internalCookie = cookieCount;
        cookieDisplay.GetComponent<Text>().text = "Cookies: " + internalCookie;
    }
}
