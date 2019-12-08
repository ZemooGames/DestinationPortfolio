using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMaths : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetAngle(Vector2 point1, Vector2 point2)
    // Given two points returns the angle in Radians between them
    {
        float x1 = point1.x;
        float y1 = point1.y;
        float x2 = point2.x;
        float y2 = point2.y;
        float xDelta = x2 - x1;
        float yDelta = y2 - y1;
        return Mathf.Atan2(yDelta, xDelta) * Mathf.Rad2Deg;
    }

    public float GetDistance(Vector2 point1, Vector2 point2)
    // Given two points returns the angle in Radians between them
    {
        float x1 = point1.x;
        float y1 = point1.y;
        float x2 = point2.x;
        float y2 = point2.y;
        float xDelta = x2 - x1;
        float yDelta = y2 - y1;
        Debug.Log("X1 " + x1 + " X2 " + x2 + " Xd " + xDelta + " Y1 " + y1 + " Y2 " + y2 + " Yd " + yDelta + " distance " + Mathf.Sqrt(Mathf.Pow(yDelta, 2) + Mathf.Pow(xDelta, 2)));
        return Mathf.Sqrt(Mathf.Pow(yDelta, 2) + Mathf.Pow(xDelta, 2));
    }

    public float GetRadians(float F)
    {
        // Debug.Log("input " + F + " Output " + F * 180 / (2 * Mathf.PI));
        return F / 180 * Mathf.PI;
    }
}
