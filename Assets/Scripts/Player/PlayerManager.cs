using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;


public class PlayerManager : Singleton<PlayerManager>
{
    public float speed = 10f;

    [Header("Lerp")]
    public Transform target;
    public GameObject startScreen;
    public GameObject endScreen;
    public float lerpSpeed = 0.1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    public bool _canRun;
    public TextMeshProUGUI uiTextPowerUp;

    private bool invencible = false;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }


    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.x = transform.position.x;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            EndGame();
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine || other.transform.tag == tagToCheckEnemy)
        {
            if (!invencible) EndGame();
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

    #region POWER UPS
    public void SetPowerUpText(string v)
    {
        uiTextPowerUp.text = v;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void PowerUpInvencible()
    {
        invencible = true;
    }
    public void ResetInvencible()
    {
        invencible = false;
    }
    public void PowerUpJump()
    {
      // transform.DOMoveY();
    }
    public void ResetJump()
    {
       
    }

    #endregion
}
