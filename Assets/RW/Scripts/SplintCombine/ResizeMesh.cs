using UnityEngine;

public class ResizeMesh : MonoBehaviour
{
    public MeshFilter meshToResizeFilter;   // The mesh you want to resize
    public MeshFilter targetMeshFilter;     // The mesh whose size you want to match

    void Start()
    {
        if (meshToResizeFilter != null && targetMeshFilter != null)
        {
            // Resize the mesh
            ResizeToTargetMesh();
            MoveTargetObject();
        }
        else
        {
            Debug.LogError("Mesh filters not assigned!");
        }
    }

    void ResizeToTargetMesh()
    {
        Vector3 targetMeshSize = targetMeshFilter.mesh.bounds.size;

        // Calculate the scale needed to match the size of the target mesh
        Vector3 scale = new Vector3(
            targetMeshSize.x != 0 ? targetMeshSize.x / meshToResizeFilter.mesh.bounds.size.z : 1f,
            targetMeshSize.y != 0 ? targetMeshSize.y / meshToResizeFilter.mesh.bounds.size.y : 1f,
            targetMeshSize.z != 0 ? targetMeshSize.z / meshToResizeFilter.mesh.bounds.size.x : 1f
        );

        // Apply the calculated scale to the mesh
        meshToResizeFilter.transform.localScale = scale;
    }
    void MoveTargetObject()
    {
        targetMeshFilter.GetComponent<Transform>().position = new Vector3(-84.6f, -81.3f,-44.4f);
    }
}
