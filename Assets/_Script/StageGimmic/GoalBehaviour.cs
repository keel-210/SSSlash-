﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalBehaviour : MonoBehaviour, ISlide
{
    public List<Vector3> PosHistory { get; set; } = new List<Vector3>();
    void Awake()
    {
        PosHistory.Add(transform.position);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IPlayer>() != null)
            Clear();
    }
    void Clear()
    {
        SceneManager.LoadScene(SceneName.ClearUI, LoadSceneMode.Additive);
        GameObject.FindGameObjectWithTag(TagName.Player).GetComponent<IClear>()?.Clear();
    }
    public void Slide(Vector2 p0, Vector2 p1, bool PlayerSide, Vector3 SlideVec)
    {
        PosHistory.Add(transform.position);
        bool GoalSide = MeshCut2D.IsClockWise(p0.x, p0.y, p1.x, p1.y, transform.position.x, transform.position.y);
        if (PlayerSide && !GoalSide)
            transform.position += SlideVec;
        else if (!PlayerSide && GoalSide)
            transform.position += SlideVec;
    }
    public void Return(Vector2 p0, Vector2 p1, bool PlayerSide)
    {
        bool GoalSide = MeshCut2D.IsClockWise(p0.x, p0.y, p1.x, p1.y, transform.position.x, transform.position.y);
        if (PlayerSide && !GoalSide)
            transform.position = PosHistory.Last();
        else if (!PlayerSide && GoalSide)
            transform.position = PosHistory.Last();
        PosHistory.Remove(PosHistory.Last());
    }
}