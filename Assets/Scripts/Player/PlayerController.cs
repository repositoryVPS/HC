using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 100f;
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 10f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    public GameObject startScreen;
    public GameObject endScreen;

    private Vector3 _pos;
    public bool _canRun;

    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.x = transform.position.x;

        transform.Translate(transform.forward * speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        speed++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
        {
            EndGame();
        }
    }

    public void StartToRun()
    {
        _canRun = true;
        startScreen.SetActive(false);
    }
    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }
}


