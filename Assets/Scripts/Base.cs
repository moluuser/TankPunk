using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite brokenSprite;
    public AudioClip dieAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        PlayerManager.Instance.isDefeated = true;
        sr.sprite = brokenSprite;
        AudioSource.PlayClipAtPoint(dieAudioClip, transform.position);
    }
}
