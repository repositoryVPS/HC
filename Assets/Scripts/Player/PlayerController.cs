using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    private Vector3 _pos;
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.x = transform.position.x;


        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
    
}

   
