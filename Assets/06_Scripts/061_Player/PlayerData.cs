//============================================================
// �v���C���[�f�[�^�̃X�N���^�u���f�[�^
//======================================================================
// �J������
// 20220729:�p������̂��ߍč\�z
//======================================================================
using UnityEngine;

namespace VR.Players
{
    // ������e�L�X�g�f�[�^��
    [CreateAssetMenu(menuName = "Scriptable/New Create PlayerData")]
    public class PlayerData : ScriptableObject
    {
        // �e�p�����[�^
        public int nHP = 5;
        public float fSpeed = 1;
        public float fArmorTime = 0.8f;
        public float fSkillTime = 3.0f;

    }
}
