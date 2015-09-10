using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
 
public class AccountDatabase : MonoBehaviour 
{
	static Dictionary<string, Sprite> accountDatabase;

	// Use this for initialization
	void Start () 
	{
		accountDatabase = new Dictionary<string,Sprite>();
		//Create all of the account textures and store them in the dictionary
		//that acts as a database
		//Ideally it would be a database hosted on a server,
		//but due to short time, let's just make it a text file
		//and load the accounts from the text file into a dictionary
		LoadAccounts("TextFiles/Accounts");
	}

	void LoadAccounts(string accountTextFilePath)
	{
		StringReader stringReader = TextFileReader.ReadTextFile(accountTextFilePath);
		string line;
		Rect badgeRect = new Rect(Vector2.zero, new Vector2(186.0f, 47.0f));
		while((line = stringReader.ReadLine()) != null)
		{
			string[] accountData = line.Split(new char[]{','});
			Texture2D texture = Resources.Load (accountData[1]) as Texture2D;
			Sprite sprite = Sprite.Create(texture, badgeRect, Vector2.zero);
			accountDatabase[accountData[0]] = sprite;
		}
	}

	public static void GetAccountImageBasedOnUserName(ref string userName, out Sprite accountSprite)
	{
		accountSprite = accountDatabase[userName];
	}
}
