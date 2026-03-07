using UnityEngine;
using Kino;
using URPGlitch;
using UnityEngine.Rendering;

public class GlitchObj : MonoBehaviour
{
    public DigitalGlitch digitalGlitch;
    [SerializeField] private GameObject  glitchGlobalVolume;
    [SerializeField] private Volume volume;

    //private bool isEnabled = true;

    private AnalogGlitchVolume analogGlitchVolume;
    private DigitalGlitchVolume digitalGlitchVolume;

    private void Start()
    {
        volume.profile.TryGet<AnalogGlitchVolume>(out analogGlitchVolume);
        volume.profile.TryGet<DigitalGlitchVolume>(out digitalGlitchVolume);
    }

/*
    public void ToggleEffects()
    {
        isEnabled = !isEnabled;
        analogGlitchVolume.active = isEnabled ? true : false;
        digitalGlitchVolume.active = isEnabled ? true : false;
    }
    public void RandomSettings()
    {
        analogGlitchVolume.scanLineJitter.value = Random.Range(0f, 1f);
        analogGlitchVolume.verticalJump.value = Random.Range(0f, 1f);
        analogGlitchVolume.horizontalShake.value = Random.Range(0f, 1f);
        analogGlitchVolume.colorDrift.value = Random.Range(0f, 1f);

        digitalGlitchVolume.intensity.value = Random.Range(0f, 1f);
    }*/

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 distanceVector = other.transform.position - transform.position;
            analogGlitchVolume.horizontalShake.value = 2/distanceVector.magnitude;
            analogGlitchVolume.colorDrift.value = 1/distanceVector.magnitude;
            analogGlitchVolume.verticalJump.value = 1/distanceVector.magnitude;
            digitalGlitchVolume.intensity.value = 1/distanceVector.magnitude;
            //Debug.Log(distanceVector.magnitude);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 distanceVector = other.transform.position - transform.position;
            analogGlitchVolume.horizontalShake.value = 0f;
            analogGlitchVolume.colorDrift.value = 0f;
            analogGlitchVolume.verticalJump.value = 0f;
        }
    }
}
