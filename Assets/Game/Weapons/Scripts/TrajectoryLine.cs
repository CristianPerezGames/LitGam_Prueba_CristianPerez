using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField] private LineRenderer lineRenderer;

    //[SerializeField] Transform hitMarker;
    [Header("VARIABLES")]
    [SerializeField] private int maxPoints = 50;
    [SerializeField] float increment = 0.025f;

    public void HideTrajectory(){
        lineRenderer.positionCount = 0;
    }

    public void DrawTrajectory(Vector3 _initialPosition, Vector3 _direction, float _speed, float _mass) {
        Vector3 velocity =  _direction * (_speed / _mass);
        Vector3 position = _initialPosition;
        Vector3 nextPosition;
        
        UpdateLine(maxPoints, 0, position);

        for (int i = 1; i < maxPoints; i++){
            velocity = CalculateVelocity(velocity, increment);
            nextPosition = position + velocity * increment;

            float distance = Vector3.Distance(position, nextPosition);

            if (Physics.Raycast(position, velocity.normalized, out RaycastHit hit, distance))
            {
                UpdateLine(i, i - 1, hit.point);
                SetHitMarker(hit);
                break;
            }

            //hitMarker.gameObject.SetActive(false);
            position = nextPosition;
            UpdateLine(maxPoints, i, position);
        }
    }

    private void UpdateLine(int _count, int _point, Vector3 _position){
        lineRenderer.positionCount = _count;
        lineRenderer.SetPosition(_point, _position);
    }

    private Vector3 CalculateVelocity(Vector3 _velocity, float _increment){
        _velocity += Physics.gravity * _increment;
        return _velocity;
    }

    private void SetHitMarker(RaycastHit hit){
        //hitMarker.gameObject.SetActive(true);

        //float offset = 0.025f;
        //hitMarker.position = hit.point + hit.normal * offset;
        //hitMarker.rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
    }

}
