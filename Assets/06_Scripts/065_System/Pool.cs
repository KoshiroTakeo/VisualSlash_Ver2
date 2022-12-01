using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

#region HeaderComent
//==================================================================================
// Pool
//  �I�u�W�F�N�g�v�[���{��
// �쐬����	:2022/04/24
// �쐬��	:�O�c����
//---------- �X�V���� ----------
// 2021/04/24   ����͂��߂����I
//              
//==================================================================================
#endregion
public class Pool : MonoBehaviour
{
    // Prefab���G�f�B�^�Ŏw��
    [SerializeField] private PoolableObject pObj;
    [SerializeField] private GameObject stuck;

    // �v�[���̃T�C�Y���w��(�������ߖ�)
    private const int poolSize = 50;

    // �v�[���̎���   Queue���g�p
    public Queue<PoolableObject> qPool = new Queue<PoolableObject>(poolSize);

    // �v�[���ɃI�u�W�F�N�g������ꍇ������g�p�B
    // �Ȃ��ꍇ�A�V����Instantiate����
    public T Place<T>(Vector3 pos) where T : PoolableObject
    {
        return (T)Place(pos);
    }

    // �v�[���ɃI�u�W�F�N�g������΂���𗘗p����B
    public PoolableObject Place(Vector3 pos)
    {
        PoolableObject obj;
        if(qPool.Count > 0)
        {
            obj = qPool.Dequeue();
            obj.gameObject.SetActive(true);
            obj.transform.position = pos;
            obj.OnStart();
        }
        else
        {
            obj = Instantiate(pObj, pos, pObj.transform.rotation);
            obj.pool = this;
            obj.transform.parent = stuck.transform;
            obj.OnStart();
        }
        return obj;
    }

    // �I�u�W�F�N�g���v�[���ɖ߂�
    public void Return(PoolableObject obj)
    {
        obj.gameObject.SetActive(false);
        qPool.Enqueue(obj);
    }
}
