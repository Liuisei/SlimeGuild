using System;

using TMPro;

public class AUGMoney : AutoUpdateGraphic<TextMeshProUGUI>
{
    protected override Action GetAction()
    {
        return DataManager.Instance.OnMoneyChanged;
    }

    protected override void UpdateGraphic()
    {
        GraphicComponent.SetText(DataManager.Instance.Money.ToString());
    }
}
