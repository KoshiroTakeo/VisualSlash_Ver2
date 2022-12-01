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
        // ê‘ì_ñ≈
        int count = 0;
        while (count < 10)
        {
            // è¡Ç¶ÇÈ
            spriteRenderer.color = new Color32(13, 97, 243, 100);
            yield return new WaitForSeconds(0.05f);

            // Ç¬Ç≠
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
