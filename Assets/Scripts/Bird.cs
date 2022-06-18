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
    
    private void Start()
    {
        birdCollider = GetComponent<CapsuleCollider2D>();
    }
    
    private void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(horizontalMovement, verticalMovement, 0);
        
        this.setCharacterDirection(moveDelta);
        
        if (this.isCharacterMovementAllowed(new Vector2(0, moveDelta.y), moveDelta.y))
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        
        if (this.isCharacterMovementAllowed(new Vector2(moveDelta.x, 0), moveDelta.x))
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        
    }

    private void setCharacterDirection(Vector3 moveDelta)
    {
        if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
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
