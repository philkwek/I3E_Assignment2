/******************************************************************************
Authors: Phil & Elicia
Name of Class: WaterManager
Description of Class: Manages the wave movement
Date Created: 16/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public float amplitutde = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, detroying objects!");
            Destroy(this);
        }
    }
    private void Update()
    {
        offset += Time.deltaTime * speed;
    }
    public float GetWaveHeight(float _x)
    {
        return amplitutde * Mathf.Sin(_x / length + offset);
    }

}
