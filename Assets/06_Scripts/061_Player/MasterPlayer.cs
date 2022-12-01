//============================================================
// �V�[����̃v���C���[
//======================================================================
// �J������
// 20220728:�p������̂��ߍč\�z
//======================================================================
using UnityEngine;
using UnityEngine.InputSystem;

namespace VR.Players
{
    public class MasterPlayer : MonoBehaviour,IInputable
    {
        // �e�N���X�K�v�R���|�[�l���g�iUnity�ˑ��j
        CharacterController PlayerCharacter; 

        GameObject AnchorObject;                     // ���V�ړ��p
        [SerializeField] GameObject CenterEyeAnchor; // �J�����iHMD�{�́j
        Vector3 InitirizeAnchorPos = new Vector3();

        // Player�̃p�����[�^�f�[�^
        [SerializeField] PlayerData Data; // �X�N���v�^�u��
        [SerializeField] PlayerParameter Parameter;

        // �ړ��N���X
        HoverMover HoverMove;  // ���V�ړ�
        float fsetSpeed;
        bool bLBreak = false;
        bool bRBreak = false;

        // �V�[����̂Ƃ��Ă����ׂ��I�u�W�F�N�g
        GameManager Manager;
        IDamage DamageEffect;
        IRecovery SkillEffect;


       

        private void Start()
        {
            PlayerCharacter = GetComponent<CharacterController>();

            AnchorObject = new GameObject("AnchorObject");
            AnchorObject.transform.position = this.gameObject.transform.position;
            MoveAnchor moveAnchor = new MoveAnchor(CenterEyeAnchor, this.gameObject);
            moveAnchor = AnchorObject.AddComponent<MoveAnchor>();

            moveAnchor.Centereye = CenterEyeAnchor;
            moveAnchor.PlayerObj = this.gameObject;
            Debug.Log(moveAnchor.Centereye);


            Parameter = new PlayerParameter(Data);
            fsetSpeed = Parameter.fSpeed;
            bLBreak = false;
            bRBreak = false;
            HoverMove = new HoverMover();

            Manager = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
            //DamageEffect = GameObject.FindWithTag("UIs").GetComponent<IDamage>();
            //SkillEffect = GameObject.FindWithTag("UIs").GetComponent<IRecovery>();
        }

        private void Update()
        {
            // ���S�����炱�������s���Ȃ�
            if (Parameter.bDeath)
            {
                Manager.OnGameOver();
                return;
            }

            // ���V�ړ�
            HoverMove.HeadInclinationMove(this.gameObject ,PlayerCharacter, AnchorObject.transform.position, InitirizeAnchorPos, fsetSpeed);
        }

        // ���R���g���[���[����
        public void PressTriggerAction_L()
        {
            

            SkillEffect.RecoveryEffect();
        }
        public void HoldTriggerAction_L(float value)
        {

        }

        public void PressGripAction_L()
        {
            
        }

        public void HoldGripAction_L(float value)
        {
            if (value >= 0.7f)
            {
                fsetSpeed = fsetSpeed * 0.99f;
                bLBreak = true;
                
            }
            else if(bLBreak == true && bRBreak == true)
            {
                
                fsetSpeed = fsetSpeed * 0.3f;
            }
            else
            {
                fsetSpeed = Parameter.fSpeed;
                bLBreak = false;
            }

        }

        public void PressButton_X()
        {
            
        }

        public void PressButton_Y()
        {
           
        }

        public void PressButton_Menu()
        {

        }

        // �E�R���g���[���[����
        public void PressTriggerAction_R()
        {
            Debug.Log("sss");
            //SkillEffect.RecoveryEffect();
        }

        public void HoldTriggerAction_R(float value)
        {
            if (value >= 0.7f)
            {
                fsetSpeed = fsetSpeed * 0.99f;
                bRBreak = true;
            }
            else
            {
                fsetSpeed = Parameter.fSpeed;
                bRBreak = false;
            }
        }

        public void PressGripAction_R()
        {

        }

        public void HoldGripAction_R(float value)
        {

        }

        public void PressButton_A()
        {
            
        }

        public void PressButton_B()
        {
            
        }

        public void PressButton_Start()
        {

        }

        

        // �ڐG����
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "EnemyAttack")
            {
                StartCoroutine(Parameter.OnArmorTime());
                //DamageEffect.DamageEffect();
                Manager.CheckDamage();
                Parameter.CheckHP();
            }

        }

        
        
    }
}

