using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	//To be called when player logs in
	public delegate void LoggedInAction();
	public static event LoggedInAction LoggedIn;

	static bool isLoggedIn;
	static Account account;

	//Setters and getters
	public static bool IsLoggedIn()
	{
		if(account != null)
		{
			return true;
		}
		return false;
	}

	public static string UserName()
	{
		if(account != null)
		{
			return account.userName;
		}
		return null;
	}

	public static Image Icon()
	{
		if(account != null)
		{
			return account.userIcon;
		}
		return null;
	}

	public static void SetAccount(Account newAccount)
	{
		account = newAccount;
		Player.LoggedIn();
	}
}
