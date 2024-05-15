using UnityEngine;

public class EraserController : MonoBehaviour
{
    public Material eraserMaterial;
    public Transform eraserTool;

    void Update()
    {
        Vector2 uvPos = new Vector2(eraserTool.position.x, eraserTool.position.z);
        eraserMaterial.SetVector("_EraserPos", new Vector4(uvPos.x, uvPos.y, 0, 0));
    }
}
