using UnityEngine;
using System.Collections.Generic;

public class MeshDeformation : MonoBehaviour
{
    public MeshFilter meshToDeformFilter;   // The mesh you want to deform
    public MeshFilter targetMeshFilter;     // The mesh you want to deform towards

    public float deformationStrength = 0.1f;

    private Vector3[] originalVertices;

    void Start()
    {
        if (meshToDeformFilter != null && targetMeshFilter != null)
        {
            // Cache the original vertices of the mesh to deform
            originalVertices = meshToDeformFilter.mesh.vertices;

            // Deform the mesh
            DeformMesh();
        }
        else
        {
            Debug.LogError("Mesh filters not assigned!");
        }
    }

    void DeformMesh()
    {
        Mesh meshToDeform = meshToDeformFilter.mesh;
        Vector3[] verticesToDeform = meshToDeform.vertices;
        Vector3[] targetVertices = targetMeshFilter.mesh.vertices;

        // Deform each vertex towards the target mesh
        for (int i = 0; i < verticesToDeform.Length; i++)
        {
            verticesToDeform[i] = Vector3.Lerp(verticesToDeform[i], targetVertices[i], deformationStrength);
        }

        // Assign the deformed vertices back to the mesh
        meshToDeform.vertices = verticesToDeform;

        // Recalculate normals and bounds to ensure proper rendering
        meshToDeform.RecalculateNormals();
        meshToDeform.RecalculateBounds();
    }

    void ResetMesh()
    {
        // Reset the mesh to its original state
        meshToDeformFilter.mesh.vertices = originalVertices;
        meshToDeformFilter.mesh.RecalculateNormals();
        meshToDeformFilter.mesh.RecalculateBounds();
    }

    void Update()
    {
        // For demonstration purposes, you can reset the mesh to its original state on key press (e.g., R key)
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetMesh();
        }
    }
}
