using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    //�e�̃X�s�[�h
    private float BulletSpeed = 2.1f; // 10/20�|���ύX���i���F0.1f�j
    //�Q�[���X�s�[�h
    public float GameSpeed = 1.0f;
    //�v���C���[�X�s�[�h
    public float PlayerSpeed = 1.0f;
    //�e�̃X�s�[�h��ύX����ʒu
    public float BulletLatePos = 100.0f;
    //�e�̃X�s�[�h�ύX�p
    public float BulletLateSpeed;


    //�e���v���C���[�Ɠ����������̃G�t�F�N�g
    public GameObject HitEffect;
    //�e���������W
    public float BulletDeletePos = -50.0f;
    //�Q�[���}�l�[�W���[�Q�Ɨp
    private GameManager GameMng;


    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���}�l�[�W���[���Q��
        GameMng = GameObject.Find("GameManager").GetComponent<GameManager>();
        BulletLateSpeed = 1.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3�Ƃ����^�ɒl�����A�v�Z
        Vector3 BulletPos = transform.position;
        //�e�̑��x�����Z�i�e���x�~�Q�[���X�s�[�h�~�v���C���[�X�s�[�h�j
        BulletPos.z += -BulletSpeed * GameMng.WorldTime * GameMng.AccelSpeed * BulletLateSpeed * GameSpeed * PlayerSpeed;
        //�|�W�V�����ɑ��
        transform.position = BulletPos;
        if (gameObject.transform.position.z < BulletLatePos)
        {
            BulletLateSpeed = 0.1f;
        }
        //�e��Z���̈ʒu��BulletDeletePos�ȉ��̎�
        if (gameObject.transform.position.z < BulletDeletePos)
        {
            //�e���폜
            Destroy(gameObject);
        }
    }

    // �����蔻��
    private void OnCollisionEnter(Collision collision)
    {
        //�Փ˂����I�u�W�F�N�g��Player�������Ƃ�
        if (collision.gameObject.CompareTag("Player"))
        {
            //�e���폜
            Destroy(gameObject);

            //�G�t�F�N�g�𔭐�������
            //GenerateHitEffect();
        }

        //�Փ˂����I�u�W�F�N�g��Player�������Ƃ�
        if (collision.gameObject.CompareTag("Weapon"))
        {
            //�e���폜
            Destroy(gameObject);

            //�G�t�F�N�g�𔭐�������
            //GenerateHitEffect();
        }

    }
    void GenerateHitEffect()
    {
        //�G�t�F�N�g�𐶐�����
        GameObject effect = Instantiate(HitEffect) as GameObject;
        //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
        effect.transform.position = gameObject.transform.position;
    }
}
