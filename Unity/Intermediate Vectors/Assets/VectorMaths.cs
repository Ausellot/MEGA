using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMaths : MonoBehaviour
   
{
    public float UnitiesDistance, MyDistance;
    public Vector2 Obj1, Obj2;
    public static Vector2 AddVectors(Vector2 Vec1, Vector2 Vec2)
    {
        //init return value
        Vector2 rv = new Vector2(0, 0);

        //add two vectors
        rv.x = Vec1.x + Vec2.x;
        rv.y = Vec1.y + Vec2.y;

        //returns added value
        return rv;
    }

    public static Vector2 SubtractVectors(Vector2 Vec1, Vector2 Vec2)
    {
        Vector2 rv = new Vector2(0, 0);

        rv.x = Vec1.x - Vec2.x;
        rv.y = Vec1.y - Vec2.y;

        return rv;
    }
    public static float Length(Vector2 vector2)
    {
        float rv;

        rv = Mathf.Sqrt(vector2.x*vector2.x + vector2.y*vector2.y);

        return rv;
    }

    public static float LengthSq(Vector3 A)
    {
        return 0;
    }

    public static Vector3 MultiplyVector(Vector3 A, float Scalar)
    {
        return Vector3.zero;
    }

    public static Vector3 DivideVector(Vector3 A, float Divisor)
    {
        return Vector3.zero;
    }

    public static Vector3 NormalizedVector(Vector3 A)
    {
        return Vector3.zero;
    }

    public static float DotProduct(Vector3 A, Vector3 B)
    {
        return 0;
    }

    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        Vector2 V = VectorMaths.SubtractVectors(Obj1, Obj2);


        MyDistance = Length(V);
        UnitiesDistance = V.magnitude;
    }
}
