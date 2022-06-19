using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject;
    
    public Sprite nest2Eggs;
    public Sprite nest1Eggs;
    public Sprite nest0Eggs;
    public SpriteRenderer render;

    public int eggs = 3;

    
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
            eggs = --eggs;
            
            if (eggs == 2){
                render.sprite = nest2Eggs;
            }
            
             if (eggs == 1){
                render.sprite = nest1Eggs;
            }
            
             if (eggs == 0){
                render.sprite = nest0Eggs;
                Debug.Log("Game over");
            }
        }
    }

    IEnumerator ShowTime()
    {
        yield return new WaitForSeconds(2);
        uiObject.SetActive(false);
    }
}
