using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalBehaviour : MonoBehaviour
{
    private static GoalBehaviour instance;
    public static GoalBehaviour Instance
    {
        get
        {
            if (instance == null)
            {
                Type t = typeof(GoalBehaviour);

                instance = (GoalBehaviour)FindObjectOfType(t);
                if (instance == null)
                {
                    Debug.LogError(t + " をアタッチしているGameObjectはありません");
                }
            }

            return instance;
        }
    }

    virtual protected void Awake()
    {
        // 他のゲームオブジェクトにアタッチされているか調べる
        // アタッチされている場合は破棄する。
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = this as GoalBehaviour;
            instance.SetParentByRay();
            return true;
        }
        else if (Instance == this)
        {
            instance.SetParentByRay();
            return true;
        }
        Destroy(this.gameObject);
        return false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IPlayer>() != null)
            Clear();
    }
    void Clear()
    {
        SceneManager.LoadScene("ClearUI", LoadSceneMode.Additive);
    }
    void SetParentByRay()
    {

    }
}