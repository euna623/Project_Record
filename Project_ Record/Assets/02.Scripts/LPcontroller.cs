using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPcontroller : MonoBehaviour
{
    public Material targetMaterial; // 충돌 대상 메테리얼

    private void OnTriggerEnter(Collider collider)
    {
        Renderer renderer = collider.gameObject.GetComponent<Renderer>();
        if (renderer != null && renderer.sharedMaterial != targetMaterial)
        {
            Debug.Log("또,,, 또 왜,,,");
            Destroy(collider.gameObject);
        }
        else if (renderer != null && renderer.sharedMaterial == targetMaterial)
        {
            Destroy(collider.gameObject);
        }
    }
}
