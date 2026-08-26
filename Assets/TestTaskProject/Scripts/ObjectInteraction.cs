using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class ObjectInteraction : MonoBehaviour, IObjectInteraction, IObjectTakenSource
{
    [SerializeField] private int _idObject;

    private XRGrabInteractable _grabInteractable;

    public int ObjectId => _idObject;
    public string ObjectTag => gameObject.tag;

    public event Action<int> ObjectTaken;

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
        ObjectTaken?.Invoke(_idObject);
    }
}