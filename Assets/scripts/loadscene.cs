using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class loadscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().enabled = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public string targetSceneName; // The name of the scene to switch to
    public ParticleSystem particles;

    public void LoadSceneOnClick()
    {
        
        SceneManager.LoadScene(targetSceneName);
    }
    
}
