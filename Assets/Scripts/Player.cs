using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {

        float zAngle = transform.rotation.eulerAngles.z;

        float h = Input.GetAxisRaw("Horizontal"); // -1, 0, 1
        transform.Translate(Vector3.right * h * Time.deltaTime * speed, Space.World);
        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, zAngle + 90);
        }
        else if (h > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, zAngle - 90);
        }

        float v = Input.GetAxisRaw("Vertical"); // -1, 0, 1
        transform.Translate(Vector3.up * v * Time.deltaTime * speed, Space.World);
        if (v < 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, zAngle + 180);
        }
        else if (v > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
