using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string sceneName = "New Scene name here";
    
    public bool isAutomatic;
    
    public string uuid; // uuid = universal unique identifier
    
    private bool manualEnter;
    private void Update(){
        if (!isAutomatic && !manualEnter){
            manualEnter = Input.GetButtonDown("Fire1");
        }
    }
    
    // Teleport automático
    private void OnTriggerEnter2D(Collider2D other){
        Teleport(other.name);
    }
    
    // Teleport manual
    private void OnTriggerStay2D(Collider2D other){
        Teleport(other.name);
    }
    
    private void Teleport(string objName){
        if (objName == "Player"){ 
            if (isAutomatic || (!isAutomatic && manualEnter))
            {
                FindObjectOfType<PlayerController>().nextUuid = uuid;
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
