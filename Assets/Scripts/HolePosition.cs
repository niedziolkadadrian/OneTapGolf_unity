using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResetHole();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetHole() {
        transform.position = new Vector3(Random.Range(.0f,8.0f),0,0);
    }
}
