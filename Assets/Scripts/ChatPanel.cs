using UnityEngine;
using System.Collections;

public class ChatPanel : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		Player.LoggedIn += RequestChatHistoryToDisplay;
	}

	void RequestChatHistoryToDisplay()
	{

	}
}
