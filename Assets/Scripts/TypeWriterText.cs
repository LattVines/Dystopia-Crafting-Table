using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypeWriterText : MonoBehaviour {


	Text text_obj;
	string string_to_type;
	//public AudioClip sfx_click;

	void Start(){
		text_obj = GetComponent<Text>();
		string_to_type = text_obj.text;
		text_obj.text = string.Empty;

	}




	void OnEnable(){
		StartCoroutine(TypeWriterEffect());
	}


	public IEnumerator TypeWriterEffect(){
		

		yield return new WaitForSeconds(0.05f);
		text_obj.text = string.Empty;
		
		int characters_to_type = string_to_type.Length;
		
		for(int type_spot =0; type_spot < characters_to_type; type_spot++)
		{

			text_obj.text = string_to_type.Substring(0, type_spot + 1)
                + "<color=#0000>" + string_to_type.Substring(type_spot + 1) + "</color>";

			/*
			if (type_spot % 3 == 0)
				SFXController.PlayClip(sfx_click);
			*/
			
			yield return new WaitForSeconds(0.009f);


		}
		
		yield return new WaitForSeconds(0.2f);
        Destroy(this);
	}

}
