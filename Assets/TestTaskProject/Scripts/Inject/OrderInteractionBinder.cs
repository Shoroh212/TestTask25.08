using System.Collections.Generic;
using UnityEngine;



/// <summary> /// 
/// Связывает взаимодействие с игровыми объектами 
/// с проверкой порядка и системой подсветки. </summary>

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
    {// Находим объект по ID и передаём его данные
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