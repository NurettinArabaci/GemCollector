using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum PopUpType { Open, Close }
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject popUpPanel;
    [SerializeField] Button popUpOpenButton, popUpCloseButton;

    private void Awake()
    {
        PopUpOpenClose();
        popUpPanel.SetActive(false);
    }

    void PopUpOpenClose()
    {
        popUpOpenButton.onClick.AddListener(() =>
        {
            popUpPanel.SetActive(true);
            popUpPanel.transform.DOScale(1, 0.4f);
            popUpOpenButton.transform.DOScale(0, 0.1f).OnComplete(() =>
            popUpOpenButton.gameObject.SetActive(false));
        });

        popUpCloseButton.onClick.AddListener(() =>
        {
            popUpPanel.transform.DOScale(0, 0.2f).OnComplete(() => popUpPanel.SetActive(false));
            popUpOpenButton.gameObject.SetActive(true);
            popUpOpenButton.transform.DOScale(1, 0.2f);
        });
    }



}
