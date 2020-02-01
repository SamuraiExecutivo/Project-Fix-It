using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MiniGameBase {

    public AudioClip[] notes;
    public Sprite[] sprites;
    public bool ended { private set; get; }
    protected GameObject[] objects;
    public virtual void Create () { }
    public virtual void Load () { }
    public virtual void Update () { }
    public void End () {
        foreach (GameObject go in objects) {
            Object.Destroy (go);
        }
        ended = true;
    }
}