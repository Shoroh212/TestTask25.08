using UnityEngine;

public class OrderInteractionBinder : MonoBehaviour
{
    [SerializeField] private ObjectInteraction[] _objects;
    [SerializeField] private OrderManager _orderManager;

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

            _orderManager.CheckObject(obj.ObjectTag);
            break;
        }
    }
}