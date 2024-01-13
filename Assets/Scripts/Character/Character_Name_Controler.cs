using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character_Name_Controler : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI characterName;
   [SerializeField] List<String> Names = new List<string>();
   void Awake()
   {
       gameObject.name = Names[Random.Range(0, Names.Count - 1)];
       characterName.text = gameObject.name;
   }
}
