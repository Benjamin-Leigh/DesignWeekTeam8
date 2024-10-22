using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOne : MonoBehaviour
{
    // Switches (booleans to represent their on/off state)
    private bool switch1;
    private bool switch2;
    private bool switch3;

    // The correct combination
    private bool correctSwitch1;
    private bool correctSwitch2;

    // To ensure we only check once
    private bool puzzleCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Randomize the correct combination of switches (two need to be true)
        int combination = Random.Range(1, 4); // There are 3 possible combinations
        switch (combination)
        {
            case 1:
                correctSwitch1 = true;  // switch1 should be on
                correctSwitch2 = true;  // switch2 should be on
                break;
            case 2:
                correctSwitch1 = true;  // switch1 should be on
                correctSwitch2 = false; // switch3 should be on
                break;
            case 3:
                correctSwitch1 = false; // switch2 should be on
                correctSwitch2 = true;  // switch3 should be on
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for keyboard input to toggle the switches
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Press "1" to toggle switch 1
        {
            ToggleSwitch("switch1");
            Debug.Log("Switch 1: " + (switch1 ? "On" : "Off"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) // Press "2" to toggle switch 2
        {
            ToggleSwitch("switch2");
            Debug.Log("Switch 2: " + (switch2 ? "On" : "Off"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) // Press "3" to toggle switch 3
        {
            ToggleSwitch("switch3");
            Debug.Log("Switch 3: " + (switch3 ? "On" : "Off"));
        }
    }

    // This method can be called whenever a switch is toggled
    public void ToggleSwitch(string switchName)
    {
        if (puzzleCompleted) return;

        // Toggle the switch based on the name
        switch (switchName)
        {
            case "switch1":
                switch1 = !switch1;
                break;
            case "switch2":
                switch2 = !switch2;
                break;
            case "switch3":
                switch3 = !switch3;
                break;
        }

        // Check if the correct combination is active
        CheckPuzzle();
    }

    private void CheckPuzzle()
    {
        // Check if the correct two switches are on
        if ((switch1 == correctSwitch1 && switch2 == correctSwitch2) &&
            (switch1 == correctSwitch1 && switch3 == !correctSwitch2) &&
            (switch2 == !correctSwitch1 && switch3 == correctSwitch2))
        {
            Debug.Log("Puzzle Completed!");
            puzzleCompleted = true;
            // Call a method to transition to the next puzzle
            MoveToNextPuzzle();
        }
    }

    private void MoveToNextPuzzle()
    {
        Debug.Log("Moving to Puzzle 2...");
    }
}