using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STARSCR : MonoBehaviour
{
    float x;
    float y;
    float z;
    Vector3 pos;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-6, 6);
        y = 0.8f;
        z = 9;
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(0, 0, -2);
        transform.localPosition += velocity * Time.fixedDeltaTime;

    }
}
