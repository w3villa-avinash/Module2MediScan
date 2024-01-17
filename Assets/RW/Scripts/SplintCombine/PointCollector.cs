
using System.Collections;
using System.Linq;
using UnityEngine;

public class PointCollector : MonoBehaviour
{
    private Vector3[] _selectedVertices;
    [SerializeField] private GameObject _pfSphere;
    private Camera _mCamera;
    public enum State
    {
        WristCenter,
        WristLeft,
        WristRight,
        ElbowCenter,
        ElbowLeft,
        ElbowRight,
        AligmentTop,
        AligmentBttoms



    }
    private State _landmarks;
    void Awake()
    {
        _mCamera = Camera.main;
        _selectedVertices = new Vector3[7];
        _landmarks = State.WristCenter;
    }
    void Update()
    {
        SettingUpPoint();



    }
    private void SettingUpPoint()
    {
        
        Ray ray = _mCamera.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Player"))
            {

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log(hit.point);
                    switch (_landmarks)
                    {
                        case State.WristCenter:
                            _selectedVertices.Append(hit.point);
                             Instantiate(_pfSphere, hit.point, Quaternion.identity, transform);
                            _landmarks = State.WristLeft;
                            break;
                        case State.WristLeft:
                             _selectedVertices.Append(hit.point);
                             Instantiate(_pfSphere, hit.point, Quaternion.identity, transform);
                            _landmarks = State.WristRight;
                            break;
                        case State.WristRight:
                            _selectedVertices.Append(hit.point);
                             Instantiate(_pfSphere, hit.point, Quaternion.identity, transform);
                            _landmarks = State.ElbowCenter;
                            break;
                        case State.ElbowCenter:
                            _selectedVertices.Append(hit.point);
                             Instantiate(_pfSphere, hit.point, Quaternion.identity, transform);
                            _landmarks = State.ElbowLeft;
                            break;
                        case State.ElbowLeft:
                             _selectedVertices.Append(hit.point);
                             Instantiate(_pfSphere, hit.point, Quaternion.identity, transform);
                            _landmarks = State.ElbowRight;
                            break;
                        case State.ElbowRight:
                            _selectedVertices.Append(hit.point);
                             Instantiate(_pfSphere, hit.point, Quaternion.identity, transform);
                            _landmarks = State.AligmentTop;
                            break;


                    }
                }
                
                   
            }
        }

    }


}
