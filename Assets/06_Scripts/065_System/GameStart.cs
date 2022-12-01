using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour,IMusic
{

    AudioSource audioSource;

    public GameObject buttonObj;
    
    private bool firstPush = false;

    //FadeCanvas�擾
    [SerializeField]
    private Fade fade;

    //�t�F�[�h���Ԏ擾�i�b�j
    [SerializeField]
    private float fadeTime;



    // Start is called before the first frame update
    void Start()
    {
        firstPush = false;

        audioSource = buttonObj.GetComponent<AudioSource>();
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

    public void PushFadeout()
    {
        fade.FadeOut(fadeTime);
    }

    public void PushFadein()
    {
        fade.FadeIn(fadeTime, () =>
        {
            fade.FadeOut(fadeTime);
        });
    }

    public void sceneChange(string sceneName)//�{�^������ȂǂŌĂяo��
    {
        if (!firstPush)
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

            /*����*/
            // �T�u�V�[���ɐ؂�ւ���
            //�t�F�[�h���|���Ă���V�[���J�ڂ���
            fade.FadeIn(fadeTime, () =>
            {
                SceneManager.LoadScene(sceneName);
            });

            firstPush = true;
        }
    }

}
