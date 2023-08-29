using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanels : MonoBehaviour
{
    public GameObject OpenPanel;
    public GameObject ClosePanel;

    public void OpenPan()
    {
        if (OpenPanel != null)
        {
            OpenPanel.SetActive(true);
            ClosePanel.SetActive(false);
        }
    }
}
