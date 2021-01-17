using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipale : MonoBehaviour {
    public void lancerJeu()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void quitterJeu()
    {
        Debug.Log("QUITTER");
        Application.Quit();
    }

    public void controle(){
 
    }

}
