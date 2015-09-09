using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	bool isLoggedIn;
	Account account;

	// Use this for initialization
	void Start () 
	{
	
	}

	//Setters and getters
	public bool IsLoggedIn()
	{
		if(account != null)
		{
			return true;
		}
		return false;
	}

	public void Account(Account newAccount)
	{
		account = newAccount;
		Debug.Log("account username: " + account.userName);
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
