using UnityEngine;
using System.Collections;

public class CharacterAnimationController : MonoBehaviour
{
    [Header("Componentes")]
    public Animator animator;
    public AudioSource audioSource;

    [Header("States del Animator")]
    public string idleState = "IdleLoop";
    public string specialState = "Special";

    [Header("Bloqueo de escena")]
    public GameObject sceneBlocker;

    [Header("Control de reproducción única")]
    public bool hasPlayed = false;   // <-- NUEVO

    private void Start()
    {
        PlayIdle();
    }

    public void TriggerEvent()
    {
        if (hasPlayed) return;  // <-- SOLO UNA VEZ POR ESCENA

        hasPlayed = true;
        PlaySpecial();
    }

    public void PlayIdle()
    {
        animator.Play(idleState);
    }

    public void PlaySpecial()
    {
        animator.Play(specialState);

        if (audioSource != null)
            audioSource.Play();

        StartCoroutine(ReturnToIdleAfterAudio());
    }

    private IEnumerator ReturnToIdleAfterAudio()
    {
        // Esperar a que el audio termine
        if (audioSource != null && audioSource.clip != null)
        {
            yield return new WaitForSeconds(audioSource.clip.length);
        }

        // Bloqueo se baja
        if (sceneBlocker != null)
            sceneBlocker.SetActive(false);

        // Volver a idle
        PlayIdle();
    }
}
