using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpPanelManager : MonoBehaviour
{
    public GameObject helpPanel; // ���� �ǳ��� ����Ű�� ����

    private bool isHelpPanelActive = false; // ���� �ǳ��� Ȱ��ȭ ���θ� ��Ÿ���� ����

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
