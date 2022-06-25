using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{

    public Sprite[] sprites;

    public SpriteRenderer render;

    public int eggs = 3;


  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
 
            eggs = --eggs;
            
            if (eggs == 2){
                render.sprite = sprites[eggs];
            }
            
             if (eggs == 1){
                render.sprite = sprites[eggs];
            }
            
             if (eggs == 0){
                render.sprite = sprites[eggs];
                Debug.Log("Game over");
            }
        }
    }
}
