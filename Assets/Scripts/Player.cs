using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private float timer = 0;
    private float defenseTimeVal = 3;
    private bool isDefended = true;

    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public GameObject defendEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (timer > 0.4f)
        {
            Attack();
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (isDefended)
        {
            defendEffectPrefab.SetActive(true);

            defenseTimeVal -= Time.deltaTime;
            if (defenseTimeVal <= 0)
            {
                isDefended = false;
                defendEffectPrefab.SetActive(false);
            }
        }
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
            timer = 0;
        }
    }

    private void Die() 
    {
        if (isDefended)
        {
            return;
        }

        PlayerManager.Instance.isDead = true;

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
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
