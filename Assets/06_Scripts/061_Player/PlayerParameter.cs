//============================================================
// �v���C���[�̔\�͒l
//======================================================================
// �J������
// 20220729:�p������̂��ߍč\�z
//======================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR.Players
{
    public class PlayerParameter
    {
        // �e�p�����[�^
        public int nHP;
        int nMaxHP;
        int nCurrentHP;
        public float fSpeed = 1;

        // ���S����
        public bool bDeath = false;

        // ���G����
        public WaitForSeconds WTSArmorTime;
        public bool bOnDamage = false;

        // �X���b�V���^�C��
        public bool bSkill = false;
        float fSkillTime;



        public PlayerParameter(PlayerData _data)
        {
            nMaxHP = nCurrentHP = nHP = _data.nHP;
            fSpeed = _data.fSpeed;
            fSkillTime = _data.fSkillTime;
            WTSArmorTime = new WaitForSeconds(_data.fArmorTime);

        }

        public void CheckHP()
        {
           
            if (nHP <= 0)
            {
                bDeath = true;
            }

        }

        public IEnumerator OnArmorTime()
        {

            if (bOnDamage == true) yield return 0;
            bOnDamage = true;
            nHP--;

            yield return WTSArmorTime;

            bOnDamage = false;
        }
    }
}
