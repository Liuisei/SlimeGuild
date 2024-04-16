using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnGacha : MyButton
{
    [SerializeField]
    private int price = 10;

    [SerializeField]
    private bool isTenGacha;
    
    protected override void OnButtonUp()
    {
        if(isTenGacha) OnTenGacha();
        else OnOneGacha();
    }
    
    private void OnOneGacha()
    {
        if (DataManager.Instance.Money < price)
        {
            Debug.Log("お金が足りません");
        }
        else
        {
            DataManager.Instance.Money -= price;
            GachaManager.Instance.DrawGacha();
            SceneManager.LoadScene(2);
        }
    }
    private void OnTenGacha()
    {
        if (DataManager.Instance.Money < price * 10)
        {
            Debug.Log("お金が足りません");
        }
        else
        {
            DataManager.Instance.Money -= price * 10;
            for (int i = 0; i < 10; i++)
            {
                GachaManager.Instance.DrawGacha();
            }
            SceneManager.LoadScene(3);
        }
    }
}