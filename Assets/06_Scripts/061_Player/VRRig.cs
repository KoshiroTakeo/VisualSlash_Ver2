//============================================================
// VRRig.cs
//======================================================================
// �J������
//
// 2022/05/28 author �|���F����AHMD�ɍ��킹�����f���̓���
// �Q�l�Fhttps://www.youtube.com/watch?v=tBYl-aSxUe0
// 
//
//======================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // �T�u�v���p�e�B�\���iSerializeble�͂��������\����������́j
public class VRMap
{
    public Transform vrTarget;              // VR��Ŏ��ۂɓ��������A�r���̃I�u�W�F�N�g
    public Transform rigTarget;             // TwoBoneIKConstrains����Rig��ʂ����^�[�Q�b�g
    public Vector3 trackingPosittionOffset; 
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPosittionOffset);             // ���[�J����Ԃ��烏�[���h��Ԃ� position ��ϊ�
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset); // �I�C���[�p�i3�̊p�x�g�ɂ��j�ɂ���]����
    }
}

public class VRRig : MonoBehaviour
{
    public VRMap head;
    public VRMap lefthand;
    public VRMap righthand;

    [SerializeField] public Transform headconstrain;
    [SerializeField] public Vector3 headBodyOffset;
   
    void Start()
    {
        headBodyOffset = transform.position - headconstrain.position; // �����␳
    }

    void LateUpdate() // Update�ɂ��Ă����Ȃ��iVRMap�̏������ɂ���Ă͕s�\�j
    {
        transform.position = headconstrain.position + headBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(headconstrain.up, Vector3.up).normalized; // �ΖʂɑΉ�������

        head.Map();
        lefthand.Map();
        righthand.Map();
    }
}
