
using UnityEngine;
using UnityEngine.UI;

public class AligmentTest : MonoBehaviour
{
    public MeshFilter meshFilter ,meshFilter2;
    public Vector3[] targetPoint ,sourcePoint; 
    [SerializeField] private Button _combineMesh;

    void Awake()
    {
        _combineMesh.onClick.AddListener(() => Combine());
        

    }
    private void Combine()
    {
        targetPoint = meshFilter2.GetComponent<Test2>().PointSelected();
        sourcePoint = meshFilter.GetComponent<Test>().PointSelected();
         if (meshFilter != null)
        {
            // Get the mesh from the MeshFilter
            Mesh mesh = meshFilter.mesh;

            // Move all vertices to the target point
            MoveVerticesToTarget(mesh, targetPoint[0]);

            // Update the mesh in the MeshFilter
            meshFilter.mesh = mesh;
        }
        else
        {
            Debug.LogError("MeshFilter not assigned!");
        }
    }


    void MoveVerticesToTarget(Mesh mesh, Vector3 target)
    {
        // Get the mesh vertices
        

        // Calculate the displacement vector
        Vector3 displacement = target - sourcePoint[0];

        // Move all vertices to the target point
     sourcePoint[0] += displacement;
        // Assign the modified vertices back to the mesh
       

        // Recalculate bounds and normals after moving vertices
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
