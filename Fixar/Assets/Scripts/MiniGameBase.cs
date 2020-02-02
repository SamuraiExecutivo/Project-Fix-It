using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MiniGameBase {

    public enum State {
        running,
        won,
        lost

    }
    public State state;
    public AudioClip[] notes;
    public Sprite[] sprites;
    public bool ended { get { return state != State.running; } }
    public float timer { protected set; get; } = 5;
    protected GameObject[] objects;
    public virtual void Create () { }
    public virtual void Load () { }
    public virtual void Update () { }
    protected virtual void Timer () {
        timer -= Time.deltaTime;
        if (timer <= 0) End (State.lost);
    }
    public void End (State s) {
        state = s;
    }
    public void Clear () {
        foreach (GameObject go in objects) {
            Object.Destroy (go);
        }
    }
}