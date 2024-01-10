using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Character_Controler : MonoBehaviour
{
    [Header("Brackets for a stats")]
    [Range(0.0f, 10.0f)]
    [SerializeField] float maxSpeed;
    [Range(0.0f, 10.0f)]
    [SerializeField] float minSpeed;
    [Range(0.0f, 120.0f)]
    [SerializeField] float maxAngular_speed;
    [Range(0.0f, 120.0f)]
    [SerializeField] float minAngular_speed;
    [Range(0.0f, 20.0f)]
    [SerializeField] float maxDexterity;
    [Range(0.0f, 20.0f)]
    [SerializeField] float minDexterity;
   
    
    [Header("Stats")]
    [SerializeField] float speed;
    [SerializeField] float angular_speed;
    [SerializeField] float dexterity;
    
    public bool isHeLead;
    
    //movement variables
    Vector3 mousePostion;
    Rigidbody rigidbody;
    NavMeshAgent agent;
    
    
    Renderer renderer;
    [FormerlySerializedAs("vector3")]
    [SerializeField] SO_Vector3 leaderVector3;
    [FormerlySerializedAs("list")]
    public SO_ListGameObject characterList;

    [SerializeField] TextMeshProUGUI characterName; 
    
    void Awake()
    {
        characterName.text = gameObject.name;
        leaderVector3.vector3 = Vector3.zero;
        characterList.list.Add(gameObject);
        
        
       GetComponentAwake();
       CreateAssignStats();
       rigidbody.freezeRotation = true;

    }
    
    void Update()
    {
      SetCharacherMaterial(IsCharacterLeader());
      
      HandleMovement(IsCharacterLeader());
    }
    
    void OnDestroy()
    {
        characterList.list.Clear();
    }

    void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
        
    } 
    
    void CreateAssignStats()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        angular_speed = Random.Range(minAngular_speed, maxAngular_speed);
        dexterity = Random.Range(minDexterity, maxDexterity);
        agent.speed = speed;
        agent.angularSpeed = angular_speed;
    }

    bool IsCharacterLeader()
    {
        return isHeLead;
    }

    void SetCharacherMaterial(bool isLeader)
    {
        renderer.material.color = isLeader ? Color.red : Color.green;
    }
    void HandleMovement(bool isLeader)
    {
        if (isLeader)
        {
            leaderVector3.vector3 = transform.position;
            agent.stoppingDistance = 0;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SetDestinationToMousePosition();
                return;
            }
        }
        else
        {
            agent.stoppingDistance = 2;
            if (leaderVector3.vector3 != Vector3.zero)
            {
               agent.SetDestination(leaderVector3.vector3); 
            }
            
        }
    }

    void GetComponentAwake()
    {
        rigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();
    }
}
