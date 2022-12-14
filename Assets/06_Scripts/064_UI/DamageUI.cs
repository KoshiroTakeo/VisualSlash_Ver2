using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IDamage
{
    void DamageEffect();
}

public class DamageUI : MonoBehaviour,IDamage
{
    public static DamageUI instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    SpriteRenderer spriteRenderer;

    void Start()
    {

    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    IEnumerator GameOver()
    {
        // 赤点滅
        int count = 0;
        while (count < 10)
        {
            // 消える
            spriteRenderer.color = new Color32(255, 120, 120, 100);
            yield return new WaitForSeconds(0.05f);

            // つく
            spriteRenderer.color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.05f);

            count++;
        }


    }

    public void DamageEffect()
    {
        StartCoroutine(GameOver());
    }
}
