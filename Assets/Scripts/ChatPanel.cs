using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChatPanel : MonoBehaviour 
{
	private GameObject chatMessagePanel;
	// Use this for initialization
	void Start () 
	{
		chatMessagePanel = Resources.Load("Prefabs/MessagePanel") as GameObject;
		AmericanaChatClient.ReceivedMessage += ReceivedMessage;
		AmericanaChatClient.ChatHistory += DisplayChatHistory;
	}

	void DisplayChatHistory(List<string>senders, List<object>messages)
	{
		for(int i = 0; i < senders.Count; i++)
		{
			string sender = senders[i];
			string message = messages[i] as string;
			CreateMessagePanel(sender, message);
		}
	}

	void ReceivedMessage(string sender, string message)
	{
		CreateMessagePanel(sender, message);
	}

	void CreateMessagePanel(string sender, string message)
	{
		GameObject chatMessagePanelClone = Instantiate(chatMessagePanel) as GameObject;
		//Set the parent of the message panel to the chat panel that acts as the content panel
		//for chat
		chatMessagePanelClone.transform.SetParent(this.gameObject.transform, false);
		MessagePanel messagePanel = chatMessagePanelClone.GetComponent<MessagePanel>();
		messagePanel.SetupWithSenderAndText(sender, message);


	}
}
