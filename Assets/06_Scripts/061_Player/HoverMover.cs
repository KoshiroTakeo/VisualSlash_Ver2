//============================================================
// ���̈ړ�����
//======================================================================
// �J������
// 20220729:�p������̂��ߍč\�z
// 20220811:�������ǉ��AfRadius�ƌ��������ύX�ł���悤�ɂ�����
//======================================================================
using UnityEngine;

namespace VR.Players
{
    public class HoverMover 
    {
        // �K�v�Ȃ���
        public float fRadius = 0.1f; // �����J�n����
        public float fbrakepower = 2f;  // �u���[�L���x
        public float fstopmagnitude = 1f;

        float fnowspeed;

        // �������i���S���u������������N���X�j
        //DrawCircle AccelCircle;

        public void HeadInclinationMove(GameObject _parent, CharacterController _character ,Vector3 _anchor, Vector3 _initirizepos, float _speed)
        {
            // �����ʒu�ƈړ��ʒu�̍����Ƃ�i�C���X�^���X�����𖈉񂩂��Ă���̂ŏd���Ȃ��Ă��邩���j
            Vector3 setDirection = new Vector3(_anchor.x - _initirizepos.x, 0, 0); 
            float fsetSpeed = _speed - fRadius;

            // ��~�͈͊O�ɏo���Ƃ�����o��
            if (Calcurate(setDirection.x, setDirection.z) > fRadius)
            {               
                // �����i�K
                if(fsetSpeed >= fnowspeed)
                {
                    _character.Move(setDirection * Time.fixedDeltaTime * (fnowspeed += fsetSpeed / 20));
                }
                else
                {
                    _character.Move(setDirection * Time.fixedDeltaTime * fsetSpeed);
                }
            }
            else
            {
                fnowspeed = 0;
                if (_character.velocity.magnitude > fstopmagnitude)
                {
                    _character.Move(setDirection * Time.fixedDeltaTime * (fsetSpeed / (_speed / 20)));
                }
                
            }

            //// �~�`�� getcomponent
            //if(AccelCircle == null)
            //{
            //    AccelCircle = _parent.AddComponent<DrawCircle>();
            //    Debug.Log(AccelCircle);
            //}

            
            //AccelCircle.Draw(_parent, fRadius * 10, _initirizepos, fnowspeed);
            
        }

        // �ėp�������͂������番�������i���̂����j
        public float Calcurate(float _x, float _y)
        {
            float radius;

            radius = (_x * _x) + (_y * _y);

            return Mathf.Sqrt(radius);
        }
    }
}
