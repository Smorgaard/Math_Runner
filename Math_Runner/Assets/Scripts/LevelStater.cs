using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStater : MonoBehaviour
{
    public GameObject countdown3;
    public GameObject countdown2;
    public GameObject countdown1;
    public GameObject countdownGO;

    public AudioSource countdownBeepSFX;
    public AudioSource countdownGoSFX;

    public GameObject fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownSequence());
    }
    IEnumerator CountdownSequence()
    {
        yield return new WaitForSeconds(1f);
        countdown3.SetActive(true);
        countdownBeepSFX.Play();

        yield return new WaitForSeconds(1f);
        countdown2.SetActive(true);
        countdownBeepSFX.Play();

        yield return new WaitForSeconds(1f);
        countdown1.SetActive(true);
        countdownBeepSFX.Play();

        yield return new WaitForSeconds(1f);
        countdownGO.SetActive(true);
        countdownGoSFX.Play();

    }
}
