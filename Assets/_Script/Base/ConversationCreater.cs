using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationCreater : MonoBehaviour
{
    [SerializeField] List<GameObject> ConversationMessage = new List<GameObject>();
    public GameObject currentObject;
    void Update()
    {
        if (currentObject == null && ConversationMessage.Count != 0)
        {
            currentObject = Instantiate(ConversationMessage[0]);
            ConversationMessage.RemoveAt(0);
        }
        //Debug.Log(ConversationMessage[0] + (currentObject == null).ToString());
    }
}