using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashManager : Singleton<FlashManager>
{
    public Image playerFlashImage; // UI Image�̎Q��
    public Image enemyFlashImage; // EnemyImage�̎Q��
    public Color flashColor; // �_�ł���F
    public float flashDuration; // �_�ł̎�������

    private void Start()
    {
        playerFlashImage = GameObject.Find("FlashImage").GetComponent<Image>();
        enemyFlashImage = GameObject.Find("EnemyImage").GetComponent<Image>();

        if (playerFlashImage != null)
        {
            playerFlashImage.color = new Color(0, 0, 0, 0); // ������Ԃœ���
        }
    }

    // �O������Ăяo�����\�b�h
    public void FlashScreen(Color color, float duration)
    {
        flashColor = color;
        flashDuration = duration;
        StartCoroutine(FlashRoutine());
    }

    public void EnemyFlash(Color color, float duration)
    {
        flashColor = color;
        flashDuration = duration;
        StartCoroutine(EnemyFlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        float elapsedTime = 0f;
        playerFlashImage.color = flashColor;

        // �_�ł̃t�F�[�h�C��
        while (elapsedTime < flashDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, elapsedTime / (flashDuration / 2));
            playerFlashImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
            yield return null;
        }

        elapsedTime = 0f;

        // �_�ł̃t�F�[�h�A�E�g
        while (elapsedTime < flashDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsedTime / (flashDuration / 2));
            playerFlashImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
            yield return null;
        }

        playerFlashImage.color = new Color(0, 0, 0, 0); // ���S�ɓ����ɖ߂�
    }

    private IEnumerator EnemyFlashRoutine()
    {
        float elapsedTime = 0f;
        enemyFlashImage.color = flashColor;

        // �_�ł̃t�F�[�h�C��
        while (elapsedTime < flashDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, elapsedTime / (flashDuration / 2));
            enemyFlashImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
            yield return null;
        }

        elapsedTime = 0f;

        // �_�ł̃t�F�[�h�A�E�g
        while (elapsedTime < flashDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsedTime / (flashDuration / 2));
            enemyFlashImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
            yield return null;
        }

        enemyFlashImage.color = new Color(1, 1, 1, 1);
    }
}

