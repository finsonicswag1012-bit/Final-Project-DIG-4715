using UnityEngine;
using System.Collections.Generic;

public class FloorSwitch_Trigger : MonoBehaviour
{
    [SerializeField] private GameObject invisibleWallReference;
private static GameObject invisibleWall;
    // -------- STATIC GLOBAL TRACKING --------
    private static List<FloorSwitch_Trigger> allSwitches = new List<FloorSwitch_Trigger>();
    private static int totalOn = 0;
    private static bool allLocked = false;

    // Assign this in ONE switch (or make static if preferred)
    public static GameObject Invisible_Wall;

    // -------- INSTANCE STATE --------
    private bool isOn = false;
    private bool playerOnSwitch = false;

    // -------- VISUALS --------
    private Renderer rend;

    public Color offColor = Color.red;
    public Color onColor = Color.green;
    public Color lockedColor = new Color(1f, 0.84f, 0f); // gold

    void Awake()
    {
        allSwitches.Add(this);
       

    if (invisibleWallReference != null)
    {
        invisibleWall = invisibleWallReference;
    }

    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        UpdateColor();
    }

    void OnDestroy()
    {
        allSwitches.Remove(this);
    }

    // -------- TRIGGER LOGIC --------
    void OnTriggerEnter(Collider other)
    {
        if (allLocked) return;

        if (other.CompareTag("Player"))
        {
            if (!playerOnSwitch)
            {
                playerOnSwitch = true;
                ToggleSwitch();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnSwitch = false;
        }
    }

    // -------- TOGGLE LOGIC --------
    void ToggleSwitch()
    {
        isOn = !isOn;

        if (isOn)
            totalOn++;
        else
            totalOn--;

        UpdateColor();
        CheckAllSwitches();

        Debug.Log("On: " + totalOn + " / Total: " + allSwitches.Count);
    }

    // -------- GLOBAL CHECK --------
    void CheckAllSwitches()
    {
        if (totalOn == allSwitches.Count && !allLocked)
        {
            LockAllSwitches();
        }
    }

    void LockAllSwitches()
    {
        allLocked = true;

        foreach (FloorSwitch_Trigger sw in allSwitches)
        {
            sw.SetLockedState();
        }

        // Disable the wall (only works if assigned on one switch)
        if (Invisible_Wall != null)
        {
            Invisible_Wall.SetActive(false);
        }

        Debug.Log("All switches activated!");

        if (Invisible_Wall != null)
{
    Invisible_Wall.SetActive(false);
    Debug.Log("Wall disabled");
}
else
{
    Debug.LogError("Invisible Wall NOT assigned!");
}
    }

    void SetLockedState()
    {
        isOn = true;
        UpdateColor();
    }

    // -------- VISUAL UPDATE --------
    void UpdateColor()
    {
        if (rend == null) return;

        if (allLocked)
            rend.material.color = lockedColor;
        else
            rend.material.color = isOn ? onColor : offColor;
    }

    
}