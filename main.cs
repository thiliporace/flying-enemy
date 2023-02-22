using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
        //public bool chase = false;
    public Transform startingPosition;
    private GameObject player;
    private float count;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        count = GetComponent<FlyingEnemy>().count;
    }
    
    void Update()
    {
        if (count>2) // experimental mexer depois
            Chase();
        else 
            ReturntoStartingPosition();
        Flip();
    }

    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0,0,0);
        else
            transform.rotation = Quaternion.Euler(0,180,0);
    }

    void ReturntoStartingPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, startingPosition.position, speed * Time.deltaTime);
    }
}
