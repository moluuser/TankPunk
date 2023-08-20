using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int hp = 3;
    public int score = 0;
    public bool isDead = false;
    public GameObject playerPrefab;

    private static PlayerManager instance;

    public static PlayerManager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Recover()
    {
        if (hp <= 0)
        {
            // TODO
            return;
        }
        else
        {
            hp--;
            Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Recover();
        }

    }
}
