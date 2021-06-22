using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField, Range(0,90)] float angle;
    [SerializeField] float initialVelocity;
    [SerializeField] float roundVelIncrement;
    [SerializeField] GameObject lineObj;
    Rigidbody2D rb;
    Vector2 forceVector;
    Vector2 startLoc;
    // Start is called before the first frame update
    void Start()
    {
        startLoc=(Vector2)transform.position;
        rb = GetComponent<Rigidbody2D>();
        float radian = angle* Mathf.Deg2Rad;
        forceVector = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        rb.AddForce(forceVector*initialVelocity);
        //print(Physics2D.gravity.y);
        float X = 1;
        float Y = (X) * Mathf.Tan(radian) - (Mathf.Abs(Physics2D.gravity.y)/(2*Mathf.Pow(initialVelocity/100,2)*Mathf.Pow(Mathf.Cos(radian),2)))*Mathf.Pow(X,2)+ startLoc.y;
        print(Mathf.Abs(Physics2D.gravity.y)/(2*Mathf.Pow(initialVelocity,2)*Mathf.Pow(Mathf.Cos(radian),2)));
        X += startLoc.x;
        var ball = Instantiate(lineObj, new Vector3(X, Y, 0), Quaternion.identity);
        X = 2;
        Y = (X) * Mathf.Tan(radian) - (Mathf.Abs(Physics2D.gravity.y)/(2*Mathf.Pow(initialVelocity,2)*Mathf.Pow(Mathf.Cos(radian),2)))*Mathf.Pow(X,2)+ startLoc.y;
        X += startLoc.x;
        var ball2 = Instantiate(lineObj, new Vector3(X, Y, 0), Quaternion.identity);
        X = 5;
        Y = (X) * Mathf.Tan(radian) - (Mathf.Abs(Physics2D.gravity.y)/(2*Mathf.Pow(initialVelocity,2)*Mathf.Pow(Mathf.Cos(radian),2)))*Mathf.Pow(X,2)+ startLoc.y;
        X += startLoc.x;
        var ball3 = Instantiate(lineObj, new Vector3(X, Y, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartThrow(){
        
    }

    void EndThrow(){

    }
}
