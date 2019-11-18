using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisasterScript : MonoBehaviour
{
    public GameObject statusBox;
    public float cookieCheck;
    public int genChance;
    public bool disasterActive = false;
    public int cookieLoss;

    // Update is called once per frame
    void Update()
    {
        cookieCheck = GlobalCookies.cookieCount / 10;

        if (disasterActive == false)
        {
            StartCoroutine(StartDisaster()); 
        }

        IEnumerator StartDisaster()
        {
            disasterActive = true;
            genChance = Random.Range(1, 20);

            if (cookieCheck >= genChance)
            {
                cookieLoss = Mathf.RoundToInt(GlobalCookies.cookieCount * 0.25f);
                statusBox.GetComponent<Text>().text = "You lost " + cookieLoss + " as a ship explodes.";
                GlobalCookies.cookieCount -= cookieLoss;
                yield return new WaitForSeconds(3);
                statusBox.GetComponent<Animation>().Play("StatusAnim");
                yield return new WaitForSeconds(1);
                statusBox.SetActive(false);
                statusBox.SetActive(true);
            }

            yield return new WaitForSeconds(10);
            disasterActive = false;
        }
    }
}
