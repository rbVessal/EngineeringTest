using UnityEngine;
using System.Collections;

public class ChooseAccountModal : MonoBehaviour 
{
	void toggleVisibility()
	{
		//Display the group chat history
		if(Player.IsLoggedIn()
		   && this.gameObject.activeSelf)
		{
			this.gameObject.SetActive(false);
			
		}
		//Otherwise ask the player to choose an account to login to
		else
		{
			if(!this.gameObject.activeSelf)
			{
				this.gameObject.SetActive(true);
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{
		toggleVisibility();
	}
}
