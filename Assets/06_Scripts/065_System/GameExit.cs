using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour,IMusic
{
    AudioSource audioSource;

    public GameObject buttonObj;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //------------------------------------------------------------------
    //
    AudioClip[] IMusic.GetAudioClips()
    {
        return MusicPlayer.instance.soundList;
    }

    void IMusic.PlaySound(int No)
    {
        audioSource.PlayOneShot(MusicPlayer.instance.soundList[No]);
    }

    void IMusic.StopSound()
    {
        audioSource.Stop();
    }
    //------------------------------------------------------------------

    //�Q�[���I��:�{�^������Ăяo��
    public void EndGame()
    {
        // SE�𗬂�
        /*
        IMusic iMusic = buttonObj.GetComponent<IMusic>();
        if (iMusic != null)
        {
            iMusic.PlaySound(0);
        }
        */
        SoundManager.Instance.PlaySE(SESoundData.SE.StartButton);

        //#if UNITY_EDITOR
        // �G�f�B�^�[����I�����������Ƃ�
        //UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
        //#else
        Application.Quit();//�Q�[���v���C�I��
                           //#endif
    }

}