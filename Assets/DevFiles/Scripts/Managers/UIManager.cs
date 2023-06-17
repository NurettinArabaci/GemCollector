using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject popUpPanel;
    [SerializeField] Button _popUpOpenButton, _popUpCloseButton;

    private void Awake()
    {
        PopUpOpenButton();
        PopUpCloseButton();

    }

    void PopUpOpenButton()
    {
        _popUpOpenButton.onClick.AddListener(() =>
        {
            popUpPanel.SetActive(true);
            popUpPanel.transform.localScale = Vector3.zero;
            popUpPanel.transform.DOScale(1, 0.4f);

            _popUpOpenButton.transform.DOScale(0, 0.1f).OnComplete(() =>
                _popUpOpenButton.gameObject.SetActive(false));

        });

        
    }

    void PopUpCloseButton()
    {
        _popUpCloseButton.onClick.AddListener(() =>
        {
            popUpPanel.transform.DOScale(0, 0.2f).OnComplete(() => popUpPanel.SetActive(false));
            _popUpOpenButton.gameObject.SetActive(true);
            _popUpOpenButton.transform.DOScale(1, 0.2f);

            
        });
    }
     

}
