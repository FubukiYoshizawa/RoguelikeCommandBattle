using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashManager : Singleton<FlashManager>
{
    public Image playerFlashImage; // UI Image�̎Q��
    public Image enemyFlashImage; // EnemyImage�̎Q��
    public Color flashColor; // ���ł���F
    public float flashDuration; // ���ł̎�������

    private void Start()
    {
        // ���ł�����Image�I�u�W�F�N�g�̓ǂݍ���
        playerFlashImage = GameObject.Find("FlashImage").GetComponent<Image>();
        enemyFlashImage = GameObject.Find("EnemyImage").GetComponent<Image>();

        if (playerFlashImage != null)
        {
            playerFlashImage.color = new Color(0, 0, 0, 0); // ������Ԃœ���
        }
    }

    // ��ʑS�̖̂��Łi�v���C���[�p�j
    public void FlashScreen(Color color, float duration)
    {
        flashColor = color;
        flashDuration = duration;
        StartCoroutine(FlashScreenRoutine());
    }

    // �G�摜�̖��Łi�G�p�j
    public void EnemyFlash(Color color, float duration)
    {
        flashColor = color;
        flashDuration = duration;
        StartCoroutine(EnemyFlashRoutine());
    }

    // ��ʑS�̖̂��ł𐧌䂷��R���[�`��
    private IEnumerator FlashScreenRoutine()
    {
        float elapsedTime = 0f;
        playerFlashImage.color = flashColor;

        // ���ł̃t�F�[�h�C��
        while (elapsedTime < flashDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, elapsedTime / (flashDuration / 2));
            playerFlashImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
            yield return null;
        }

        elapsedTime = 0f;

        // ���ł̃t�F�[�h�A�E�g
        while (elapsedTime < flashDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsedTime / (flashDuration / 2));
            playerFlashImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
            yield return null;
        }

        playerFlashImage.color = new Color(0, 0, 0, 0);
    }

    // �G�摜�̖��ł𐧌䂷��R���[�`��
    private IEnumerator EnemyFlashRoutine()
    {
        float elapsedTime = 0f;
        enemyFlashImage.color = flashColor;

        // ���ł̃t�F�[�h�C��
        while (elapsedTime < flashDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, elapsedTime / (flashDuration / 2));
            enemyFlashImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
            yield return null;
        }

        elapsedTime = 0f;

        // ���ł̃t�F�[�h�A�E�g
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

