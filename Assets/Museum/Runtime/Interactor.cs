using System;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 0.25f;
    [SerializeField] private FixedJoint holder;

    public Vector3 originOffset = Vector3.zero;

    private int _layerMask;
    private readonly Collider[] _colliders = new Collider[1];
    private Vector3 Origin => transform.position + originOffset;
    public InteractionState State { get; private set; }

    [Header("Interactions"), SerializeField]
    private GrabInteraction grabInteraction;

    [SerializeField] private DropInteraction dropInteraction;
    [SerializeField] private DisplayDescriptionInteraction displayDescriptionInteraction;
    [SerializeField] private HideDescriptionInteraction hideDescriptionInteraction;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask("Things", "Treasures");
        grabInteraction.Holder = holder;
        dropInteraction.Holder = holder;
    }

    public void StartInteraction()
    {
        var size = Physics.OverlapSphereNonAlloc(transform.position + originOffset,
            interactionRadius,
            _colliders,
            _layerMask);

        if (size == 0) return;

        var interactableArray = _colliders[0].GetComponentsInChildren<IInteractable>();
        if (interactableArray.Length == 0) return;

        State = InteractionState.Started;

        UseInteraction(grabInteraction, interactableArray);
        UseInteraction(displayDescriptionInteraction, interactableArray);
    }

    public void StopInteraction()
    {
        if (State != InteractionState.Started) return;
        if (_colliders[0] == null) return;

        var interactableArray = _colliders[0].GetComponentsInChildren<IInteractable>();
        if (interactableArray.Length == 0) return;

        State = InteractionState.Started;
        UseInteraction(dropInteraction, interactableArray);
        UseInteraction(hideDescriptionInteraction, interactableArray);
    }

    private static void UseInteraction(IInteraction interaction, IEnumerable<IInteractable> interactables)
    {
        foreach (var interactable in interactables)
        {
            interactable.Accept(interaction);
        }
    }


#if UNITY_EDITOR
    private void OnValidate()
    {
        if (interactionRadius < 0.01f)
            interactionRadius = 0.01f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Origin, interactionRadius);
        Gizmos.DrawLine(Origin, Origin + transform.forward * interactionRadius);
    }
#endif
}