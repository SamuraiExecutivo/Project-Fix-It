using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager a_Manager;
    private static AudioSource a_Player;
    [SerializeField] 
    AudioClip[] a_sfxList;

    public static void PlaySFX (int id) {
        if (a_Manager != null && id >= 0 && id < a_Manager.a_sfxList.Length) {
            a_Player.PlayOneShot (a_Manager.a_sfxList[id], 1f);
        }
    }

    // Start is called before the first frame update
    void Start () {
        DontDestroyOnLoad (gameObject);
        a_Player = gameObject.AddComponent<AudioSource> ();
        a_Manager = this;
    }

    // Update is called once per frame
    void Update () {

    }
}