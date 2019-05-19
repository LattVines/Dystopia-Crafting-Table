using UnityEngine;
using UnityEngine.UI;

public class AttackFormulaPanel : MonoBehaviour
{
    public string ability = string.Empty;
    public string scaler = string.Empty;
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
        GameController.attack_ability_string = s;
        UpdateFormulaText();
    }

    public void SetScalerBonus(string s)
    {
        scaler = s;
        GameController.attack_scaler_string = s;
        UpdateFormulaText();
    }

    public void UpdateConstantBonus()
    {
        constant_bonus = int.Parse(constantBonusInput.text.ToString());
        GameController.attack_constant_int = constant_bonus;
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


        if (ability != string.Empty)
        {
            ability_string = ability + " + ";
        }
        //------------------------------------------------


        //constant value stuff ----------------------------
        if(constant_bonus > 0)
        {
            constant_bonus_string = " + " + constant_bonus.ToString();
        }
        else if (constant_bonus < 0)
        {
            constant_bonus_string = " - " + Mathf.Abs(constant_bonus).ToString();
        }
        //------------------------------------------------


        //-------------------------- scaler --------------
        string scaler_string = string.Empty;
        if (scaler != string.Empty)
        {
            scaler_string = " + " + scaler;
        }
        //-----------------------------------------------

        max = brawn + brains + agility + constant_bonus + 10;
        min = 0 + 0 + 0 + constant_bonus + 1;//agility + brawn + brains + constant bonus + roll of 1 + at least level 1 if scaler used
        if (scaler != string.Empty)
        {
            max += 10;
            min += 1;
        }

        formula = "Attack Formula:\n" + ability_string + "d10" + scaler_string + constant_bonus_string
            + "\nMaximum Roll: " + max.ToString()
            + "\nMinimum Roll: " + min.ToString();

        formula_text.text = formula;
        GameController.attack_formula = formula;
    }


}

