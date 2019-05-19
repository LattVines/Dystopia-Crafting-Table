using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static string attack_ability_string = string.Empty;
    public static string attack_scaler_string = string.Empty;
    public static int attack_constant_int = 0;
    public static string attack_formula = string.Empty;


    public static string defend_ability_string = string.Empty;
    public static string defend_challenge_string = string.Empty;
    public static int defend_constant_int = 0;
    public static string defend_formula = string.Empty;


    private void Awake()
    {
        //reset static values
        attack_ability_string = string.Empty;
        attack_scaler_string = string.Empty;
        attack_constant_int = 0;
        attack_formula = string.Empty;


        defend_ability_string = string.Empty;
        defend_challenge_string = string.Empty;
        defend_constant_int = 0;
        defend_formula = string.Empty;
    }

}
