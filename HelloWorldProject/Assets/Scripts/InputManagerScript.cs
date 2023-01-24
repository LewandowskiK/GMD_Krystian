using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    float timer;
    bool hasMoved;
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
                    break;
                case TouchPhase.Moved:
                    hasMoved = true;
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    //print("Touch at:    " + myFirstTouch.position.ToString() + "           Touch Type: " + myFirstTouch.type.ToString());
                    print(timer);
                    if (timer < 0.5f)
                    {
                        Ray myRay = Camera.main.ScreenPointToRay(myFirstTouch.position);

                        Debug.DrawRay(myRay.origin, myRay.direction * 15f);

                        RaycastHit hitInfo;

                        if (Physics.Raycast(myRay, out hitInfo))
                        {
                            //hitInfo.transform.position += Vector3.up;
                            ITouchable touchedObject = hitInfo.transform.GetComponent<ITouchable>();
                            if (touchedObject != null)
                            {
                                touchedObject.OnTap();

                                if (touchedObject is GeorgeScript)
                                {
                                    (touchedObject as GeorgeScript).changeColor(Color.green);
                                }
                            }
                        }
                        else
                        {
                            print("Tap Not Hit Object");
                        }

                    }
                    else
                    {
                        print("I held my touch");
                    }
                    break;
                case TouchPhase.Canceled:
                    break;
                
            }
        }
    }
}
