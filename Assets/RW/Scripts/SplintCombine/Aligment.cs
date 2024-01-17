using UnityEngine.UI;

using UnityEngine;

public class Aligment : MonoBehaviour
{

    private Vector3[] sourcePoints;
    private Vector3[] targetPoints;
    [SerializeField] private Button _combineMesh;
    [SerializeField] private MeshFilter meshFilter1;
    [SerializeField] private MeshFilter meshFilter2;

    void Start()
    {
        _combineMesh.onClick.AddListener(() => CombineMesh());
        targetPoints = meshFilter1.GetComponent<Test2>().PointSelected();
        sourcePoints = meshFilter2.GetComponent<Test>().PointSelected();
        
    }
    void CombineMesh()
    {

        if (meshFilter1 != null && sourcePoints.Length == targetPoints.Length)
        {
        
            Mesh mesh = meshFilter1.mesh;

           
            MovePoints(mesh, sourcePoints, targetPoints);

           
            meshFilter1.mesh = mesh;
        }
        else
        {
            Debug.LogError("MeshFilter not assigned or source/target points mismatch!");
        }
    }

    void MovePoints(Mesh mesh, Vector3[] source, Vector3[] target)
    {
        // Get the mesh vertices
        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < source.Length; i++)
        {
            // Find the index of the source point in the vertices array
            int sourceIndex = FindClosestVertexIndex(vertices, source[i]);

            // Move the corresponding vertex to the target position
            vertices[sourceIndex] = target[i];
        }

        // Assign the modified vertices back to the mesh
        mesh.vertices = vertices;
    }

    int FindClosestVertexIndex(Vector3[] vertices, Vector3 target)
    {
        // Find the index of the closest vertex to the target point
        float minDistance = float.MaxValue;
        int closestIndex = -1;

        for (int i = 0; i < vertices.Length; i++)
        {
            float distance = Vector3.Distance(vertices[i], target);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }
}
