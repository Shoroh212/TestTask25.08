using System.Collections.Generic;
using UnityEngine;

public class OrderInteractionBinder : MonoBehaviour
{
    [SerializeField] private ObjectInteraction[] _objects;
    [SerializeField] private OrderManager _orderManager;
    [SerializeField] private HighlightManager _highlightManager;
    

    private void OnEnable()
    {
        foreach (var obj in _objects)
        {
            obj.ObjectTaken += OnObjectTaken;
        }

    
    }

    private void OnDisable()
    {
        foreach (var obj in _objects)
        {
            obj.ObjectTaken -= OnObjectTaken;
        }
    }

    private void OnObjectTaken(int objectId)
    {
        foreach (var obj in _objects)
        {
            if (obj.ObjectId != objectId)
                continue;
            Debug.Log("Выполнился метод OnObjectTaken");
            _highlightManager.OnLightObject(objectId);
            _orderManager.CheckObject(obj.ObjectTag);
            break;
        }
    }
}