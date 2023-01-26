using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeorgeScript : MonoBehaviour, ITouchable
{
    Vector3 acceleration, velocity;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //acceleration = 9.8f * Vector3.down;             // F = ma

        if (Input.touchCount > 0)
        {
            //acceleration += 15f * Vector3.up;
        }

        velocity += acceleration * Time.deltaTime;       // v = u + at
        transform.position += velocity * Time.deltaTime; // s = ut
    }

    

    internal void changeColor(Color newColor)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = newColor;
    }

    public void OnTap()
    {
        print("I tapped George");
    }

    public void OnDrag(Ray collidingRay)
    {
        transform.position = collidingRay.GetPoint(distance);
        print(distance + " George drag");
    }

    public void OnDrag(Ray collidingRay, bool firstTouch)
    {
        distance = Vector3.Distance(Camera.main.transform.position, transform.position);
    }
}
