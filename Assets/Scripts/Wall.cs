using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public AudioClip hitAudioClip;

    public void PlayAudio()
    {
        AudioSource.PlayClipAtPoint(hitAudioClip, transform.position);
    }
}
