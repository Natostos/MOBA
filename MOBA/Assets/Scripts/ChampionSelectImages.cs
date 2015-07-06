using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChampionSelectImages : MonoBehaviour
{
    public Image championSelec;
    public Image championSelecIG;

    public Sprite blue;
    public Sprite red;

    public void changeToBlue()
    {
        championSelec.sprite = blue;
        championSelecIG.sprite = blue;
    }

    public void changeToRed()
    {
        championSelec.sprite = red;
        championSelecIG.sprite = red;
    }
}
