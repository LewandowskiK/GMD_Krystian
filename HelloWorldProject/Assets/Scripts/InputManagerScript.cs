using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
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

            //print("Touch at:    " + myFirstTouch.position.ToString() + "           Touch Type: " + myFirstTouch.type.ToString());

            Ray myRay = Camera.main.ScreenPointToRay(myFirstTouch.position);

            Debug.DrawRay(myRay.origin, myRay.direction * 15f);

            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo)) 
            {
                //hitInfo.transform.position += Vector3.up;
                GeorgeScript touchedGeorge = hitInfo.transform.GetComponent<GeorgeScript>();
                touchedGeorge.changeColor(Color.green);
                print("Hit " + hitInfo.collider.name);
            }
            else
            {
                print("Not Hit");
            }
        }
    }
}
