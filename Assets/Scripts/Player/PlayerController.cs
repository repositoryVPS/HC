using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

namespace PlayerController
{

    public class PlayerController : Singleton<PlayerController>
    {
        public float speed = 100f;
        
        [Header("Lerp")]
        public Transform target;
        public float lerpSpeed = 10f;
        public string tagToCheckEnemy = "Enemy";
        public string tagToCheckEndLine = "EndLine";
        public GameObject startScreen;
        public GameObject endScreen;
        public bool _canRun;

        
        private Vector3 _pos;
        private float _currentSpeed;
        private Transform _startPosition;
        public TextMeshProUGUI uiTextPowerUp;

        void Start()
        {
         //   _startPosition = transform.position;
            ResetSpeed();
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

        public void SetPowerUpText(string s)
        {
            uiTextPowerUp.text = s;
        }
        public void PowerUpSpeedUp(float f)
        {
            _currentSpeed = f;
        }
        public void ResetSpeed()
        {
            _currentSpeed = speed;
        }
    }
}