
public class BtnNormal : MyButton
{
    protected override void OnButtonUp()
    {
        SoundManager.Instance.PlaySE(SeSoundData.Se.Button);
    }
}
