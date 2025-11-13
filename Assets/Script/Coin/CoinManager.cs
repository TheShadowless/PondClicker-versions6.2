using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoinManager : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 200f;

    [Header("Lifetime")]
    [SerializeField] private float lifeTime = 4f;          
    [SerializeField] private float clickedLifeTime = 0.1f; 

    [Header("Audio")]
    [SerializeField] private AudioClip soundAwake;
    [SerializeField] private AudioClip soundEnd;

    private AudioSource audioSource;
    private bool isClicked = false;
    private float timer;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    protected virtual void OnEnable()
    {
        isClicked = false;
        timer = lifeTime;
        PlayAwakeSound();
    }

    private void Update()
    {
        MoveDown();
        UpdateLifeTime();
    }

    protected virtual void MoveDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void UpdateLifeTime()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    
    public void OnClick()
    {
        if (isClicked) return;       
        isClicked = true;

        timer = clickedLifeTime;     
        PlayEndSound();

        
        ApplyEffect();
    }

    protected virtual void PlayAwakeSound()
    {
        if (soundAwake != null && audioSource != null)
        {
            audioSource.PlayOneShot(soundAwake);
        }
    }

    protected virtual void PlayEndSound()
    {
        if (soundEnd != null && audioSource != null)
        {
            audioSource.PlayOneShot(soundEnd);
        }
    }

    
    protected abstract void ApplyEffect();
}
