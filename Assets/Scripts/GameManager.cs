using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    private string _scene;
    private int _money = 5000000;
    private float _time = 0;
    private int _consume=50;
    private int _timeInHh;

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
        set { _money = value; }
    }

    public int _Consume
    {
        get { return _consume; }
        set { _consume = value; }
    }

    public List<int> LogMoney
    {
        get { return logMoney; }
        set { logMoney = value; }
    }

    public int HoraAct
    {
        get { return horaAct; }
        set { horaAct = value; }
    }

    // Use this for initialization
    private void Start()
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
    private void Update()
    {
        // Game Time
        _time += Time.deltaTime*1000;

        // Money per Hour
        MoneyPerHour();
    }

    private int horaAct = 0;
    
    List<int> logMoney = new List<int>();
    private void MoneyPerHour()
    {
        if (HoraAct != ((int) (_time / 3600)))
        {
            // Ingreso
            HoraAct = ((int) (_time / 3600));
            _money += 150000;
            // Pérdida (50 = consumo por hora)
            _money -= 472*50;
        }
        LogMoney.Add(_money);
        
 
    }
}