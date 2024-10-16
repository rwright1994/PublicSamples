
[System.Serializable]
public class StatModifier 
{
    public float Value{get;set;}
    public ModifierType ModifierType{get;}

    public StatModifier(float Value, ModifierType ModifierType)
    {
        this.Value = Value;
        this.ModifierType = ModifierType;    
    }
}
