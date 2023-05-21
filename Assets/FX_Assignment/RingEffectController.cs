using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingEffectController : MonoBehaviour
{
    public Renderer ringEffectRenderer;
    public float emission;
    public float emissionSpeed;
    [Space]
    public float emissionMin;
    public float emissionMax;
    [Space]
    [Header("Controls")]
    [Space]
    public bool rampEmission;
    public float rampSpeed;
    [Space]
    public bool enforceSpeedLimits;
    public float minSpeed;
    public float maxSpeed;

    private bool add;
    private MaterialPropertyBlock _propertyBlock;
    private static readonly int EmissionId = Shader.PropertyToID("_Emission");

    private void Start()
    {
        _propertyBlock = new MaterialPropertyBlock();
    }

    public void FixedUpdate()
    {
        if (enforceSpeedLimits)
        {
            if(emissionSpeed > maxSpeed)
            {
                emissionSpeed = maxSpeed;
            }
            else if(emissionSpeed < minSpeed)
            {
                emissionSpeed = minSpeed;
            }
        }

        if (emission > emissionMax)
        {
            add = false;
        }
        else if (emission < emissionMin)
        {
            add = true;
        }

        if (rampEmission)
        {
            if (add)
            {
                emission += emissionSpeed;
                _propertyBlock.SetFloat(EmissionId, emission);
            }
            else if (!add)
            {
                emission -= emissionSpeed;
                _propertyBlock.SetFloat(EmissionId, emission);
            }
            emissionSpeed += rampSpeed;
        }
        ringEffectRenderer.SetPropertyBlock(_propertyBlock);
    }
}
