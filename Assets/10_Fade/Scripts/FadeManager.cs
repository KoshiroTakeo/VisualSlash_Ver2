using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    //FadeCanvas�擾
    [SerializeField]
    private Fade fade;

    //�t�F�[�h���ԁi�b�j
    [SerializeField]
    private float fadeTime;


    // Start is called before the first frame update
    void Start()
    {
        if (fade == null)
        {
            Debug.Log("FadeCanvas��Inspector�ɂȂ���B");
        }

        //�V�[���J�n���Ƀt�F�[�h���|����
        //fade.FadeOut(fadeTime);
    }

    //�e�{�^�������������̏���
    public void SceneTransition(string sceneName)
    {
        // SE�𗬂�

        //�t�F�[�h���|���Ă���V�[���J�ڂ���
        fade.FadeIn(fadeTime, () =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }
}
