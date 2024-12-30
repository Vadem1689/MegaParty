using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWorkoutToday : AbstractButton
{
    [SerializeField] private int _index;
    [SerializeField] private TodayContent _todayContent;
    [SerializeField] private GameObject _screen;
    
    protected override void OnClick()
    {
        _todayContent.AddWorkout(_index);
        _screen.SetActive(false);
    }
}