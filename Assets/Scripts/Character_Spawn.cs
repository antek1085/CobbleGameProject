using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character_Spawn : MonoBehaviour
{
   [SerializeField] GameObject itemToSpawn;
   [SerializeField] SO_INT numberCharacters;

   void Awake()
   {
      SpawnCharacter();
   }
   void SpawnCharacter()
   {
      for (int i = 0; i < numberCharacters.value; i++)
      {
         Vector3 randomSpawnPosition = new Vector3(Random.Range(-10f, 10f),0, Random.Range(-10f,10f));
         Instantiate(itemToSpawn, randomSpawnPosition, Quaternion.identity);
      }
      numberCharacters.value = 0;
      gameObject.SetActive(false);
   }
}
