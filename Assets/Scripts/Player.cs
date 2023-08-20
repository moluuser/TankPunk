using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

        Attack();

    }


    private void FixedUpdate()
    {
        Move();
    }


    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles));
        }
    }

    private void Move()
    {
        float v = Input.GetAxisRaw("Vertical"); // -1, 0, 1
        transform.Translate(Vector3.up * v * Time.deltaTime * speed, Space.World);
        if (v < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (v > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (v != 0)
        {
            return;
        }

        float h = Input.GetAxisRaw("Horizontal"); // -1, 0, 1
        transform.Translate(Vector3.right * h * Time.deltaTime * speed, Space.World);
        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (h > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}
