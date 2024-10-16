// Character Sheet Observer Class to watch for changes in Character Stats.

public interface ICharacterSheetObserver
{
    void OnHealthChanged(int newHealth);
    void OnStaminaChanged(int newStamina);
    void OnManaChanged(int newMana);
    void OnEnergyChanged(int newEnergy);
    void OnSpiritChanged(int newSpirit);
    void OnExperienceChanged(int newExperience);

}
