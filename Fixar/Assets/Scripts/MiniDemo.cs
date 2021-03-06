﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniDemo : MiniGameBase {

    public override void Create () {
        objects = new GameObject[sprites.Length];
        for (int i = 0; i < sprites.Length; i++) {
            objects[i] = new GameObject ("object" + i);
            objects[i].AddComponent<SpriteRenderer> ().sprite = sprites[i];
            objects[i].transform.position = new Vector3 ((-3+i%2*8)*(1+i/2), -i/2*3);
        }
    }
    public override void Update () {
        bool flag = Input.GetKeyDown (KeyCode.Space);
        if (flag) AudioManager.PlaySFX (Random.Range (0, 6));
        for (int i = 0; i < objects.Length; i++) {
            objects[i].transform.position = Vector3.MoveTowards (objects[i].transform.position, new Vector3 ((-3+i%2*8)*(1+i/2), -i/2*3), Time.deltaTime / 5);
            if (flag) objects[i].transform.position = Vector3.MoveTowards (objects[i].transform.position, Vector3.zero, Time.deltaTime * 15);
        }
        Timer ();
        foreach (GameObject go in objects) {
            if (go.transform.position != Vector3.zero) return;
        }
        End (State.won);
    }
}