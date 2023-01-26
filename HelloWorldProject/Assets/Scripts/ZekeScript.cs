using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZekeScript : MonoBehaviour, ITouchable
{
    public void OnDrag(Ray collidingRay)
    {
        print("I dragged Zeke");
    }

    public void OnDrag(Ray collidingRay, bool firstTouch)
    {
        throw new System.NotImplementedException();
    }

    public void OnTap()
    {
        print("I tapped Zeke");
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
