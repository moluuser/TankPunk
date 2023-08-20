using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    private int option = 1;

    public Transform option1;
    public Transform option2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            option = 1;
            transform.position = option1.position;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            option = 2;
            transform.position = option2.position;
        }

        if (option == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
        
    }
}
