using UnityEngine;

public class LightCommands : MonoBehaviour
{
    //Renderer is gonna be used a lot so made into a variable
    public Renderer rend;

    // initializing light color and getting the renderer of the gameObject
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
        //set color to white (off)
        
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        rend.material.color = Color.yellow;
    }

    // Called by SpeechManager when the user says the "Reset world" command
    void OnReset()
    {
        //reset color to white
        rend.material.color = Color.white;
    }

    void OnRed()
    {
        //Set color to red
        rend.material.color = Color.red;
    }

    void OnTurnOn()
    {
        //set color to yellow (On)
        rend.material.color = Color.yellow;
    }

    void OnBlue()
    {
        //set color to blue
        rend.material.color = Color.blue;
    }
}