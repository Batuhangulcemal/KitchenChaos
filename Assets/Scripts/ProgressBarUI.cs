using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;
    [SerializeField] private Image barImage;

    private void Start()
    {
        cuttingCounter.OnProgressChanged += CuttingCounter_OnProgressChanged;

        SetBarImageFillAmount(0f);
    }

    private void CuttingCounter_OnProgressChanged(object sender, CuttingCounter.OnProgressChangedEventArgs e)
    {
        SetBarImageFillAmount(e.progressNormalized);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);

    }

    private void SetBarImageFillAmount(float amount)
    {
        barImage.fillAmount = amount;
        if(amount == 0f || amount == 1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
}
