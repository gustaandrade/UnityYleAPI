using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class YleButtonHandler : MonoBehaviour
{
    private GameObject _informationPanel;
    private Text _title;
    private Text _description1;
    private Text _description2;
    private Text _description3;
    private Text _description4;
    private Text _description5;

    private YleSearchObject.Data _data;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        _informationPanel = GameObject.FindGameObjectWithTag("Information").transform.Find("Information").gameObject;
        _title = _informationPanel.transform.GetChild(0).gameObject.GetComponent<Text>();
        _description1 = _informationPanel.transform.GetChild(1).gameObject.GetComponent<Text>();
        _description2 = _informationPanel.transform.GetChild(2).gameObject.GetComponent<Text>();
        _description3 = _informationPanel.transform.GetChild(3).gameObject.GetComponent<Text>();
        _description4 = _informationPanel.transform.GetChild(4).gameObject.GetComponent<Text>();
        _description5 = _informationPanel.transform.GetChild(5).gameObject.GetComponent<Text>();

        _button.onClick.AddListener(LoadInformationPanel);
    }

    public void SetButtonYleData(YleSearchObject.Data data)
    {
        _data = data;
    }

    private void LoadInformationPanel()
    {
        var title = _data.title.fi;
        if (string.IsNullOrWhiteSpace(title)) title = _data.title.und;
        if (string.IsNullOrWhiteSpace(title)) title = _data.title.sv;
        if (string.IsNullOrWhiteSpace(title)) title = "<Empty Title>";
        _title.text = title;

        _description1.text = $"ID: {_data.id}";
        _description2.text = $"Type: {_data.type}";
        _description3.text = $"Type Media: {_data.typeMedia}";
        _description4.text = $"Start 1st Publication: {_data.publicationEvent.FirstOrDefault().startTime}";
        _description5.text = $"End 1st Publication: {_data.publicationEvent.FirstOrDefault().endTime}";

        _informationPanel.SetActive(true);
    }
}
