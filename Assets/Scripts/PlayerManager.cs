using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public int hp = 3;
    public int score = 0;
    public bool isDead = false;
    public GameObject playerPrefab;
    public bool isDefeated = false;

    public TMP_Text scoreText;
    public TMP_Text hpText;

    public GameObject gameOverPrefab;

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
            isDefeated = true;
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
        if (isDefeated)
        {
            gameOverPrefab.SetActive(true);
            return;
        }

        scoreText.text = PlayerManager.Instance.score.ToString();
        hpText.text = PlayerManager.Instance.hp.ToString();

        if (isDead)
        {
            Recover();
        }
    }
}
