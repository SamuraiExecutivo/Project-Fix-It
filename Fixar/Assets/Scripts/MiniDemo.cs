using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniDemo : MiniGameBase {

    public override void Create () {
        objects = new GameObject[sprites.Length];
        for (int i = 0; i < sprites.Length; i++) {
            objects[i] = new GameObject ("object" + i);
            objects[i].AddComponent<SpriteRenderer> ().sprite = sprites[i];
            objects[i].transform.position = new Vector3 (i / 2 * 4, -4 + i % 2 * 8);
        }
    }
    public override void Update () {
        foreach (GameObject go in objects) {
            go.transform.position = Vector3.MoveTowards (go.transform.position, Vector3.zero, Time.deltaTime / 5);
        }
        foreach (GameObject go in objects) {
            if (go.transform.position != Vector3.zero) return;
        }
        End ();
    }
}