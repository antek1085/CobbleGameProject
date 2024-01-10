using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "gameObjectList")]
public class SO_ListGameObject : ScriptableObject
{
    public List<GameObject> list = new List<GameObject>();
}
