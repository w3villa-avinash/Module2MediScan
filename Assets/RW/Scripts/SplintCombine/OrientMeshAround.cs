using UnityEngine;

public class OrientMeshAround : MonoBehaviour
{
    public Transform sourceMesh;
    public Transform targetMesh;
    public Transform sourcePoint1;
    public Transform sourcePoint2;
    public Transform targetPoint1;
    public Transform targetPoint2;

    void Start()
    {
        if (sourceMesh != null && targetMesh != null &&
            sourcePoint1 != null && sourcePoint2 != null &&
            targetPoint1 != null && targetPoint2 != null)
        {
            OrientMesh();
        }
        else
        {
            Debug.LogError("Required transforms not assigned!");
        }
    }

    void OrientMesh()
    {
        // Calculate the direction vectors between the corresponding points
        Vector3 directionSource = sourcePoint2.position - sourcePoint1.position;
        Vector3 directionTarget = targetPoint2.position - targetPoint1.position;

        // Calculate the rotation to align the source direction with the target direction
        Quaternion rotation = Quaternion.FromToRotation(directionSource, directionTarget);

        // Apply the rotation to the source mesh
        sourceMesh.rotation = rotation * targetMesh.rotation;

        // Optionally, you may want to align the source points with the target points
        sourceMesh.position = targetMesh.position;
        sourceMesh.position += targetPoint1.position - sourcePoint1.position;
    }
}
