using UnityEngine;
using UnityEngine.UI;

public class AlignMeshesToSelectedPoints : MonoBehaviour
{
    public MeshFilter meshFilter1;
    public MeshFilter meshFilter2;
    public Button combineMesh;
    void Awake()
    {
        combineMesh.onClick.AddListener( () => Combine());
    }
    void Combine()
    {
        if (meshFilter1 != null && meshFilter2 != null)
        {
           
            Mesh mesh1 = meshFilter1.mesh;
            Mesh mesh2 = meshFilter2.mesh;

          
            Vector3[] selectedPointsMesh1 = meshFilter1.GetComponent<Test>().PointSelected();
            Vector3[] selectedPointsMesh2 = meshFilter2.GetComponent<Test2>().PointSelected();

            
            AlignMeshes(mesh1, selectedPointsMesh1, mesh2, selectedPointsMesh2);

          
            meshFilter1.mesh = mesh1;
        }
        else
        {
            Debug.LogError("MeshFilter not assigned!");
        }
    }

    void AlignMeshes(Mesh mesh1, Vector3[] selectedPointsMesh1, Mesh mesh2, Vector3[] selectedPointsMesh2)
    {
     
        int[] correspondences = FindCorrespondences(selectedPointsMesh1);

        Matrix4x4 transformationMatrix = ComputeTransformationMatrix(selectedPointsMesh1, selectedPointsMesh2, correspondences);

   
        ApplyTransformation(mesh1, transformationMatrix);
    }

    int[] FindCorrespondences(Vector3[] points1)
    {
  
        int numPoints = points1.Length;
        int[] correspondences = new int[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            correspondences[i] = i;
        }

        return correspondences;
    }

    Matrix4x4 ComputeTransformationMatrix(Vector3[] points1, Vector3[] points2, int[] correspondences)
    {
      
        Vector3 translation = ComputeTranslation(points1, points2, correspondences);
        Matrix4x4 transformationMatrix = Matrix4x4.Translate(translation);

        return transformationMatrix;
    }

    Vector3 ComputeTranslation(Vector3[] points1, Vector3[] points2, int[] correspondences)
    {
       
        Vector3 translation = Vector3.zero;
        int numCorrespondences = correspondences.Length;

        for (int i = 0; i < numCorrespondences; i++)
        {
            int correspondenceIndex = correspondences[i];
            translation += points2[correspondenceIndex] - points1[i];
        }

        translation /= numCorrespondences;

        return translation;
    }

    void ApplyTransformation(Mesh mesh, Matrix4x4 matrix)
    {
       
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = matrix.MultiplyPoint(vertices[i]);
        }
        mesh.vertices = vertices;

      
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
