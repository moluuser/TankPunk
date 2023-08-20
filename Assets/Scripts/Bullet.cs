using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public bool isPlayerBullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * transform.up, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayerBullet)
                {
                    collision.SendMessage("Die");
                }
                break;
            case "Base":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Barrier":
                Destroy(gameObject);
                break;
            case "Enemy":
                // Destroy(collision.gameObject);
                // Destroy(gameObject);
                break;
            case "EnemyBullet":
                // Destroy(collision.gameObject);
                // Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
