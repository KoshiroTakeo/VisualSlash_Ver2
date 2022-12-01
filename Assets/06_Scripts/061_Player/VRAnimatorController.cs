using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAnimatorController : MonoBehaviour
{
    float speedTreshold = 0.1f; // ���s���x�̍Œᔻ�f�l
    [Range(0, 1)]
    public float smoothing = 1;
    private Animator animator;
    private Vector3 previewsPos;
    private VRRig vrRig;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        vrRig = GetComponent<VRRig>();
        previewsPos = vrRig.head.vrTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        // �ߋ����W�ƈړ���̍��W�����
        Vector3 headsetSpeed = (vrRig.head.vrTarget.position - previewsPos) / Time.deltaTime;
        headsetSpeed.y = 0; // ��΂Ȃ�����
        Vector3 headsetLocalSpeed = transform.InverseTransformDirection(headsetSpeed);
        previewsPos = vrRig.head.vrTarget.position;


        // Animator�ɐݒ肳�ꂽ�l���󂯎��
        float previousDirectionX = animator.GetFloat("DirectionX");
        float previousDirectionY = animator.GetFloat("DirectionY");


        animator.SetBool("isMoving", headsetLocalSpeed.magnitude > speedTreshold); // ���s���Ă���Ȃ�A�j���[�V����������

        // �ߋ����W�ƈړ��������W�i-1�`1�̊ԁj��smmothing�����
        animator.SetFloat("DirectionX", Mathf.Lerp(previousDirectionX, Mathf.Clamp(headsetLocalSpeed.x, -1, 1), smoothing)); 
        animator.SetFloat("DirectionY", Mathf.Lerp(previousDirectionY, Mathf.Clamp(headsetLocalSpeed.z, -1, 1), smoothing));
    }
}
