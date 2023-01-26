using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnScript : MonoBehaviour, ITouchable
{
    public void OnDrag(Ray collidingRay)
    {
        print("I dragged John");
    }

    public void OnDrag(Ray collidingRay, bool firstTouch)
    {
        throw new System.NotImplementedException();
    }

    public void OnTap()
    {
        print("I tapped John");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
