using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IRecovery
{
    void RecoveryEffect();
}

public class RecoveryUI : MonoBehaviour,IRecovery
{
    public static RecoveryUI instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    SpriteRenderer spriteRenderer;

    public void Start()
    {

    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    IEnumerator GameSkill()
    {
        // �ԓ_��
        int count = 0;
        while (count < 10)
        {
            // ������
            spriteRenderer.color = new Color32(13, 97, 243, 100);
            yield return new WaitForSeconds(0.05f);

            // ��
            spriteRenderer.color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.05f);

            count++;
        }


    }

    public void RecoveryEffect()
    {
        StartCoroutine(GameSkill());
    }
}
