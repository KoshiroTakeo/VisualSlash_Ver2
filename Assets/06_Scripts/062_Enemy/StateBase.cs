#region HeaderComent
//==================================================================================
// StateBase
// �G�̃X�e�[�g�̊��N���X
// �쐬����	:2022/10/7
// �쐬��	:�O�c����
//---------- �X�V���� ----------
// 2022/10/7   ����͂���
//==================================================================================
#endregion

public abstract class StateBase
{
    /// <summary>
    /// �J�n���ɌĂ΂��
    /// </summary>
    public virtual void OnEnter(EnemyCommon owner, StateBase prev) {}

    /// <summary>
    /// �X�V���ɌĂ΂��
    /// </summary>
    public virtual void OnUpdate(EnemyCommon owner) { }

    /// <summary>
    /// �X�V��(fixed)�ɌĂ΂��
    /// </summary>
    public virtual void OnFixedUpdate(EnemyCommon owner) { }

    /// <summary>
    /// �I�����ɌĂ΂��
    /// </summary>
    public virtual void OnExit(EnemyCommon owner, StateBase next) { }
}
