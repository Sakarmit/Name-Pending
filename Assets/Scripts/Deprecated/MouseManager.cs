using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

class MouseManager
{
    private static MouseManager instance;

    public static Vector3 RelativeMousePosition
    {
        get
        {
            Vector3 relativeWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return new Vector3(relativeWorldPosition.x, relativeWorldPosition.y, 0);
        }
    }
}