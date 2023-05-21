using UnityEngine;

public class EffectRadiusController : MonoBehaviour
{
    public EmpathicAuraController empathicAuraController;
    public float effectRadius = 1f;
    public float scalingFactor;

    private void Start()
    {
        scalingFactor = 1.4f * 2;
    }
    private void Update()
    {
        UpdateEffectRadius();
    }

    private void UpdateEffectRadius()
    {
        // Set the position of the effect radius object to the center of the ability
        transform.position = empathicAuraController.transform.position;

        // Scale the effect radius object
        transform.localScale = new Vector3(scalingFactor, scalingFactor, scalingFactor);
        if(Input.GetKeyDown(KeyCode.D))
            transform.localEulerAngles = new Vector3(-90, 0, 0);
        if (Input.GetKeyDown(KeyCode.A))
            transform.localEulerAngles = new Vector3(90, 0, 0);
    }
}
