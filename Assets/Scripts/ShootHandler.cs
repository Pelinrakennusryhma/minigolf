using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
     
public class ShootHandler : MonoBehaviour,IUpdateSelectedHandler,IPointerDownHandler,IPointerUpHandler
{
    public bool isPressed;
    public bool mouseDown;
     
    // Start is called before the first frame update
    public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressed)
        {
            BallController.instanssi.Putt();
            isPressed = false;
        }
        
    }
    public void Update() {
        if(mouseDown) {
            BallController.instanssi.PowerUp();
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        mouseDown = true;
/*         while(isPressed) {
            // isPressed = true;
            BallController.instanssi.PowerUp();  
        } */

    }
    public void OnPointerUp(PointerEventData data)
    {
        mouseDown = false;
        isPressed = true;
    }
}
