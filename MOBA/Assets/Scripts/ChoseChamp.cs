using UnityEngine;
using System.Collections;

public class ChoseChamp : MonoBehaviour
{
    public GameObject canvasSelection;
    public GameObject canvasGUI;
    public GameObject goButton;
    public GameObject Green;
    public GameObject Red;

    private int champSelected = 0;
    private int teamSelected = 0; // 1 for Blue team, 2 for Red team

    public int accessChampSelected()
    {
        return champSelected;
    }

    // Champion choice

    public void chooseGreen() //Choose Blue
    {
        champSelected = 1;
        if (champSelected != 0 && teamSelected != 0)
            goButton.SetActive(true);
    }

    public void chooseRed()
    {
        champSelected = 2;
        if (champSelected != 0 && teamSelected != 0)
            goButton.SetActive(true);
    }

    // Team choice

    public void chooseBlueTeam()
    {
        teamSelected = 1;
        if (champSelected != 0 && teamSelected != 0)
            goButton.SetActive(true);
    }

    public void chooseRedTeam()
    {
        teamSelected = 2;
        if (champSelected != 0 && teamSelected != 0)
            goButton.SetActive(true);
    }

    // Go button

    public void chosen()
    {
        switch (champSelected)
        {
            case 1:
                Green.SetActive(true);
                break;
            case 2:
                Red.SetActive(true);
                break;
        }

        GetComponent<SyncLayerAndTeam>().UpdateAll(teamSelected);

        GetComponent<syncChamp>().CmdSyncChamp(champSelected);
        canvasSelection.SetActive(false);
        canvasGUI.SetActive(true);
    }
}
