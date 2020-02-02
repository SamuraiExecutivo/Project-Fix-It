using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniDemo : MiniGameBase {

    public override void Create () {
        objects = new GameObject[4];
        for (int i = 0; i < 4; i++) {
            objects[i] = new GameObject ("object" + i);
            objects[i].AddComponent<SpriteRenderer> ().sprite = sprites[i];
            objects[i].transform.position = new Vector3 (-12 + i  * 8, i/2*-4);
            objects[i].transform.localScale=Vector3.one*1.5f;
        }
    }
    public override void Update () {
        bool flag=Input.GetKeyDown(KeyCode.Space);
        if (flag) AudioManager.PlaySFX (Random.Range (0,6));
        for (int i = 0; i < objects.Length; i++) {
            objects[i].transform.position = Vector3.MoveTowards (objects[i].transform.position, new Vector3 (-12 + i  * 8, i/2*-4), Time.deltaTime / 5);
            if(flag)objects[i].transform.position = Vector3.MoveTowards (objects[i].transform.position, Vector3.zero, Time.deltaTime*12);
        }
        Timer();
        foreach (GameObject go in objects) {
            if (go.transform.position != Vector3.zero) return;
        }
        End(State.won);
    }
}