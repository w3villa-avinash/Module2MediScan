using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeshSticker : MonoBehaviour
{
    [SerializeField] public Transform mesh1;
    [SerializeField] public Transform mesh2;
    [SerializeField] private Button  _meshCombine , _scannedObject , _spintObject;

    public int stickingPointIndex = 0; // Index of the sticking points on both meshes

    private List<Vector3> stickingPointMesh1;
    private List<Vector3> stickingPointMesh2;


    private Vector3 offset; // Offset between sticking points
    private bool check;

void Awake()
{
    _meshCombine.onClick.AddListener(() => CombineMesh());
    _scannedObject.onClick.AddListener( () => WorkingOnScannedObject());
    _spintObject.onClick.AddListener( () => WorkingOnSplintObject() );
}
    void Start()
    {
        WorkingOnScannedObject();

        
        if (mesh1 != null && mesh2 != null)
        {
            // stickingPointMesh1 = mesh1.GetComponent<Test>().PointSelected();
            // stickingPointMesh2 = mesh2.GetComponent<Test2>().PointSelected();
            stickingPointMesh2.ToArray();
            stickingPointMesh1.ToArray();

        }
        else
        {
            Debug.LogError("Mesh references not set!");
        }
    }
    private void CombineMesh()
    {
        if (!(stickingPointMesh1.Capacity == stickingPointMesh2.Count)) return;
        check = true;
        mesh1.gameObject.SetActive(true);
        mesh2.gameObject.SetActive(true);

    }

    private void WorkingOnScannedObject()
    {
        mesh1.gameObject.SetActive(true);
        mesh2.gameObject.SetActive(false);
    }
    private void WorkingOnSplintObject()
    {
        mesh1.gameObject.SetActive(false);
        mesh2.gameObject.SetActive(true);
    }
    void Update()
    {
        for(int i =0 ; i < stickingPointMesh1.Count; i++)
        {

        }

    }
}
