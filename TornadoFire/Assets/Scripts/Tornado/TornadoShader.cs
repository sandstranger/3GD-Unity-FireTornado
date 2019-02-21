using System;
using UnityEngine;

public class TornadoShader : MonoBehaviour
{
    [SerializeField] private bool takeSunDirection = false;

    private static readonly int shaderFrenelGlowID = Shader.PropertyToID("_FrenelGlow");
    private static readonly int shaderFrenelColorID = Shader.PropertyToID("_FrenelColor");
    private static readonly int shaderPositionID = Shader.PropertyToID("_Position");
    private static readonly int shaderSunDirectionID = Shader.PropertyToID("_SunDirection");

    [SerializeField, ColorUsage(false,true)]
    private Color selectedColor = Color.green;
    [SerializeField, ColorUsage(false, true)]
    private Color unselectedColor = Color.white;

    [Header("References")]
    [SerializeField] private Transform sun = null;
    [SerializeField] private Renderer[] tornadoRenderers = null;

    private void Awake()
    {
        this.UpdateSelected(false);
    }

    private void Update()
    {
        foreach(Renderer renderer in tornadoRenderers)
        {
            renderer.sharedMaterial.SetVector(shaderPositionID, this.transform.position);
            if(takeSunDirection && renderer.name == "Tornado - Low")
            {
                renderer.sharedMaterial.SetVector(shaderSunDirectionID, -this.sun.forward);
            }
        }
    }

    public void UpdateSelected(bool selected)
    {
        if(selected)
        {
            foreach (Renderer renderer in tornadoRenderers)
            {
                renderer.material.SetColor(shaderFrenelColorID, this.selectedColor);
                renderer.material.SetFloat(shaderFrenelGlowID, 1.0f);
            }
        }
        else
        {
            foreach (Renderer renderer in tornadoRenderers)
            {
                renderer.material.SetColor(shaderFrenelColorID, this.unselectedColor);
                renderer.material.SetFloat(shaderFrenelGlowID, 0.0f);
            }
        }
    }
}
