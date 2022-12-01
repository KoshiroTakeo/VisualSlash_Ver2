using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour
{
    //�e�v���n�u
    public GameObject BulletObject;
    //�e���ˎ��̃G�t�F�N�g
    public GameObject BulletEffect;
    //�v���C���[�̃v���n�u
    public GameObject Player;
    //�G�̃v���n�u
    public GameObject Enemy;
    //���ԊԊu�̍ŏ��l
    public float minTime = 3.0f;
    //���ԊԊu�̍ő�l
    public float maxTime = 5.0f;
    //�eX���W�̍ŏ��l
    public float MinBulletPositionX = -20f;
    //�eX���W�̍ő�l
    public float MaxBulletPositionX = 20f;
    //�e�̃X�s�[�h
    //private float BulletSpeed = 100f;
    //�e�������ԊԊu
    private float interval;
    //�o�ߎ���
    private float time = 0.0f;
    //�v���C���[�ƓG�̋���
    private float distance;
    //�e���~�߂鎞�̋���
    public float BulletStop = 400.0f;


    // Start is called before the first frame update
    void Start()
    {
        //���ԊԊu�����肷��
        interval = GetRandomTime();

        //�I�u�W�F�N�g��������
        Player = GameObject.Find("Player_XRRig");
        Enemy = GameObject.Find("Stage1_Boss");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //���Ԍv��
        time += Time.deltaTime;

        //�v���C���[�ƓG�̈ʒu
        distance = Enemy.transform.position.z; //- Player.transform.position.z;

        //�o�ߎ��Ԃ��������ԂɂȂ����Ƃ�(�������Ԃ��傫���Ȃ����Ƃ�)
        if (time > interval)
        {
            //��苗���̎��e�𐶐����Ȃ�
            if (distance > BulletStop)
            {
                //�e���C���X�^���X������(��������)
                GameObject bullet = Instantiate(BulletObject);
                //���������e�̈ʒu�������_��(X=-20�`20,Y=0,Z=50)�ɐݒ肷��
                bullet.transform.position = GetRandomPosition();

                //�G�t�F�N�g�𐶐�����
                GameObject effect = Instantiate(BulletEffect) as GameObject;
                //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
                effect.transform.position = bullet.transform.position;

                //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
                time = 0.0f;
                //���ɔ������鎞�ԊԊu�����肷��
                interval = GetRandomTime();
            }
        }
    }

    // �w�肵���͈͂Ń����_���Ȏ��Ԃ𐶐�����֐�
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    //�w�肵���͈͂Ń����_���Ȉʒu�𐶐�����֐�
    private Vector3 GetRandomPosition()
    {
        //X���W�������_���ɐ�������
        float x = Random.Range(MinBulletPositionX, MaxBulletPositionX);
        float y = 1.0f; // 10/20�|���ύX���i���F0.0f�j
        //float z = 400.0f; // 10/20�|���ύX���i���F50.0f�j
        float z = Enemy.transform.position.z - 20.0f; 

        //Vector3�^��Position��Ԃ�
        return new Vector3(x, y, z);
    }
}
