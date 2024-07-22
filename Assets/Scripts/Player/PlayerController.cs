using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;
    public string tagToCheckEnemy = "Enemy";


    private Vector3 _pos;
    private bool _canRun;

    void Start()
    { 
        _canRun = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.x = transform.position.x;

        transform.Translate(transform.forward * speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            _canRun = false;
        }
    }

}


