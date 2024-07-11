using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Camera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            PauseToggle();
        }
    }
    public void PauseToggle(){
        bool isActive = Panel.activeSelf;
        if (Panel != null){
            Panel.SetActive(!isActive);
            if (isActive == false){
                Player.GetComponent<Movement>().enabled = false;
                Camera.GetComponent<Look>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
            } else if (isActive == true){
                Player.GetComponent<Movement>().enabled = true;
                Camera.GetComponent<Look>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
    public void Quit(){
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
