using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] private Transform _playerPoint;

    private Rigidbody[] _rbs;
    private Collider[] _colliders;

    private Animator _animator;
    bool isAlive;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        _rbs = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
    }

    private void Update()
    {
        if (Vector3.Distance(_animator.GetBoneTransform(HumanBodyBones.Head).position, _playerPoint.position) < 10f && isAlive)
        {
            Kill();
            isAlive = false;
            
        } else if (Vector3.Distance(_animator.GetBoneTransform(HumanBodyBones.Head).position, _playerPoint.position) > 10f)
        {
            Revive();
            isAlive= true;
        }
        
    }

    private void SetRagDoll(bool isActive)
    {
        foreach (var rb in _rbs)
        {
            rb.isKinematic = !isActive;
            if (isActive)
            {
                rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            }
        }

        foreach (var collider in _colliders)
        {
            collider.enabled = isActive;
        }

        _rbs[0].isKinematic= isActive;
        _colliders[0].enabled = !isActive;

    }

    public void Kill()
    {
        SetRagDoll(true);
        _animator.enabled = false;
    }

    public void Revive()
    {
        SetRagDoll(false);
        _animator.enabled = true;
    }
}
