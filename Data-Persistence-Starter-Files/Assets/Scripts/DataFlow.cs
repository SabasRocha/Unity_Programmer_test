using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class DataFlow : MonoBehaviour
{
    public static DataFlow Instance;

    public TextMeshProUGUI textUI;
    public TextMeshProUGUI scoreUI;
    string numberString;
    [SerializeField] TMP_InputField inputField;

    public string userInput;
    public string Nombre;
    public int score;// new variable declared
    public int highScore = 0;// new variable declared


    private void Awake()
      {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
      }

    private void Start()
    {
        inputField = GameObject.FindGameObjectWithTag("Name").GetComponent<TMP_InputField>();
        scoreUI = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        textUI = GameObject.FindGameObjectWithTag("BestScore").GetComponent<TextMeshProUGUI>();
        RefreshScore();
        NewName();
        
    }

    public void NewName()
    {

        textUI.text = "Nombre: " + DataFlow.Instance.Nombre + "Score: " + numberString;
    }

    public void RefreshScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }
        numberString = Convert.ToString(DataFlow.Instance.highScore);
    }

    public void InputName()
    {
        inputField.onValueChanged.AddListener(UpdateString);
    }
    public void UpdateString(string input) 
    {
        userInput = input;
        DataFlow.Instance.Nombre = userInput;
        textUI.text = "Nombre: " + DataFlow.Instance.Nombre + "Score: " + numberString;
        Debug.Log(input);
    }
}

