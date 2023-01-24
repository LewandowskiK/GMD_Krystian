using UnityEngine;

interface ITouchable
{
    void OnTap();

    void OnDrag(Ray collidingRay);

}
