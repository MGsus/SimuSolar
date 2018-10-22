using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    private string _scene;
    private int _energy = 0;
    private int _money = 5000000;
    private float _time = 0;

    // 0 = null ; 1 = running ; 2 = Finished
    [SerializeField] private int _gameState = 0;

    public float _Time
    {
        get { return _time; }
        set { _time += value; }
    }

    public int _Money
    {
        get { return _money; }
        set { _money += value; }
    }

    // Use this for initialization
    void Start()
    {
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            _gameState = 2;
        }

        DontDestroyOnLoad(gameObject);
        _scene = SceneManager.GetActiveScene().name;
        _gameState = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime*1000;
        if (Math.Abs(_time - 1296000) < 0.01f || Math.Abs(_time) < 0.001f)
        {
            _money += 5000000;
        }
    }
}