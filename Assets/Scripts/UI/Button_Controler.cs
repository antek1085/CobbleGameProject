using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button_Controler : MonoBehaviour
{
    [SerializeField] SO_ListGameObject characterList;
    GameObject characterLead;
    GameObject character;
    [SerializeField] int numberOnList;
    [SerializeField] TextMeshProUGUI characterNameOnButton;
    string characterName;

    void Awake()
    {
        if (numberOnList > characterList.list.Count - 1)
        {
            gameObject.SetActive(false);
            return;
        }
        
        characterName  = characterList.list[numberOnList].name;
       characterNameOnButton.text = characterName;
    }
    public void OnClick()
    {
        Debug.Log("!");
        characterLead = characterList.list[numberOnList];
        characterLead.GetComponent<Character_Controler>().isHeLead = true;
        StartCoroutine(ChangeLeader());
    }

    IEnumerator ChangeLeader()
    {
        for (int i = 0; i < characterList.list.Count; i++)
        {
            character = characterList.list[i];
            if (character != characterLead)
            {
                character.GetComponent<Character_Controler>().isHeLead = false;
                if (i == characterList.list.Count - 1) 
                {
                    StopCoroutine(ChangeLeader());
                    break;
                }  
            }
        }
        yield return null;
    }
}
