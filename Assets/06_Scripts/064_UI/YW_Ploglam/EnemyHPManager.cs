using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPManager : MonoBehaviour
{
    public GameObject Boss;

    //�@�ő�HP
    [SerializeField]
    private int maxHP = 10000;
    //�@���X�Ɍ��炵�Ă���hp�v���Ɏg��
    [SerializeField]
    private int hp;
    //�@�ŏI�I��hp�v���Ɏg��
    private int finalHP;
    //�@HP����x���炵�Ă���̌o�ߎ���
    private float countTime = 0f;
    //�@����HP�����炷�܂ł̎���
    [SerializeField]
    private float nextCountTime = 0f;
    //�@HP�\���p�X���C�_�[
    private Slider hpSlider;
    //�@�ꊇHP�\���p�X���C�_�[
    private Slider bulkHPSlider;
    //�@���݂̃_���[�W��
    private int damage = 0;
    //�@���Ɍ��炷�_���[�W��
    [SerializeField]
    private int amountOfDamageAtOneTime = 100;
    //�@HP�����炵�Ă��邩�ǂ���
    private bool isReducing;
    //�@HP�p�\���X���C�_�[�����炷�܂ł̑ҋ@����
    [SerializeField]
    private float delayTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        hpSlider = transform.Find("HUD/Canvas/HPSlider").GetComponent<Slider>();
        bulkHPSlider = transform.Find("HUD/Canvas/BlukSlider").GetComponent<Slider>();
        hp = maxHP = GameObject.FindWithTag("Boss").GetComponent<EnemyCommon>().Life;
        finalHP = maxHP;
        hpSlider.value = 1;
        bulkHPSlider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //�@�_���[�W�Ȃ���Ή������Ȃ�
        if (!isReducing)
        {
            return;
        }

        //�@���Ɍ��炷���Ԃ�������
        if (countTime >= nextCountTime)
        {
            int tempDamage;
            //�@���߂�ꂽ�ʂ����c��_���[�W�ʂ���������Ώ���������1��̃_���[�W�ɐݒ�
            tempDamage = Mathf.Min(amountOfDamageAtOneTime, damage);
            hp -= tempDamage;
            //�@�S�̂̔䗦�����߂�
            hpSlider.value = (float)hp / maxHP;
            //�@�S�_���[�W�ʂ���1��Ō��炵���_���[�W�ʂ����炷
            damage -= tempDamage;
            //�@�S�_���[�W�ʂ�0��艺�ɂȂ�����0��ݒ�
            damage = Mathf.Max(damage, 0);

            countTime = 0f;
            //�@�_���[�W���Ȃ��Ȃ�����HP�o�[�̕ύX���������Ȃ��悤�ɂ���
            if (damage <= 0)
            {
                isReducing = false;
            }

            //�@HP��0�ȉ��ɂȂ�����G���폜
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
        countTime += Time.deltaTime;
    }

    //�@�_���[�W�l��ǉ����郁�\�b�h
    public void TakeDamage(int damage)
    {
        //�@�_���[�W���󂯂����ɈꊇHP�p�̃o�[�̒l��ύX����
        var tempHP = Mathf.Max(finalHP -= damage, 0);
        bulkHPSlider.value = (float)tempHP / maxHP;
        this.damage += damage;
        countTime = 0f;
        //�@��莞�Ԍ��HP�o�[�����炷�t���O��ݒ�
        Invoke("StartReduceHP", delayTime);
    }

    //�@���X��HP�o�[�����炷�̂��X�^�[�g
    public void StartReduceHP()
    {
        isReducing = true;
    }
}
