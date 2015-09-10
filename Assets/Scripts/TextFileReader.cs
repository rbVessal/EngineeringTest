using UnityEngine;
using System.IO;

public class TextFileReader : MonoBehaviour 
{
	//Read the text file found in Assets/Resources
	public static StringReader ReadTextFile(string textFileNamePath)
	{
		TextAsset textContent = Resources.Load(textFileNamePath) as TextAsset;
		if(textContent)
		{
			return new StringReader(textContent.text);
		}
		else
		{
			Debug.Log("Could not find text file given the path: " + textFileNamePath + " Please check that the file is correctly name and in the correct path.");
			return null;
		}
	}
}
