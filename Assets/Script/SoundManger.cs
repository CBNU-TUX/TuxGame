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

    [Header("���� ���")]
    [SerializeField] Sound[] bgmsounds;
    [SerializeField] Sound[] sfxsounds;

    [Header("��� �÷��̾�")]
    [SerializeField] AudioSource bgmplayers;

    [Header("ȿ���� �÷��̾�")]
    [SerializeField] AudioSource[] sfxplayers;
    // Start is called before the first frame update
     private void Awake()
    {

        GameObject[] sounds = GameObject.FindGameObjectsWithTag("Sound");
        if (sounds.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } // 중복된 Player 오브젝트가 있을 경우 오브젝트 파괴

    }
    void Start()
    {
        instance = this;
        bgmPlay();
    }

    public void platSE(string _soundName)
    {
        Debug.Log(_soundName);
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
