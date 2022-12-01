using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class EnemyCommon
{
    [SerializeField] GameManager gameMng = null;
    [SerializeField] Rigidbody rig;
    [SerializeField] int life;
    [SerializeField] GameObject weakpoint;
    [SerializeField] GameObject player;
    [SerializeField] private float leave;   // ����鋗��
    [SerializeField] private float idx;     // �w��
    [SerializeField] private float mult;    // �搔
    [SerializeField] private Animator anim;

    /// <summary>
    /// ����������
    /// </summary>
    private void OnStart()
    {
        Life = life;                    // HP�̏�����
        HitWP = false;                  // ��_�\���I�t
        weakpoint.SetActive(false);     
        Invoke(nameof(SetWP), 3.0f);    // Debug3�b��Ɏ�_�\��

        // �{�X�̃X�e�[�g(������)
        currentState = s_stay;       // �ҋ@��Ԃ���
        currentState.OnEnter(this, null);
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    private void OnUpdate()
    {
        currentState.OnUpdate(this);
    }

    /// <summary>
    /// �X�V����(Fixed)
    /// </summary>
    private void OnFixedUpdate()
    {
        currentState.OnFixedUpdate(this);
    }

    /// <summary>
    /// ���S����
    /// </summary>
    private void OnDeath()
    {
        Debug.Log("DEAD");
        gameObject.SetActive(false);
    }

    /// <summary>
    /// ��_��\���w���鏈��
    /// </summary>
    private void SetWP()
    {
        weakpoint.SetActive(true);
        
        Debug.Log("on");
    }

    private float DistanceCalc()
    {
        float result = 0.0f;

        result = transform.position.z - player.transform.position.z;

        return result;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (HitWP) { return; }

        if (other.gameObject.tag == "Player")
            AddDmg(1);
    }
}