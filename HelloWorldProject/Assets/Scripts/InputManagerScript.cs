using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    float timer;
    bool hasMoved;
    ITouchable touchedObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch[] myTouches = Input.touches;
            Touch myFirstTouch = myTouches[0];

            timer += Time.deltaTime;
            switch (myFirstTouch.phase)
            {
                case TouchPhase.Began:
                    timer = 0.0f;
                    hasMoved = false;
                    if (touchedObject != null)
                        touchedObject = null;
                    break;
                case TouchPhase.Moved:
                    Ray myRay = Camera.main.ScreenPointToRay(myFirstTouch.position);

                    touchedObject = SelectObject(myRay);
                    if (!hasMoved)
                        touchedObject.OnDrag(myRay, hasMoved);

                    if (touchedObject != null)
                        touchedObject.OnDrag(myRay);
                    
                    hasMoved = true;
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    //print("Touch at:    " + myFirstTouch.position.ToString() + "           Touch Type: " + myFirstTouch.type.ToString());
                    print(timer);
                    if (timer < 0.5f && !hasMoved)
                    {
                        ObjectTapped(myFirstTouch);
                    }
                    else if (!hasMoved)
                    {
                        print("I held my touch");
                    }
                    else
                    {
                        if(touchedObject != null)
                        {
                            myRay = Camera.main.ScreenPointToRay(myFirstTouch.position);
                            Debug.DrawRay(myRay.origin, myRay.direction * 15f);
                            touchedObject.OnDrag(myRay);
                        }
                        else
                        {
                            print("I tried dragging");
                        }
                    }
                    break;
                case TouchPhase.Canceled:
                    break;
                
            }
        }
    }

    ITouchable SelectObject(Ray myRay)
    {
        RaycastHit hitInfo;

        Debug.DrawRay(myRay.origin, myRay.direction * 15f);

        if (Physics.Raycast(myRay, out hitInfo))
        {
            return hitInfo.transform.GetComponent<ITouchable>();
            
        }
        return null;
    }

    void ObjectTapped(Touch myFirstTouch)
    {
        Ray myRay = Camera.main.ScreenPointToRay(myFirstTouch.position);
        
        //hitInfo.transform.position += Vector3.up;

        ITouchable touchedObject = SelectObject(myRay);

            if (touchedObject != null)
            {
                touchedObject.OnTap();

                if (touchedObject is GeorgeScript)
                {
                    (touchedObject as GeorgeScript).changeColor(Color.green);
                }
            }
            else
            {
                print("Tap Not Hit Object");
            }
    }

    void ObjectDragged()
    {

    } 
}
