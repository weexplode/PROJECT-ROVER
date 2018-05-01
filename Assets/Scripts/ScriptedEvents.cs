using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptedEvents : MonoBehaviour {

    public Bloop bloop;
    public Console console;
    public TabHelp tabHelp;
    public PlayerController player;
    public BoxCollider nurseryDoor;
    public BoxCollider commandDoor;
    public Image endImage;
    public Text endText;


    public float timer = 8;
    // gameStep 0 = start
    // 1 = received console startup
    // 2 = received diagnostics
    // 3 = visited command before nursery
    // 4 = visited nursery
    // 5 = completed nursery puzzle
    // 6 = 
    // 7 = game ending
    public int gameStep = 0;

    private void Start()
    {
        console.PrintLine("~START");
        console.PrintLine("BOOTING UP...");
    }

    public void FadeToBlack()
    {
        player.enabled = false;
        console.enabled = false;
        gameStep = 7;
        timer = 10;
    }

    // Update is called once per frame
    void Update () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if(gameStep == 7)
            {
                endImage.color = new Color(0, 0, 0, Math.Min((10 - timer) / 5, 1));
                endText.color = new Color(255, 255, 255, Math.Min((10 - timer) / 5, 1));
            }
            if (timer < 0)
            {
                if (gameStep == 0)
                {
                    if (!player.consoleEnabled)
                        bloop.enabled = true;
                    console.PrintLine("HELLO. WELCOME TO MARSOS.");
                    console.PrintLine("");
                    gameStep++;
                    timer = 8;
                    tabHelp.enabled = true;
                }
                else if (gameStep == 1)
                {
                    if(!player.consoleEnabled)
                        bloop.enabled = true;
                    console.PrintLine("AUTOMATIC DIAGNOSTICS COMPLETE.");
                    console.PrintLine("FACILITIES STATUS:");
                    console.PrintLine("    NURSERY: OPEN, CONNECTION ERROR");
                    console.PrintLine("    COMMAND CENTER: DOOR LOCKED, CONNECTION ERROR");
                    console.PrintLine("    SHUTTLE: ERROR, CANNOT RUN DIAGNOSTICS");
                    console.PrintLine("    SHUTTLE DOOR: ERROR");
                    console.PrintLine("");
                    console.PrintLine("LAST CONTACT: 99999 DAYS AGO");
                    console.PrintLine("");
                    gameStep++;
                } else if(gameStep == 7)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
	}

    public void Trigger(string name)
    {
        if(name == "command" && gameStep < 3)
        {
            gameStep = 3;
            if (!player.consoleEnabled)
                bloop.enabled = true;
            console.PrintLine("ANALYSIS: COMMAND CENTER DOOR LOCKED.");
            console.PrintLine("A NEARBY CONTROL CONSOLE MAY BE ABLE TO OVERRIDE THE LOCK.");
            console.PrintLine("");
        }
        else if(name == "nursery" && gameStep < 4)
        {
            gameStep = 4;
            if (!player.consoleEnabled)
                bloop.enabled = true;
            console.PrintLine("ANALYSIS: CENTER MODULE DOOR LOCKED.");
            console.PrintLine("DOOR CONTROLS SHOULD BE IN THIS ROOM.");
            console.PrintLine("");
        }
    }

    int[] buttons = new int[3];

    public string ButtonPress(int num, Light light)
    {
        if(num == 4)
        {
            gameStep = 6;
            commandDoor.enabled = true;
            light.color = Color.blue;
            return "COMMAND CENTER DOOR OVERRIDE ENGAGED. DOOR UNLOCKED.";
        }
        if (gameStep > 4) return "NO RESPONSE.";
        if(buttons[0] == 0 && num == 3)
        {
            buttons[0] = 3;
            light.color = Color.green;
        
        } else if(buttons[0] == 3 && buttons[1] == 0 && num == 1)
        {
            buttons[1] = 1;
            light.color = Color.green;
        } else if(buttons[0] == 3 && buttons[1] == 1 && buttons[2] == 0 && num == 2)
        {
            buttons[2] = 2;
            foreach (Button b in FindObjectsOfType<Button>())
                if(b.num < 4)
                    b.GetComponentInChildren<Light>().color = Color.blue;
            gameStep = 5;
            nurseryDoor.enabled = true;
            return "CENTER MODULE DOOR UNLOCKED.";
        } else
        {
            foreach (Button b in FindObjectsOfType<Button>())
                if(b.num < 4)
                    b.GetComponentInChildren<Light>().color = Color.red;
            buttons = new int[3];
            return "INCORRECT ORDER. BUTTONS RESET.";
        }
        return "ACTIVATED.";
    }
}
