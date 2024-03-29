﻿using UnityEngine;

[System.Serializable]
public class YleSearchObject
{
    public MetaData meta;
    public Data[] data;

    public static YleSearchObject FromJson(string jsonData)
    {
        return JsonUtility.FromJson<YleSearchObject>(jsonData);
    }

    [System.Serializable]
    public struct MetaData
    {
        public string offset;
        public string limit;
        public int count;
        public string q;//query
    }

    [System.Serializable]
    public struct Data
    {
        public string id;
        public DualLanguageText title;
        public DualLanguageText description;
        public Image image;

        public string type;
        public string typeMedia;

        public Creator[] creator;
        public PublicationEvent[] publicationEvent;

        [System.Serializable]
        public struct DualLanguageText
        {
            public string und;
            public string fi;
            public string sv;
        }

        [System.Serializable]
        public struct Image
        {
            public string id;
            public bool available;
        }

        [System.Serializable]
        public struct Creator
        {
            public string name;
            public string type;
        }

        [System.Serializable]
        public struct PublicationEvent
        {
            public string startTime;
            public string endTime;
            public Service service;

            [System.Serializable]
            public struct Service
            {
                public string id;
            }
        }
    }
}
