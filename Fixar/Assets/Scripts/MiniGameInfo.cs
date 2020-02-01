using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct MiniGameInfo
{
    public AudioClip[] notes;
    public Sprite[] sprites;
    public string type;
    public MiniGameBase GetMiniGame(){
        MiniGameBase mini= System.Activator.CreateInstance(System.Type.GetType(type)) as MiniGameBase;
        mini.sprites=sprites;
        mini.notes=notes;
        return mini;
    }
}
