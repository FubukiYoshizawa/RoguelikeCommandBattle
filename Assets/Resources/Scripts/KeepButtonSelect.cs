using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeepButtonSelect : MonoBehaviour
{
    private GameObject lastSelected;

    void Update()
    {
        // ���ݑI������Ă���{�^�����Ȃ��ꍇ�A�O��̑I���𕜌�����
        if (EventSystem.current.currentSelectedGameObject == null && Input.GetMouseButton(0))
        {
            EventSystem.current.SetSelectedGameObject(lastSelected);
        }
        else
        {
            // ���ݑI������Ă���I�u�W�F�N�g���L��
            lastSelected = EventSystem.current.currentSelectedGameObject;
        }
    }
}