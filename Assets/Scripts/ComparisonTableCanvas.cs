using UnityEngine;
using UnityEngine.UI;

public class ComparisonTableCanvas : MonoBehaviour
{

    public Text attack_FormulaText, defend_Formulatext;
    public Text formula_text;//SET IN EDITOR
    const string SPACER = "\t\t\t\t";
    const string SPACER2 = "\t\t\t\t\t\t\t\t\t\t";


    private void OnEnable()
    {
        attack_FormulaText.text = GameController.attack_formula;
        defend_Formulatext.text = GameController.defend_formula;
        formula_text.text = GetFormattedTable();
       
    }

    string GetFormattedTable(){


        string s = "attacker lvl" + SPACER + "avg attack" + SPACER +"defender lvl" + SPACER + "avg defense by player" + SPACER + "avg defense by enemy\n";
        for(int i = 1; i <= 10; i++){
            s += GetTableRow(i) + "\n";
        }
        return s;
    }

    string GetTableRow(int player_level){
        string row = "row";

        //attack scaler lvl    avg attack       defend lvl   avg rolled by player      avg against enemy
        //1
        row = player_level + SPACER2 + GetAverageAttack(player_level) +
            SPACER2 + player_level +
            SPACER2 + GetAverageDefendPlayerVersion(player_level) +
            SPACER2 + GetAverageDefendCHALLENGEVersion(player_level);

        return row;
    }


    string GetAverageAttack(int player_level){
        int average_roll = 10;//attack always start with a roll on d20. So average is half.

        if(GameController.attack_scaler_string != string.Empty){
            average_roll += player_level;
        }

        if(GameController.attack_ability_string != string.Empty){
           average_roll += 5; //the average ability score
        }


        average_roll += GameController.attack_constant_int;

        return average_roll.ToString();
    }

    string GetAverageDefendPlayerVersion(int player_level){
        int average_roll = 0;

        if(GameController.defend_challenge_string != string.Empty){
            average_roll += player_level;
        }

        if(GameController.defend_ability_string != string.Empty){
           average_roll += 5; //the average ability score
        }
        average_roll += GameController.defend_constant_int;

        return average_roll.ToString();
    }


    string GetAverageDefendCHALLENGEVersion(int player_level){
        int average_roll = 0;

        if(GameController.defend_challenge_string != string.Empty){
           
            if(player_level <2){
                average_roll += 2; //using d4 for challenge
            }
            else if(player_level < 4){
                average_roll += 3; //using d6 for challenge
            }
            else if(player_level < 6){
                  average_roll += 4; //using d8 for challenge
            }
            else if (player_level < 8){
                 average_roll += 5; //using d8 for challenge
            }
            else{
                average_roll += 6; //using d8 for challenge
            }

        }
        if(GameController.defend_ability_string != string.Empty){
           average_roll += 5; //the average ability score
        }
        average_roll += GameController.defend_constant_int;

        return average_roll.ToString();
    }

}
