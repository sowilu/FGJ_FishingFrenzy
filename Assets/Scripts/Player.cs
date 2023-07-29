using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput), typeof(AudioSource))]
public class Player : MonoBehaviour
{
    public float speed = 15;

    [Header("Sound settings")]
    public float idleSoundLevel = 0.5f;
    public float moveSoundLevel = 1f;
    
    private PlayerInput playerInput;
    private Vector2 input;
    private AudioSource audioSource;
    
    
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = idleSoundLevel;
    }
    

    private void Update()
    {
        //get input from player input
        input = playerInput.actions["Move"].ReadValue<Vector2>();
        transform.position += new Vector3(input.x, 0, input.y) * speed * Time.deltaTime;
        
        //rotate towards move idrection
        if (input != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(-new Vector3(input.x, 0, input.y));
            audioSource.volume = moveSoundLevel;
        }
        else
        {
            audioSource.volume = idleSoundLevel;
        }
    }
}
