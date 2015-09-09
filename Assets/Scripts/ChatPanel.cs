using UnityEngine;
using System.Collections;

public class ChatPanel : MonoBehaviour
{
	// Use this for initialization
	void Start () 
	{
		toggleDisplayChatHistory();
	}

	void toggleDisplayChatHistory()
	{
		GameObject playerGameObject = GameObject.FindWithTag("Player");
		Player player = playerGameObject.GetComponent<Player>() as Player;
		GameObject chooseAccountModalGameObject = GameObject.FindWithTag("ChooseAccountModal");
		//Display the group chat history
		if(player.IsLoggedIn())
		{
			chooseAccountModalGameObject.SetActive(false);

		}
		//Otherwise ask the player to choose an account to login to
		else
		{
			chooseAccountModalGameObject.SetActive(true);
		}
	}
}
