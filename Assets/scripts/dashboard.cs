using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System;

public class dashboard : MonoBehaviour
{
    public InputField inputname;
    public InputField inputregt;
    public InputField inputserviceyear;
    public GameObject displayPanel;
    public Text prompttext;
  
    

    private db databaseManager;
    private string connectionstring;
    void Start()
    {
       prompttext.gameObject.SetActive(false);
        displayPanel.SetActive(false);
        databaseManager = GetComponent<db>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SubmitData()
    {
        string playerName = inputname.text;
        int regt = 0;
        int serviceyear = 0;

        //int regt = int.Parse(inputregt.text);
        //int serviceyear = int.Parse(inputserviceyear.text);
        if (!IsAlphabetic(playerName))
        {
            Debug.Log("Invalid name: Must be alphabetic characters only");
            return;
        }
        try
        {
            regt = int.Parse(inputregt.text);
        }
        catch (FormatException)
        {
            Debug.Log("Invalid regt: Must be a valid integer");
            return;
        }
        try
        {
            serviceyear = int.Parse(inputserviceyear.text);
        }
        catch (FormatException)
        {
            Debug.Log("Invalid service year: Must be a valid integer");
            return;
        }

        databaseManager.insertstudentdata(playerName, regt, serviceyear);
        Debug.Log("data send to insert stu ");

        inputname.text = "";
        inputregt.text = "";
        inputserviceyear.text = "";
        prompt();



    }
    public void OnReadDataButtonClicked()
    {
        Debug.Log("read button clicked");
        databaseManager.ReadStudentData(); // Call the method to read data
    }
   
    public void CloseDisplayPanel()
    {
        displayPanel.SetActive(false); // Close the display panel
    }
    private bool IsAlphabetic(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
        }
        return true;
    }
    public void prompt()
    {  
      
        prompttext.gameObject.SetActive(true);
        Invoke("stopprompt", 2.0f);
    }
    public void stopprompt()
    {

        prompttext.gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
