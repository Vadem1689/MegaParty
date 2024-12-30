using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatScreen : MonoBehaviour
{
    private const string LastTrainKeyPrefix = "LastTrain_";

    [SerializeField] private LastTrain[] _lastTrains;
    [SerializeField] private Transform _content;
    [SerializeField] private TMP_Text _stepText;
    [SerializeField] private TMP_Text _kcalText;
    [SerializeField] private TMP_Text _durationText;

    private List<LastTrain> _lastTrainList = new List<LastTrain>();
    private int _currentKcal;
    private int _currentSteps;
    private int _currentDuration;

    private void OnEnable()
    {
        LoadSavedData();
        ShowInfo();
    }

    public void AddLastWorkout(int index)
    {
        LastTrain last = Instantiate(_lastTrains[index], _content);

        if (_lastTrainList.Count >= 3)
        {
            LastTrain oldest = _lastTrainList[0];
            _lastTrainList.RemoveAt(0);
            Destroy(oldest.gameObject);
        }

        _lastTrainList.Add(last);
        SaveCurrentData();
        ShowInfo();
    }

    private void ShowInfo()
    {
        if (_lastTrainList.Count <= 0)
            return;

        _currentKcal = 0;
        _currentSteps = 0;
        _currentDuration = 0;

        foreach (var last in _lastTrainList)
        {
            _currentKcal += last.Kcal;
            _currentSteps += last.Steps;
            _currentDuration += last.Duration;
        }

        _stepText.text = $"Steps: \n{_currentSteps.ToString()}";
        _kcalText.text = $"Kcal: \n{_currentKcal.ToString()}";
        _durationText.text = $"Duration: \n{_currentDuration.ToString()}";
    }

    private void SaveCurrentData()
    {
        for (int i = 0; i < _lastTrainList.Count; i++)
        {
            string key = LastTrainKeyPrefix + i;
            PlayerPrefs.SetInt(key + "LastTrainLoad", _lastTrainList[i].Index);
        }

        PlayerPrefs.Save();
    }

    private void LoadSavedData()
    {
        foreach (var last in _lastTrainList)
            Destroy(last.gameObject);
        
        _lastTrainList.Clear();
        
        for (int i = 0; i < 3; i++)
        {
            string key = LastTrainKeyPrefix + i;
            int index = PlayerPrefs.GetInt(key + "LastTrainLoad", -1);

            if (index != -1)
            {
                LastTrain last = Instantiate(_lastTrains[index], _content);
                _lastTrainList.Add(last);
            }
        }
    }
}