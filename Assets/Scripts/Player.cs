using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	//To be called when player logs in
	public delegate void LoggedInAction();
	public static event LoggedInAction LoggedIn;

	static bool isLoggedIn;
	static Account account;

	// Use this for initialization
	void Start () 
	{
	
	}

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

	public static void Account(Account newAccount)
	{
		account = newAccount;
		Player.LoggedIn();
		Debug.Log("account username: " + account.userName);
	}
}
