using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSell : MonoBehaviour
{
    public bool sellingCookie = false; 
    public static int cashIncrease = 1;
    public int internalIncrease;

    // Update is called once per frame
    void Update()
    {
        cashIncrease = GlobalShop.shopPerSec;

        internalIncrease = cashIncrease;

        if (sellingCookie == false)
        {
            sellingCookie = true;
            StartCoroutine(SellTheCookie());
        }
    }

    IEnumerator SellTheCookie()
    {
        if(GlobalCookies.cookieCount == 0)
        {
            //we can't do anything
        }
        else
        {
            GlobalCash.cashCount += internalIncrease;
            GlobalCookies.cookieCount -= 1;
            yield return new WaitForSeconds(1);
            sellingCookie = false;
        }
    }
}
