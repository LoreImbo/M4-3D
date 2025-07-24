using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_LifeControllerLab6 : MonoBehaviour
{
    [SerializeField] private Image _fillableLifebar;
    [SerializeField] private TextMeshProUGUI _lifeText;
    [SerializeField] private Gradient healthGradient;

    public void UpdateGraphics(int currentHp, int maxHP)
    {
        //_lifeText.text = "HP " + currentHp + "/" + maxHP;
        _fillableLifebar.fillAmount = (float)currentHp / maxHP; // devo castarne uno a float altrimenti la divisione verrebbe sempre 0 o 1
        _fillableLifebar.color = healthGradient.Evaluate(_fillableLifebar.fillAmount);

    }
}
