using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private const string blockLayer = "Block";
    private const string actorLayer = "Actor";
    
    private CapsuleCollider2D birdCollider;

    private RaycastHit2D raycastHit;
    
    private Vector3 moveDelta;

    public Animator animator;
   
    private AudioEngine audioEngine;
    
    private void Start()
    {
        birdCollider = GetComponent<CapsuleCollider2D>();
        audioEngine = FindObjectOfType<AudioEngine>();
   }
    
    private void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        if(Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1 || Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1) 
        {
            animator.SetFloat("LastMoveX", Input.GetAxis("Horizontal"));
            animator.SetFloat("LastMoveY", Input.GetAxis("Vertical"));
        }

        if(horizontalMovement == 0)
        {
            animator.SetFloat("Horizontal", verticalMovement);
        } else {
            animator.SetFloat("Horizontal", horizontalMovement);
        }

        moveDelta = new Vector3(horizontalMovement, verticalMovement, 0);
        
        if (this.isCharacterMovementAllowed(new Vector2(0, moveDelta.y), moveDelta.y))
        {
            audioEngine.Play("grass");
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        
        if (this.isCharacterMovementAllowed(new Vector2(moveDelta.x, 0), moveDelta.x))
        {
            audioEngine.Play("grass");
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        
    }


    private bool isCharacterMovementAllowed(Vector2 direction, float distance)
    {
         RaycastHit2D hitCast = Physics2D.BoxCast(
            transform.position,
            birdCollider.size,
            0,
            direction,
            Mathf.Abs(distance * Time.deltaTime),
            LayerMask.GetMask(blockLayer, actorLayer)
        );

         if (hitCast.collider == null)
         {
             return true;
         }

         return false;
    }
}
