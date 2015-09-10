using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AccountButton : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		GetComponent<Button>().onClick.AddListener(SetPlayerToAccount);
	}

	void SetPlayerToAccount()
	{
		Account account = GetComponent<Account>() as Account;
		account.userIcon = GetComponent<Image>();
		Player.Account(account);
	}
}
