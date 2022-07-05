using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{

    public Sprite[] sprites;

    public SpriteRenderer render;
    
    public GameObject uiObject;

    public int eggs = 3;
    
    private AudioEngine audioEngine;

    private void Start()
    {
        audioEngine = FindObjectOfType<AudioEngine>();
        uiObject.SetActive(false);
   }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            audioEngine.Play("egg_crack");
            
            eggs = --eggs;
            
            if (eggs == 2){
                render.sprite = sprites[eggs];
            }
            
             if (eggs == 1){
                render.sprite = sprites[eggs];
            }
            
             if (eggs == 0){
                render.sprite = sprites[eggs];
                   
                uiObject.SetActive(true);
                
                Time.timeScale = 0; 
             }
        }
    }
}
