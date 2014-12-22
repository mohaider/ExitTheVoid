using UnityEngine;
using System.Collections;

public class HintText : MonoBehaviour {
	//View class

	public string hintText;
	public GUIText guiText;
	public GameObject HintBox;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		
	}
	public void UpdateText(string text)
	{
		this.hintText = text;
		guiText.text = text;

	}

	public void ActivateHintText(string hint)
	{
		this.hintText = hint;
		guiText.text = hintText;
		HintBox.SetActive (true);
	}

	public void DeactivateHintText()
	{
		//set the text back to nothing and deactivate the game object

		this.hintText = "";
		guiText.text = hintText;
		HintBox.SetActive (false);

		}


}


public class StringFormatter
{

	public static string SplitString(string s, int maxLengthPerLine)
	{
		string outputStr = "";
		int linesRequired = 0;
		if (s.Length % maxLengthPerLine != 0)
			linesRequired = 1;
		linesRequired += s.Length / maxLengthPerLine;

		
		//need to check: if we're at the end of a line and it's not a white space, we need to add
		// '-'. if it is a '\n' then we must skip it. 
		for (int i = 0; i < linesRequired;i++)
		{
			bool dontSkipFlag = true;
			for (int j = 0; j < maxLengthPerLine; j++)
			{
				if (maxLengthPerLine*i + j >=s.Length)
				{

					i = maxLengthPerLine +2;
					break;
				}
				
				if( j == maxLengthPerLine -1 && char.IsWhiteSpace(s[maxLengthPerLine*i + j]))
				{

					continue;
				}
				
				//if the index is not out of range
				if (!(maxLengthPerLine*i + j+1 >=s.Length))
				{

					if( j == maxLengthPerLine -1 && !char.IsWhiteSpace(s[maxLengthPerLine*i + j+1]) &&char.IsLetter(s[maxLengthPerLine*i + j+1]))
					{

						outputStr +=s[maxLengthPerLine*i + j];
						outputStr +='-';
						outputStr+= "\n";
						dontSkipFlag =false;	
						continue;
						
					}
				}
				outputStr +=s[maxLengthPerLine*i + j];
				
			}
			if(dontSkipFlag)
				outputStr+= "\n";
			
		}
		return outputStr;
	}


}