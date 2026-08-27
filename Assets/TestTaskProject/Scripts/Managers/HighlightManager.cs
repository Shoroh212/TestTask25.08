using System;
using System.Collections.Generic;
using UnityEngine;


public class HighlightManager : MonoBehaviour
{
    [SerializeField] private List<Outline> _lights;

    private readonly List<IObjectTakenSource> _objects = new();

    public void Initialize(IEnumerable<IObjectTakenSource> objects)
    {
        _objects.AddRange(objects);

        foreach (var obj in _objects)
        {
            obj.ObjectTaken += OnLightObject;
        }
    }

    private void OnDestroy()
    {
        foreach (var obj in _objects)
        {
            obj.ObjectTaken -= OnLightObject;
        }
    }

    private void Start()
    {
        _lights[0].enabled = false;
        _lights[1].enabled = false;
        _lights[2].enabled = false;
    }

    public  void OnLightObject(int id)
    {
        Debug.LogError("МЫ получили id  " + id);
        switch (id)
        {
            case 1:
                Debug.LogWarning("МЫ красим ");
                _lights[0].enabled = false;
                _lights[1].enabled = true;
                break;

            case 2:
                _lights[1].enabled = false;
                _lights[2].enabled = true;
                break;

            case 3:
                _lights[2].enabled = false;
                break;
        }
    }
}



public interface IObjectTakenSource
{
    event Action<int> ObjectTaken;
}