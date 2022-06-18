using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEngine : MonoBehaviour
{
    public Transform focus;
    public float boundX = 0.15f;
    public float boundY = 0.03f;
    private Dictionary<string, bool> brokenBoundStatus = new Dictionary<string, bool>();
    
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float deltaX = focus.position.x - transform.position.x;
        float deltaY = focus.position.y - transform.position.y;
        
        this.updateCameraPosition(delta, deltaX, deltaY);
    }
 
    private void updateCameraPosition(Vector3 delta, float deltaX, float deltaY)
    {
        this.checkBrokenBounds(deltaX, deltaY);

        if (brokenBoundStatus["boundX"])
        {
            if (transform.position.x < focus.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        if (brokenBoundStatus["boundY"])
        {
            if (transform.position.y < focus.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }

    private void checkBrokenBounds(float deltaX, float deltaY)
    {
        brokenBoundStatus["boundX"] = false;
        brokenBoundStatus["boundY"] = false;

        if (deltaX > boundX || deltaX < -boundX)
        {
            brokenBoundStatus["boundX"] = true;
        }
        
        if (deltaY > boundY || deltaY < -boundY)
        {
            brokenBoundStatus["boundY"] = true;
        }
    }
}
