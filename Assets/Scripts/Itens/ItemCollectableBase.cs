using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{

    public string compareTag = "Player";
    //public ParticleSystem particleSystem;
    public float timeToHide = 3;
    private GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
      //  if (particleSystem != null)
     //   {
      //      particleSystem.transform.SetParent(null);
     //   }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect(GetGraphicItem());
        }
    }

    protected virtual GameObject GetGraphicItem()
    {
        return graphicItem;
    }

    protected virtual void Collect(GameObject graphicItem)
    {
        graphicItem = this.gameObject;
        if(graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject",timeToHide);
        OnCollect();
        
    }


    protected virtual void OnCollect()
    {
     //   if (particleSystem != null) particleSystem.Play();
        if (audioSource != null)
        {
            audioSource.transform.parent = null;
            audioSource.Play();
            Destroy(audioSource.gameObject, 3f);
        }
        
        
    }
}