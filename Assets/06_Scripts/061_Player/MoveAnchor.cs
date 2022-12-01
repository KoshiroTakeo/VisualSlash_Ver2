//============================================================
// Controller.cs
//======================================================================
// �J������
//
// 2022/05/01 author �|���F����AMoveManager�ɕK�v
// 
//
//======================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnchor : MonoBehaviour
{
    public GameObject Centereye; // �J�������W�擾
    public GameObject PlayerObj; // �v���C���[����


    public MoveAnchor(GameObject _centereye, GameObject _player)
    {
        Centereye = _centereye;
        PlayerObj = _player;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0,3,0);
        this.transform.rotation = new Quaternion();
    }

    // Update is called once per frame
    void Update()
    {
        //localPosition�łȂ��Ɩ\��
        this.transform.position = new Vector3(Centereye.transform.localPosition.x,30, Centereye.transform.localPosition.z);
        this.transform.rotation = PlayerObj.transform.rotation;
    }
}
