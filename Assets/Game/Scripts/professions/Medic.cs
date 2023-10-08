using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Medic : MonoBehaviour
{
    [SerializeField] Button btn;
    [SerializeField] Timer timer;
    public static Medic Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public void ChnageBtnState(bool state)
    {
        btn.interactable = state;
    }
    public void Btn()
    {
        print("btn");
        SelectionController.Instance.ChangeButtonsState(false);
        Examinate();
    }
    public void Examinate()
    {
        timer.gameObject.SetActive(true);
        timer.StartTimer();

        if (Engineer.Instance) Engineer.Instance.gameObject.GetComponent<ProfessionPanel>().Heal();
        if (Biologist.Instance) Geologist.Instance.gameObject.GetComponent<ProfessionPanel>().Heal();
        if (Geologist.Instance) Biologist.Instance.gameObject.GetComponent<ProfessionPanel>().Heal();
        if (Observer.Instance) Observer.Instance.gameObject.GetComponent<ProfessionPanel>().Heal();
        if (Diver.Instance) Diver.Instance.gameObject.GetComponent<ProfessionPanel>().Heal();
        if (Medic.Instance) Medic.Instance.gameObject.GetComponent<ProfessionPanel>().Heal();


        print("XD");
    }
    public void OnEnd()
    {
        SelectionController.Instance.ChangeButtonsState(true);
    }

}
