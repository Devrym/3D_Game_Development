using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIK : MonoBehaviour
{
    [SerializeField] private Transform _handPoint;
    [SerializeField] private Transform _headPoint;

    [SerializeField, Range(0f, 1f)] private float _handWeight;
    [SerializeField] private Vector3 _handOffset;

    [SerializeField, Range(0f, 1f)] private float _lookWeight;
    [Range(0f, 1f)] public float eyesWeight;
    [Range(0f, 1f)] public float headWeight;
    [Range(0f, 1f)] public float bodyWeight;
    [Range(0f, 1f)] public float clampWeight;

    private float distance;

    private Collider[] colliders;

    public LayerMask mask;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();    
    }

    private void OnAnimatorIK(int layerIndex)
    {
        distance = Vector3.Distance(_animator.GetBoneTransform(HumanBodyBones.Head).position, _headPoint.position);

        if (_handPoint)
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _handWeight);
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _handWeight);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, _handWeight);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, _handWeight);

            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _handPoint.position + _handOffset);
            _animator.SetIKPosition(AvatarIKGoal.RightHand, _handPoint.position + _handOffset);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _handPoint.rotation);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _handPoint.rotation);

        }
        
        if (distance < 10f) //Примерно 2 метра
        {

                    
                    _lookWeight = 2 / distance;
                    bodyWeight = 2 / distance;
                    headWeight = 2 / distance;
                    eyesWeight = 2 / distance;
                    clampWeight = 2 / distance;
                    _handWeight = 2 / distance;

                    _animator.SetLookAtWeight(_lookWeight, bodyWeight, headWeight, eyesWeight, clampWeight);
                    _animator.SetLookAtPosition(_headPoint.position);

        } else
        {
            _lookWeight = 0;
            bodyWeight = 0;
            headWeight = 0;
            eyesWeight = 0;
            clampWeight = 0;
            _handWeight = 0;
        }
    }
        


    
}
