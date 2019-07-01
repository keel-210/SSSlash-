using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationCreater : MonoBehaviour
{
    [SerializeField] public List<GameObject> ConversationMessage = new List<GameObject>();
    [SerializeField] bool IsBossConversation = false;
    public GameObject currentObject;
    void Update()
    {
        if (currentObject == null && ConversationMessage.Count == 0 && IsBossConversation)
        {
            GameObject.FindGameObjectWithTag(TagName.BossSettings)
                .GetComponent<BossEvents>().FightStart();
            this.enabled = false;
        }
        if (currentObject == null && ConversationMessage.Count != 0)
        {
            currentObject = Instantiate(ConversationMessage[0]);
            currentObject.transform.parent = transform;
            currentObject.transform.localPosition = transform.position;
            ConversationMessage.RemoveAt(0);
        }
    }
}