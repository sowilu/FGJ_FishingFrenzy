using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tenticle : MonoBehaviour
{
    public float speed = 15;
    public float time = 3;
    private bool dash = false;
    void Start()
    {
        transform.DOMoveY(0, time).SetEase(Ease.InOutSine).OnComplete(()=>StartCoroutine(Attack()));
    }

    private void Update()
    {
        if (dash)
        {
            //move forward
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(time);
        
        //find all objects tagged player
        var players = GameObject.FindGameObjectsWithTag("Player");
        
        //if no players found, return
        if (players.Length == 0)
        {
            transform.DOMoveY(-30, time).SetEase(Ease.InOutSine).OnComplete(()=>Destroy(gameObject));
        }
        else
        {
            //find nearest player
            var nearestPlayer = players[0];
            foreach (var player in players)
            {
                if (Vector3.Distance(transform.position, player.transform.position) <
                    Vector3.Distance(transform.position, nearestPlayer.transform.position))
                {
                    nearestPlayer = player;
                }
            }

            //rotate so that tenticle is facing player
            transform.rotation = Quaternion.LookRotation(nearestPlayer.transform.position - transform.position);


            dash = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //ignore sea
        if (other.gameObject.CompareTag("Sea"))
        {
            return;
        }
        
        //if player is hit add force to player
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 1000);
        }

        transform.DOMoveY(-30, time).SetEase(Ease.InOutSine).OnComplete(()=>Destroy(gameObject));
        
    }
}
