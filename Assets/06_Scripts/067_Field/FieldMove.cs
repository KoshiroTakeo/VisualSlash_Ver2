using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMove : MonoBehaviour
{
    //�t�B�[���h�ړ����x
    public float Field_Speed = 0;

    //�t�B�[���h�Đݒu�ʒu�I�u�W�F�N�g
    private GameObject Pop_Point;

    //GemeManager�̕ϐ������Ă���p
    private GameManager GameMng;

    private void Start()
    {
        Pop_Point = GameObject.Find("FieldPopPoint");

        GameMng = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void FixedUpdate()
    {
        //�t�B�[���h�̈ړ����s
        Vector3 Field_Pos = transform.position;

        Field_Pos.z -= Time.deltaTime * Field_Speed * GameMng.WorldTime * GameMng.AccelSpeed;

        transform.position = Field_Pos;

        if (transform.position.z <= -900.0f)
        {
            transform.position = Pop_Point.transform.position;
        }
    }

    //�v���C���[�_���[�W������
    public void PlayerDamage()
    {
        Field_Speed = Field_Speed - 1.0f;
    }
}