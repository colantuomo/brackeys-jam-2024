using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission4 : MonoBehaviour
{
    [SerializeField]
    private MissionTracker _missionTracker;
    private bool _tookMedicine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameSettings.Instance.ChangeGameState(GameStates.CutScene);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _tookMedicine = true;
            _missionTracker.ClearObjective();
            GameEvents.Instance.ShowTextPanel("Ah.. estou melhor, agora preciso ver o disjuntor");
            GameSettings.Instance.ChangeGameState(GameStates.Playing);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!_tookMedicine) return;
        _missionTracker.SetNewObjective("Encontre o Disjuntor");
        GameEvents.Instance.CloseTextPanel();
        gameObject.SetActive(false);
    }
}
