using UnityEngine;
using UnityEngine.UI;

public class DefenderFormulaPanel : MonoBehaviour
{

    public string ability = string.Empty;
    public string challenge_used = string.Empty;
    public int constant_bonus = 0;
    public InputField constantBonusInput;//SET IN EDITOR
    public Text formula_text;//SET IN EDITOR

    void Start()
    {
        UpdateFormulaText();
    }


    public void SetAbilityBonus(string s)
    {
        ability = s;
        UpdateFormulaText();
    }

    public void SetChallengeBonus(string s)
    {
        challenge_used = s;
        UpdateFormulaText();
    }

    public void UpdateConstantBonus()
    {
        constant_bonus = int.Parse(constantBonusInput.text.ToString());
        UpdateFormulaText();
    }


    public void UpdateFormulaText()
    {
        int max = 0; int min = 0;

        //these ability values are used for determining the max & min.
        int brawn = 0; int brains = 0; int agility = 0;

        string ability_string = string.Empty;
        string constant_bonus_string = string.Empty;
        string formula;

        //---------------- ability score stuff ----------
        if (ability == "Brawn")
        {
            brawn += 10;
        }
        if (ability == "Brains")
        {
            brains += 10;
        }
        if (ability == "Agility")
        {
            agility += 10;
        }


        //------------------------------------------------


        //constant value stuff ----------------------------
        if (constant_bonus > 0)
        {
            constant_bonus_string = " + " + constant_bonus.ToString();
        }
        else if (constant_bonus < 0)
        {
            constant_bonus_string = " - " + Mathf.Abs(constant_bonus).ToString();
        }
        //------------------------------------------------


        //-------------------------- CHALLENGE --------------
        string challenge_String = string.Empty;
        if (challenge_used != string.Empty)
        {
            challenge_String = "CHALLENGE";
        }
        //-----------------------------------------------

        max = brawn + brains + agility + constant_bonus;
        min = 0 + 0 + 0 + constant_bonus;
        if (challenge_used != string.Empty)
        {
            max += 10;//agility + brawn + brains + constant bonus + roll of 10 on challenge if used
            min += 1;//agility + brawn + brains + constant bonus + roll of 1
        }

        string formula_builder = string.Empty;

        //case just challenge
        if (challenge_String != string.Empty) formula_builder = challenge_String;


        //case ability with or without challenge
        if(ability != string.Empty && challenge_String != string.Empty)
        {
            formula_builder = challenge_String + " + " + ability;
        }
        else if(ability != string.Empty && challenge_String == string.Empty)
        {
            formula_builder = ability;
        }

        //case ability, challenge and constant
        if(formula_builder == string.Empty && constant_bonus_string != string.Empty)
        {
            formula_builder = constant_bonus_string;
        }
        else if(formula_builder != string.Empty && constant_bonus_string != string.Empty)
        {
            formula_builder = formula_builder + constant_bonus_string;
        }


        formula = "Defend Formula:\n" + formula_builder
            + "\nMaximum Roll: " + max.ToString()
            + "\nMinimum Roll: " + min.ToString();

        formula_text.text = formula;


    }


}
