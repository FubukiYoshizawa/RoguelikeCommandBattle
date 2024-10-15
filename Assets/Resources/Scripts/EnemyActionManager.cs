using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyActionManager : Singleton<EnemyActionManager>
{
    public EnemyStatusManager enemyStatusManager; // �X�L���̊e�l�Ǘ��p�̃X�N���v�g

    public TextMeshProUGUI battleText; // �e�L�X�g�\��

    public IEnumerator EnemyAction()
    {
        if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[0].eNAME)
        {
            yield return StartCoroutine(Slime());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[1].eNAME)
        {
            yield return StartCoroutine(IkeBat());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[2].eNAME)
        {
            yield return StartCoroutine(HatGhost());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[3].eNAME)
        {
            yield return StartCoroutine(GodADeath());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[4].eNAME)
        {
            yield return StartCoroutine(TornadoMan());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[5].eNAME)
        {
            yield return StartCoroutine(ThunderOni());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[6].eNAME)
        {
            yield return StartCoroutine(InfernoButterfly());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[7].eNAME)
        {
            yield return StartCoroutine(DarkDragon());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[8].eNAME)
        {
            yield return StartCoroutine(IceDragon());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[9].eNAME)
        {
            yield return StartCoroutine(BabyDragon());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[10].eNAME)
        {
            yield return StartCoroutine(LightDragon());
        }

    }

    public IEnumerator Slime()
    {
        battleText.text = $"{BattleManager.Instance.enemyName}��\n�X���C���V���b�g��������I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyStatusManager.DataList[0].skillValue1}�̃_���[�W�I";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= enemyStatusManager.DataList[0].skillValue1;
        if (BattleManager.Instance.playerHP < 0)
        {
            BattleManager.Instance.playerHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator IkeBat()
    {
        battleText.text = $"{BattleManager.Instance.enemyName}��\n�t���C���O�A�^�b�N��������I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyStatusManager.DataList[1].skillValue1}�̃_���[�W�I";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= enemyStatusManager.DataList[1].skillValue1;
        if (BattleManager.Instance.playerHP < 0)
        {
            BattleManager.Instance.playerHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator HatGhost()
    {
        battleText.text = $"{BattleManager.Instance.enemyName}��\n�t�@�C�A�{�[����������I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyStatusManager.DataList[2].skillValue1}�̃_���[�W�I";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= enemyStatusManager.DataList[2].skillValue1;
        if (BattleManager.Instance.playerHP < 0)
        {
            BattleManager.Instance.playerHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator GodADeath()
    {
        battleText.text = $"{BattleManager.Instance.enemyName}��\n����U�肩�Ԃ����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyStatusManager.DataList[3].skillValue1}�̃_���[�W�I";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= enemyStatusManager.DataList[3].skillValue1;
        if (BattleManager.Instance.playerHP < 0)
        {
            BattleManager.Instance.playerHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator TornadoMan()
    {
        battleText.text = $"{BattleManager.Instance.enemyName}��\n�����������N�������I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyStatusManager.DataList[4].skillValue1}�̃_���[�W�I";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= enemyStatusManager.DataList[4].skillValue1;
        if (BattleManager.Instance.playerHP < 0)
        {
            BattleManager.Instance.playerHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator ThunderOni()
    {
        battleText.text = $"{BattleManager.Instance.enemyName}��\n���_���Ă񂾁I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyStatusManager.DataList[5].skillValue1}�̃_���[�W�I";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= enemyStatusManager.DataList[5].skillValue1;
        if (BattleManager.Instance.playerHP < 0)
        {
            BattleManager.Instance.playerHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator InfernoButterfly()
    {
        int randomValue = Random.Range(0, 5);
        if (randomValue <= 3)
        {
            battleText.text = $"{BattleManager.Instance.enemyName}��\n�t�@�C�A�{�[�����������I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[6].skillValue1}�̃_���[�W�I";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[6].skillValue1;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }
        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName}��\n�΂̕����W�߂��I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{BattleManager.Instance.enemyName}��\nHP��{enemyStatusManager.DataList[7].skillValue1}�񕜂����I";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.enemyHP += enemyStatusManager.DataList[7].skillValue1;
            if (BattleManager.Instance.enemyHP > BattleManager.Instance.enemyMaxHP)
            {
                BattleManager.Instance.enemyHP = BattleManager.Instance.enemyMaxHP;
            }

        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator DarkDragon()
    {
        int randomValue = Random.Range(0, 5);
        if (randomValue <= 2)
        {
            battleText.text = $"{BattleManager.Instance.enemyName}��\n�_�[�N�u���X��������I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[7].skillValue1}�̃_���[�W";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[7].skillValue1;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }
        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName}��\n�_�[�N�I�[����������I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[7].skillValue2}�̃_���[�W�I";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[7].skillValue2;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }

        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator IceDragon()
    {
        int randomValue = Random.Range(0, 5);
        if (randomValue <= 2)
        {
            battleText.text = $"{BattleManager.Instance.enemyName}��\n�A�C�X�u���X��������I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[8].skillValue1}�̃_���[�W�I";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[8].skillValue1;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }
        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName}��\n�A�C�X���C����������I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[8].skillValue2}�̃_���[�W�I";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[8].skillValue2;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }

        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator BabyDragon()
    {
        int randomValue = Random.Range(0, 3);
        if (randomValue <= 1)
        {
            battleText.text = $"{BattleManager.Instance.enemyName}��\n�v�`�u���X��������I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[9].skillValue1}�̃_���[�W�I";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[9].skillValue1;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }
        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName}��\n�����W�߂��I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{BattleManager.Instance.enemyName}��\nHP��{enemyStatusManager.DataList[9].skillValue3}�񕜂����I";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.enemyHP += enemyStatusManager.DataList[9].skillValue3;

        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator LightDragon()
    {
        int randomValue = Random.Range(0, 8);
        if (randomValue <= 4)
        {
            battleText.text = $"{BattleManager.Instance.enemyName}��\n���C�g�j���O�u���X��������I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[10].skillValue1}�̃_���[�W�I";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[10].skillValue1;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }
        }
        else if (randomValue <= 6)
        {
            battleText.text = $"{BattleManager.Instance.enemyName}��\n���C�g�j���O�V���b�g��������I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[10].skillValue2}�̃_���[�W�I";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[10].skillValue2;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }

        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName}��\n�����W�߂��I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{BattleManager.Instance.enemyName}��\nHP��{enemyStatusManager.DataList[10].skillValue3}�񕜂����I";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.enemyHP += enemyStatusManager.DataList[10].skillValue3;

        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

}
