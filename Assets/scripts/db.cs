using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data.Common;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
using System;
using UnityEngine.UI;

public class db : MonoBehaviour
{
    public GameObject displayPanel;
    public Text displayTextname;
    public Text displayTextregt;
    public Text displayTextservice;

    private string connectionstring;
    void Start()
    {
        connectionstring = "URI=file:" + Application.dataPath + "/StreamingAssets/students.db";
       


    }
   public void insertstudentdata(string studentname, int sturegt,int stuserviceyear)
    {
        using(var dbconnection=new  SqliteConnection(connectionstring))
        {
            dbconnection.Open();
            using (var dbCommandCreateTable = dbconnection.CreateCommand())
            {
                dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS student_record (name TEXT, regt INTEGER, serviceyear INTEGER)";
                dbCommandCreateTable.ExecuteNonQuery();
            }
            using (var dbcommand = dbconnection.CreateCommand())
            {
                dbcommand.CommandText = "INSERT INTO student_record (name, regt, serviceyear) VALUES (@name, @regt, @serviceyear)";

                dbcommand.Parameters.AddWithValue("@name", studentname);
                dbcommand.Parameters.AddWithValue("@regt", sturegt);
                dbcommand.Parameters.AddWithValue("@serviceyear", stuserviceyear);

                dbcommand.ExecuteNonQuery();
            }
            dbconnection.Close();
        }
    }
    public void ReadStudentData()
    {
        List<string> names = new List<string>();
        List<int> regts = new List<int>();
        List<int> serviceYears = new List<int>();
        using (var dbconnection = new SqliteConnection(connectionstring))
        {
            dbconnection.Open();
            using (var dbcommand = dbconnection.CreateCommand())
            {
                dbcommand.CommandText = "SELECT * FROM student_record";

                using (var reader = dbcommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(reader.GetOrdinal("name"));
                        int regt = reader.GetInt32(reader.GetOrdinal("regt"));
                        int serviceyear = reader.GetInt32(reader.GetOrdinal("serviceyear"));
                        names.Add(name);
                        regts.Add(regt);
                        serviceYears.Add(serviceyear);


                        // Process retrieved data (e.g., store in a list, display, etc.)
                        Debug.Log($"Name: {name}, Regt: {regt}, Service Year: {serviceyear}");
                        
                       

                    }
                }
            }
            dbconnection.Close();
        }
        ShowInputData(names, regts, serviceYears);
    }

    void ShowInputData(List<string> playerNames, List<int> regts, List<int> serviceYears)
    {
        displayPanel.SetActive(true); // Activate the display panel

        displayTextname.text = "";
        displayTextregt.text = "";
        displayTextservice.text = "";

        for (int i = 0; i < playerNames.Count; i++)
        {
            displayTextname.text += $"{playerNames[i]}\n"; // Appending each player name
            displayTextregt.text += $"{regts[i]}\n"; // Appending each registration number
            displayTextservice.text += $"{serviceYears[i]}\n"; // Appending each service year
        }

        Debug.Log("Text displayed for all rows");
    }
    




}
