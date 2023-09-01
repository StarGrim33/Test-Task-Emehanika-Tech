public class SimpleFire : Fire
{
    private int _value = 15;

    protected override void AddCoin(IFirePicker coinPicker) => coinPicker.Add(_value);

    protected override void AddHeal(IHealable healable) => healable.AddHealth();
}
