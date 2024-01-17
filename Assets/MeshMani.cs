using UnityEngine;

public class MeshMani : MonoBehaviour
{
    public bool moveVertexPoint = true;
    public float handleSize = 0.01f;
    [SerializeField] GameObject pfSpere;
    private Mesh mesh;
    private Vector3[] vertices;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        EditMesh();
    }



    void EditMesh()
    {
        Transform handleTransform = transform;
        Quaternion handleRotation = Quaternion.identity; 

        for (int i = 0; i < vertices.Length; i ++)
        {
            ShowPoint(i, handleTransform);
        }
    }

    private void ShowPoint(int index, Transform handleTransform)
    {
        if (moveVertexPoint)
        {
            Vector3 point = handleTransform.TransformPoint(vertices[index]);
            DrawSphere(point, handleSize);
            
        }
       
    }

    private void DrawSphere(Vector3 center, float radius)
    {
        GameObject sphere = Instantiate(pfSpere,transform);
        sphere.transform.position = center;
        sphere.transform.localScale = Vector3.one*radius;
    }

}
