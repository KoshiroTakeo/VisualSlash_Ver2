using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBulletGenerate : MonoBehaviour
{
    //�e�v���n�u
    public GameObject HbulletObject;
    //�e���ˎ��̃G�t�F�N�g
    public GameObject HbulletEffect;
    //�v���C���[�̃v���n�u
    public GameObject Player;
    //�G�̃v���n�u
    public GameObject HEnemy;
    //�G�̍���
    public GameObject LeftShoulder_Pos;
    //�G�̉E��
    public GameObject RightShoulder_Pos;
    //���ԊԊu�̍ŏ��l
    public float minTime = 3.0f;
    //���ԊԊu�̍ő�l
    public float maxTime = 5.0f;
    //�e�������ԊԊu
    private float Hitinterval;
    //�o�ߎ���
    private float Hittime = 0.0f;
    //�v���C���[�ƓG�̋���
    private float distance;
    //�e���~�߂鎞�̋���
    public float BulletStop = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        //���ԊԊu�����肷��
        Hitinterval = GetRandomTime();

        //�I�u�W�F�N�g��������
        Player = GameObject.Find("Player_XRRig");
        HEnemy = GameObject.Find("Stage1_Boss");
        LeftShoulder_Pos = GameObject.Find("LeftLauncher");
        RightShoulder_Pos = GameObject.Find("RightLauncher");
    }

    // Update is called once per frame
    void Update()
    {

        //���Ԍv��
        Hittime += Time.deltaTime;

        //�v���C���[�̕���������
        //transform.LookAt(Player.transform);

        //�v���C���[�ƓG�̈ʒu

        distance = HEnemy.transform.position.z - Player.transform.position.z;

        //�o�ߎ��Ԃ��������ԂɂȂ����Ƃ�(�������Ԃ��傫���Ȃ����Ƃ�)
        if (Hittime > Hitinterval)
        {
            if (distance > BulletStop)
            {
                //�e���C���X�^���X������(��������)
                GameObject Hitbullet = Instantiate(HbulletObject);
                //���������e�̈ʒu��ݒ肷��
                int i;
                i = GetRandom(); 
                if (i == 0)
                {
                    Hitbullet.transform.position = LeftShoulder_Pos.transform.position;
                }
                if (i == 1)
                {
                    Hitbullet.transform.position = RightShoulder_Pos.transform.position;
                }

                //�G�t�F�N�g�𐶐�����
                GameObject effect = Instantiate(HbulletEffect) as GameObject;
                //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
                effect.transform.position = Hitbullet.transform.position;
                //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
                Hittime = 0.0f;
                //���ɔ������鎞�ԊԊu�����肷��
                Hitinterval = GetRandomTime();
            }

        }
    }

    // �w�肵���͈͂Ń����_���Ȏ��Ԃ𐶐�����֐�
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    private int GetRandom()
    {
        return Random.Range(0, 2);
    }
}
