using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private float timer;
    private float timerChangeDirection = 4;

    public GameObject bulletPrefab;
    public GameObject explosionPrefab;

    private float v;
    private float h;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (timer > 1f)
        {
            Attack();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }


    private void FixedUpdate()
    {
        Move();
    }


    private void Attack()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles));
        timer = 0;
    }

    private void Die()
    {
        PlayerManager.Instance.score++;

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Move()
    {
        if (timerChangeDirection >= 4)
        {
            int num = Random.Range(0, 8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2)
            {
                v = 0;
                h = -1;
            }
            else if (num > 2 && num <= 4)
            {
                v = 0;
                h = 1;
            }

            timerChangeDirection = 0;
        }
        else
        {
            timerChangeDirection += Time.fixedDeltaTime;
        }

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
