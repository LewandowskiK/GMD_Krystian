using UnityEngine;

interface ITouchable
{
    void OnTap();

    void OnDrag(Ray collidingRay);

    void OnDrag(Ray collidingRay, bool firstTouch);

}
