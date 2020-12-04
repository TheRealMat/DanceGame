using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SubMenu : MonoBehaviour
{
    public Button defaultSelection;

    private void OnEnable()
    {
        setDefaultSelection();
    }

    public void setDefaultSelection()
    {
        // select button
        EventSystem.current.SetSelectedGameObject(defaultSelection.gameObject);

        // highlight button
        defaultSelection.OnSelect(null);
    }
}
