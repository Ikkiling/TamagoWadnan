using TMPro;
using UnityEngine;

public class CharacterEvolve : MonoBehaviour
{
    public int currentStage;

    public TMP_Text stageText;

    private void OnEnable()
    {
        CharacterExp.EvolveEvent += Evolve;
    }

    private void OnDisable()
    {
        CharacterExp.EvolveEvent -= Evolve;
    }

    private void Evolve()
    {
        currentStage++;

        if(stageText != null )
        {
            stageText.text = "Stage " + currentStage.ToString();
        }

        Debug.Log("stage = " + currentStage);
    }    
}
