using UnityEngine;
using System.Collections.Generic;
using ExitGames.Client.Photon.Chat; //Import this inorder to use PhotoChat API
using UnityEngine.UI;

public class AmericanaChatClient : MonoBehaviour, IChatClientListener
{
	public delegate void ReceivedMessageAction(string sender, string message);
	public static event ReceivedMessageAction ReceivedMessage;

	public delegate void ChatHistoryAction(List<string>senders, List<object>messages);
	public static event ChatHistoryAction ChatHistory;

	private ChatClient chatClient;
	const string APP_ID = "34ec6cd9-6860-4767-bcc6-56311304bbda";
	const string PUBLIC_CHANNEL_NAME = "PublicChannel";
	// Use this for initialization
	void Start () 
	{
		chatClient = new ChatClient(this);
		Player.LoggedIn += ConnectPlayer;
	}

	void ConnectPlayer()
	{
		chatClient.Connect(APP_ID, "1.0", new AuthenticationValues(Player.UserName()));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Player.IsLoggedIn())
		{
			//Call this to keep the connection alive and get incoming messages
			chatClient.Service();
		}

		//If the player has hit the return or enter key,
		//then grab the text from the text field and display it in the chat
		if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
		{
			GameObject messageBox = GameObject.FindGameObjectWithTag("MessageBox");
			if(messageBox)
			{
				InputField messageInputField = messageBox.GetComponent<InputField>() as InputField;
				chatClient.PublishMessage(PUBLIC_CHANNEL_NAME, messageInputField.text);
				messageInputField.text = "";
			}
		}
	}

	//Protocols that must be implemented as established by IChatClientListener

	/// <summary>
	/// Client is connected now.
	/// </summary>
	/// <remarks>Clients have to be connected before they can send their state, subscribe to channels and send any messages.</remarks>
	public void OnConnected()
	{
		//Pass in -1 as the second parameter to get all of the chat history
		chatClient.Subscribe(new string[]{PUBLIC_CHANNEL_NAME}, -1);
	}

	//Debug info from the library
	public void DebugReturn(ExitGames.Client.Photon.DebugLevel level, string message)
	{

	}

	public void OnDisconnected()
	{

	}

	public void OnChatStateChange(ChatState state)
	{

	}

	public void OnGetMessages(string channelName, string[] senders, object[] messages)
	{
		//Since there is only a public channel, just simply get the first message and 
		//sender and display them
		if(channelName.Equals(PUBLIC_CHANNEL_NAME))
		{
			string sender = senders[0];
			string message = messages[0] as string;
			if(!message.Equals(""))
			{
				AmericanaChatClient.ReceivedMessage(sender, message);
			}
		}

	}

	public void OnPrivateMessage(string sender, object message, string channelName)
	{

	}

	public void OnSubscribed(string[] channels, bool[] results)
	{
		ChatChannel publicChatChannel;
		chatClient.TryGetChannel(PUBLIC_CHANNEL_NAME, out publicChatChannel);
		AmericanaChatClient.ChatHistory(publicChatChannel.Senders, publicChatChannel.Messages);
	}

	public void OnUnsubscribed(string[] channels)
	{

	}

	public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
	{

	}

	// To avoid that the Editor becomes unresponsive, disconnect all Photon connections in OnApplicationQuit.
	public void OnApplicationQuit()
	{
		if (chatClient != null)
		{
			chatClient.Disconnect();
		}
	}
}
