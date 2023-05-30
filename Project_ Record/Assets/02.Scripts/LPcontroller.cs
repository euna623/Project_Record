using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPcontroller : MonoBehaviour
{
    public Material targetMaterial; // �浹 ��� ���׸���

    private void OnTriggerEnter(Collider collider)
    {
        Renderer renderer = collider.gameObject.GetComponent<Renderer>();
        if (renderer != null && renderer.sharedMaterial != targetMaterial)
        {
            Debug.Log("��,,, �� ��,,,");
            Destroy(collider.gameObject);
        }
        else if (renderer != null && renderer.sharedMaterial == targetMaterial)
        {
            Destroy(collider.gameObject);
        }
    }
}
