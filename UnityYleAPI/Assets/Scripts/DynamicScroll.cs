using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicScroll : MonoBehaviour
{
    public ScrollRect ScrollView;
    public GameObject ScrollContent;
    public GameObject ScrollButtonPrefab;
    public GameObject NotFoundPanel;

    public YleInputSearchHandler SearchHandler;

    public void Update()
    {
        if (ScrollView.verticalNormalizedPosition <= 0.1f && ScrollContent.transform.childCount > 0)
        {
            SearchHandler.ComplementSearchAPI();
        }
    }

    public void InstantiateButtonOnScroll(List<YleSearchObject.Data> data)
    {
        foreach (var obj in data)
        {
            var title = obj.title.fi;
            if (string.IsNullOrWhiteSpace(title)) title = obj.title.und;
            if (string.IsNullOrWhiteSpace(title)) title = obj.title.sv;
            if (string.IsNullOrWhiteSpace(title)) title = "<Empty Title>";

            var scrollObj = Instantiate(ScrollButtonPrefab);
            scrollObj.GetComponentInChildren<Text>().text = title;
            scrollObj.GetComponent<YleButtonHandler>().SetButtonYleData(obj);
            scrollObj.transform.SetParent(ScrollContent.transform, false);
        }

        ScrollView.verticalNormalizedPosition = 1;

        if (data.Count == 0)
            NotFoundPanel.SetActive(true);
    }

    public void DestroyButtonOnScroll()
    {
        foreach (Transform child in ScrollContent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
