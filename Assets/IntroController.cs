using System.Collections;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public GameObject introPanel;       // El panel con el texto
    public AudioSource introAudio;      // El audio de bienvenida
    public GameObject bloqueoInicial;   // El muro invisible inicial

    void Start()
    {
        bloqueoInicial.SetActive(true);     // Bloqueo activo
        introPanel.SetActive(true);         // Mostrar UI
        introAudio.Play();                  // Empezar audio
        StartCoroutine(WaitForAudio());
    }

    private IEnumerator WaitForAudio()
    {
        yield return new WaitForSeconds(introAudio.clip.length);

        introPanel.SetActive(false);        // Ocultar UI
        bloqueoInicial.SetActive(false);    // Abrir camino
    }
    public void CloseIntroEarly()
    {
        introAudio.Stop();
        introPanel.SetActive(false);
        bloqueoInicial.SetActive(false);
    }

}
