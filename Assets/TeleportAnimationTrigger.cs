using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(TeleportationAnchor))]
public class TeleportAnimationTrigger : MonoBehaviour
{
    public CharacterAnimationController character;

    private TeleportationAnchor anchor;

    private void Awake()
    {
        anchor = GetComponent<TeleportationAnchor>();
    }

    private void OnEnable()
    {
        anchor.teleporting.AddListener(OnTeleported);
    }

    private void OnDisable()
    {
        anchor.teleporting.RemoveListener(OnTeleported);
    }

    private void OnTeleported(TeleportingEventArgs args)
    {
        if (character != null)
        {
            character.TriggerEvent(); 
        }
    }
}
