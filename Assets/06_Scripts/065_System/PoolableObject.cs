using UnityEngine;

#region HeaderComent
//==================================================================================
// PoolableObject
//	�v�[������ׂ̃I�u�W�F�N�g�̌p���p
// �쐬����	:2022/04/24
// �쐬��	:�O�c����
//---------- �X�V���� ----------
// 2021/04/24   ����͂��߂����I
//              
//==================================================================================
#endregion
public abstract class PoolableObject : MonoBehaviour
{
    // �v�[���ւ̎Q��
    public Pool pool{ private get; set; }

    // Start()�̑���
    public abstract void OnStart();

    // �v�[���ɖ߂�
    protected void ReturnToPool()
    {
        pool.Return(this);
    }
}
