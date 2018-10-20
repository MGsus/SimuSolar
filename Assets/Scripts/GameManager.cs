using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private string _scene;
    private int _energy = 0;
    private int _money = 0;
    private float _time = 0;
    public GameObject _tienda_pane;

    // 0 = null ; 1 = running ; 2 = Finished
    private int _gameState = 0;

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

    // Use this for initialization
    void Start()
    {
        _tienda_pane = GameObject.FindGameObjectWithTag("Shop_Pane");
        _tienda_pane.SetActive(false);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        _scene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        _money++;
    }
}