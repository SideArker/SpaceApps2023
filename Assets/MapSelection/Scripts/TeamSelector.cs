using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TeamSelector : MonoBehaviour
{

    [SerializeField] int maxAstronautCount = 5;

    public static List<int> astronauts = new List<int>();

    [SerializeField] TMP_Text[] counters = new TMP_Text[6];
    [SerializeField] TMP_Text countText;
    [SerializeField] GameObject hoverTip;
    [SerializeField] Animator screenFade;

    [SerializeField] Color maxColor;
    [SerializeField] Color normalColor;

    public static int GetCountOfAstronaut(int id)
    {
        return astronauts.FindAll(x => x == id).Count;
    }
    /// <summary>
    /// Add an astronaut if limti is not met
    /// </summary>
    /// <param name="astronautID"> id of the astronaut (0 - geologist, 1 - biologist, 2 - engineer
    /// 3 - astrophysicist, 4 - explorer, 5 - medic)</param>
    /// 

    public void SpawnHoverTip()
    {
        CanvasScaler scaler = GetComponentInParent<CanvasScaler>();
        hoverTip.transform.position = new Vector2(Input.mousePosition.x * scaler.referenceResolution.x / Screen.width * 1.225f, Input.mousePosition.y * scaler.referenceResolution.y / Screen.height);
    }
    void updateCounters()
    {
        countText.text = astronauts.Count.ToString() + "/" + maxAstronautCount;

        if (astronauts.Count >= maxAstronautCount) countText.color = maxColor;
        else countText.color = normalColor;
    }

    public void addAstronaut(int astronautID)
    {
        if (astronauts.Count < maxAstronautCount) astronauts.Add(astronautID);
        counters[astronautID].text = astronauts.FindAll(x => x == astronautID).Count.ToString();
        updateCounters();
    }

    public void removeAstronaut(int astronautID)
    {
        if (astronauts.Any(x => x == astronautID))
        {
            astronauts.Remove(astronautID);
        }
        counters[astronautID].text = astronauts.FindAll(x => x == astronautID).Count.ToString();
        updateCounters();
    }

    public void StartMission()
    {
        if (astronauts.Count >= maxAstronautCount)
        {
            screenFade.Play("ScreenFadeGame");
        }
    }
}
