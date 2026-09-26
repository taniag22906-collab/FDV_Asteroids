using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PausarJuego : MonoBehaviour
{
    public GameObject menuPausa;
    public bool juegoPausado = false;

    // Update is called once per frame
    void Update(){
        Debug.Log("UPDATE");
        if (Keyboard.current != null && Keyboard.current.pKey.wasPressedThisFrame){
            if (juegoPausado){
                Reanudar();
            }
            else {
                Pausar();
            }    
        }
    }

    public void Reanudar(){
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }

    public void Pausar(){
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
    }
}
