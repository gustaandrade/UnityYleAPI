using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class YleSearchAPI : MonoBehaviour
{
    public GameObject LoadingPanel;

    public List<YleSearchObject.Data> ResponseDataObjectsList = new List<YleSearchObject.Data>();
    public YleSearchObject.MetaData MetaData;

    [HideInInspector] public bool IsRequestLoading;

    private DynamicScroll _scroll;

    private void Start()
    {
        _scroll = GetComponent<DynamicScroll>();
    }

    public void BeginSearch(int limit = 10, string query = null, int offset = 0)
    {
        StartCoroutine(YleGetRequest(YleHelper.GetYleProgramSearchUri(limit, query, offset)));
    }

    private IEnumerator YleGetRequest(string uri)
    {
        IsRequestLoading = true;
        LoadingPanel.SetActive(true);

        using (var webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page to load and return the response
            yield return webRequest.SendWebRequest();

            IsRequestLoading = false;

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.LogWarning($"Error: {webRequest.error}");
            }
            else
            {
                Debug.Log($"Success: {webRequest.downloadHandler.text}");
                OnDataReceived(YleSearchObject.FromJson(webRequest.downloadHandler.text));
            }
        }

        LoadingPanel.SetActive(false);
    }

    private void OnDataReceived(YleSearchObject yleObject)
    {
        MetaData = yleObject.meta;
        ResponseDataObjectsList.Clear();

        foreach (var obj in yleObject.data)
        {
            ResponseDataObjectsList.Add(obj);
        }

        _scroll.InstantiateButtonOnScroll(ResponseDataObjectsList);
    }
}
