﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurrelExplosion : MonoBehaviour
{
    [SerializeField] private GameObject _burrel;
    [SerializeField] private float _explosionPower;
    [SerializeField] private float _radiusExplosion = 5;
    [SerializeField] private AudioClip _audioExplosion;
    private ParticleSystem _explosion;
    private AudioSource _audioSource;
    private Collider[] _colliders;

    private void Start()
    {
        _explosion = GetComponentInChildren<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Explosion()
    {
        _explosion.Play();
        _audioSource.clip = _audioExplosion;
        _audioSource.Play();
        
        _colliders = Physics.OverlapSphere(transform.position, _radiusExplosion);
        Enemy enemy;
        foreach (var collider in _colliders)
        {
            enemy = collider.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(_explosionPower);
            }
        }
        
        _burrel.SetActive(false);
        
        Destroy(gameObject, 2);
    }

}
