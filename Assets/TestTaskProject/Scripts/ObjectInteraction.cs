using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private OrderManager _orderManager;
    [SerializeField] private int _idObject;

    private XRGrabInteractable _grabInteractable;
    public event Action<int> TakeObject;

    private void Awake()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        _grabInteractable.selectEntered.AddListener(OnObjectGrabbed);
    }

    private void OnDisable()
    {
        _grabInteractable.selectEntered.RemoveListener(OnObjectGrabbed);
    }

    private void OnObjectGrabbed(SelectEnterEventArgs args)
    {
        string objectTag = gameObject.tag;

        _orderManager.CheckObject(objectTag);
        TakeObject?.Invoke(_idObject);
    }
}