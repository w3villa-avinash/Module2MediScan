using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class Test : MonoBehaviour
{

    [SerializeField] private GameObject _pfSphere;

   [SerializeField]private Vector3 _selectedVertices;
    [SerializeField] private List<Vector3> vertices;
    private Camera _mCamera;

    void Awake()
    {
        _mCamera = Camera.main;
       
    }
    public Vector3[] PointSelected()
    {
        return vertices.ToArray();
    }

    void Update()
    {
        Ray ray = _mCamera.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Player"))
            {

                if (Input.GetMouseButtonDown(0) )
                {
                    _selectedVertices= hit.point;
                    vertices.Add(_selectedVertices);
                    Instantiate(_pfSphere, hit.point, Quaternion.identity, transform);
                  
                    
            }
        }

    }
}
}
