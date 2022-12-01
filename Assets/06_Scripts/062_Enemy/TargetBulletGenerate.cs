using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBulletGenerate : MonoBehaviour
{
    //�e�v���n�u
    public GameObject TbulletObject;
    //�e���ˎ��̃G�t�F�N�g
    public GameObject TbulletEffect;
    //�v���C���[�̃v���n�u
    public GameObject Player;
    //�G�̃v���n�u
    public GameObject TEnemy;
    //�G�̍���
    public GameObject LeftHand_Pos;
    //�G�̉E��
    public GameObject RightHand_Pos;
    //�G�̍���
    public GameObject LeftLeg_Pos;
    //�G�̉E��
    public GameObject RightLeg_Pos;
    //�G�̒���
    public GameObject Center_Pos;
    //���ԊԊu�̍ŏ��l
    public float minTime = 3.0f;
    //���ԊԊu�̍ő�l
    public float maxTime = 5.0f;
    //�e�������ԊԊu
    private float Hinterval;
    //�o�ߎ���
    private float Htime = 0.0f;
    //�v���C���[�ƓG�̋���
    private float distance;
    //�e���~�߂鎞�̋���
    public float BulletStop = 20.0f;



    // Start is called before the first frame update
    void Start()
    {
        //���ԊԊu�����肷��
        Hinterval = GetRandomTime();

        //�I�u�W�F�N�g��������
        Player = GameObject.Find("Player_XRRig");
        TEnemy = GameObject.Find("Stage1_Boss");
        LeftHand_Pos = GameObject.Find("LeftHandLauncher");
        RightHand_Pos = GameObject.Find("RightHandLauncher");
        LeftLeg_Pos = GameObject.Find("LeftLegLauncher");
        RightLeg_Pos = GameObject.Find("RightLegLauncher");
        Center_Pos = GameObject.Find("CenterLauncher");
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԍv��
        Htime += Time.deltaTime;

        //�v���C���[�̕���������
        //transform.LookAt(Player.transform);
         
        //�v���C���[�ƓG�̈ʒu
        distance = TEnemy.transform.position.z - Player.transform.position.z;

        //�o�ߎ��Ԃ��������ԂɂȂ����Ƃ�(�������Ԃ��傫���Ȃ����Ƃ�)
        if (Htime > Hinterval)
        {
            if (distance > BulletStop)
            {
                //�e���C���X�^���X������(��������)
                GameObject Hbullet = Instantiate(TbulletObject);
                //���������e�̈ʒu��ݒ肷��
                int i;
                i = GetRandom();
                switch(i)
                {
                    case 0:
                        Hbullet.transform.position = Center_Pos.transform.position;
                        break;
                    case 1:
                        Hbullet.transform.position = LeftHand_Pos.transform.position;
                        break;
                    case 2:
                        Hbullet.transform.position = RightHand_Pos.transform.position;
                        break;
                    case 3:
                        Hbullet.transform.position = LeftLeg_Pos.transform.position;
                        break;
                    case 4:
                        Hbullet.transform.position = RightLeg_Pos.transform.position;
                        break;
                    default:
                        Hbullet.transform.position = Center_Pos.transform.position;
                        break;

                }

                //�G�t�F�N�g�𐶐�����
                GameObject effect = Instantiate(TbulletEffect) as GameObject;
                //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
                effect.transform.position = Hbullet.transform.position;

                //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
                Htime = 0.0f;
                //���ɔ������鎞�ԊԊu�����肷��
                Hinterval = GetRandomTime();
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
        return Random.Range(0, 5);
    }
}
