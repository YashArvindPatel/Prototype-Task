using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public AudioSource source;
    public AudioClip[] clips;

    public void PlaySingleClip(int index)
    {
        source.PlayOneShot(clips[index]);
    }
}

public enum SoundIndexes
{
    BUY_OR_SELL = 0,
    EQUIP = 1,
    SELECT = 2,
    ERROR = 3,
    OPEN = 4,
    CLOSE = 5,
}
