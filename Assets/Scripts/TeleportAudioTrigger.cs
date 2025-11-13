using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Reproduce un audio la primera vez que el jugador se teletransporta
/// (o se mueve) cerca de este Teleportation Anchor.
/// </summary>
public class TeleportAnchorAudioTrigger : MonoBehaviour
{
    [Header("Asignar desde el Inspector")]
    public Transform xrOrigin; // XR Origin (arrastra tu XR Origin aquí)
    public AudioSource audioSource;
    public float detectionRadius = 1.5f; // distancia para activar el audio

    private bool hasPlayed = false;

    private void Update()
    {
        if (xrOrigin == null || audioSource == null)
            return;

        float distance = Vector3.Distance(xrOrigin.position, transform.position);

        if (!hasPlayed && distance <= detectionRadius)
        {
            hasPlayed = true;
            audioSource.Play();
            Debug.Log($"[TeleportAnchorAudioTrigger] Audio '{audioSource.clip?.name}' reproducido en {gameObject.name}");
        }
    }
}
