using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject;
    
    private void Start()
    {
        uiObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            uiObject.SetActive(true);
            StartCoroutine("ShowTime");
        }
    }

    IEnumerator ShowTime()
    {
        yield return new WaitForSeconds(2);
        uiObject.SetActive(false);
    }
}
