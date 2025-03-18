using UnityEngine;

public class CustomSceneManager : MonoBehaviour
{
    [SerializeField] private Vector4 curvatureValue = new Vector4(0.1f, 0.1f, 0.1f, 0.1f);

    private void Awake()
    {
        Shader.SetGlobalVector("_Curvature", curvatureValue);
    }

    private void Start()
    {
        Debug.Log("Curvature value set to: " + curvatureValue);
    }
}