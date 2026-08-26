using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{
    [SerializeField] private List<Outline> _lights;
    [SerializeField] private List<ObjectInteraction> _objects;



    void Start()
    {
        _lights[0].enabled = true;
        _lights[1].enabled = false;
        _lights[2].enabled = false;

    }

    private void OnEnable()
    {
        foreach (var obj in _objects)
        {
            obj.TakeObject += OnLightObject;
        }
    }

    private void OnDisable()
    {
        foreach (var obj in _objects)
        {
            obj.TakeObject -= OnLightObject;
        }
    }

    private void OnLightObject(int id)
    {
        if (id == 1)
        {
            _lights[0].enabled = false;
            _lights[1].enabled = true;


        }
        

    }
}