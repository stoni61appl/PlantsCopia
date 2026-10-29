using UnityEngine;

public class SeedButton : MonoBehaviour
{
    public int plantIndex;  // Usar PascalCase

    public void OnClick()
    {
        PlantManager.Instance.SelectPlant(plantIndex);
    }
}
