//============================================================
// �Q�[���̐i�s
//======================================================================
// �J������
// 20221018:����
//======================================================================
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float WorldTime = 1.0f; // �Q�[������
    public float AccelSpeed = 1.0f; // �v���C���[�̉����x
    float fMinSpeed = 0.5f; // �Œᑬ�x
    float fMaxSpeed = 5.0f; // �ő呬�x

    public bool GameOver = false; // �Q�[���I�[�o�[�̔���



    private void Awake()
    {
        GameOver = false;
    }



    private void Start()
    {
        
    }



    private void Update()
    {
        if(fMaxSpeed > AccelSpeed) AccelSpeed *= 1.0001f;
    }

    
    public void CheckDamage()
    {
        Debug.Log("���x�ቺ");
        if(fMinSpeed < AccelSpeed) AccelSpeed *= 0.9f;
    }

    public void OnSkill()
    {
        Debug.Log("�X�L������");
        WorldTime = 0.8f;
    }

    // �X�e�[�W�J�n����
    void OnGameStart()
    {
        
    }

    // �Q�[���I�[�o�[����
    public void OnGameOver()
    {
        Debug.Log("�Q�[���I��");
        GameOver = true;
    }
}
