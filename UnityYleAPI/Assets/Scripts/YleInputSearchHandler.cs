using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YleInputSearchHandler : MonoBehaviour
{
    public YleSearchAPI SearchAPI;
    public DynamicScroll Scroll;
    public GameObject InstructionPanel;
    public GameObject NotFoundPanel;

    private int _appendSearchOffset = 0;
    private InputField _inputField;

    private void Awake()
    {
        _inputField = GetComponent<InputField>();
        _inputField.onEndEdit.AddListener(InitiateSearchAPI);
    }

    private void InitiateSearchAPI(string value)
    {
        if (SearchAPI.IsRequestLoading) return;

        Scroll.DestroyButtonOnScroll();
        InstructionPanel.SetActive(false);
        NotFoundPanel.SetActive(false);
        _appendSearchOffset = 0;
        SearchAPI.BeginSearch(10, value);
    }

    public void ComplementSearchAPI()
    {
        if (SearchAPI.IsRequestLoading) return;

        InstructionPanel.SetActive(false);
        NotFoundPanel.SetActive(false);

        _appendSearchOffset++;
        SearchAPI.BeginSearch(10, _inputField.text, _appendSearchOffset * 10);
    }
}
