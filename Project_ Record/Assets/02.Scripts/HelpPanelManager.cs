using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpPanelManager : MonoBehaviour
{
    public GameObject helpPanel; // 도움말 판넬을 가리키는 변수

    private bool isHelpPanelActive = false; // 도움말 판넬의 활성화 여부를 나타내는 변수

    public void OnButtonClick()
    {
        if (helpPanel != null)
        {
            helpPanel.SetActive(true);
            isHelpPanelActive = true;
        }
        else
        {
            Debug.LogWarning("HelpPanel not found.");
        }
    }

    public void OnHelpPanelExit()
    {
        helpPanel.SetActive(false);
    }
}
