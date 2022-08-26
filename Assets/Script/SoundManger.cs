using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundname;
    public AudioClip clip;
}

public class SoundManger : MonoBehaviour
{
    public static SoundManger instance;

    [Header("사운드 등록")]
    [SerializeField] Sound[] bgmsounds;
    [SerializeField] Sound[] sfxsounds;

    [Header("브금 플레이어")]
    [SerializeField] AudioSource bgmplayers;

    [Header("효과음 플레이어")]
    [SerializeField] AudioSource[] sfxplayers;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        bgmPlay();
    }

    public void platSE(string _soundName)
    {
        for (int i = 0; i < sfxsounds.Length; i++)
        {
            if (_soundName == sfxsounds[i].soundname)
            {
                for (int x = 0; x < sfxplayers.Length; x++)
                {
                    if (!sfxplayers[x].isPlaying)
                    {
                        sfxplayers[x].clip=sfxsounds[i].clip;
                        sfxplayers[x].Play();
                        return;
                    }
                }
                return;
            }
        }
    }
    public void bgmPlay()
    {
        bgmplayers.clip = bgmsounds[0].clip;
        bgmplayers.Play();
    }
    
}
