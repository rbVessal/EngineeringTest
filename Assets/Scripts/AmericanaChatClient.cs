﻿using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon.Chat; //Import this inorder to use PhotoChat API

public class AmericanaChatClient : MonoBehaviour, IChatClientListener
{
	private ChatClient chatClient;
	const string APP_ID = "34ec6cd9-6860-4767-bcc6-56311304bbda";
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

		}
	}

	//Protocols that must be implemented as established by IChatClientListener

	/// <summary>
	/// Client is connected now.
	/// </summary>
	/// <remarks>Clients have to be connected before they can send their state, subscribe to channels and send any messages.</remarks>
	public void OnConnected()
	{
		chatClient.Subscribe(new string[]{"PublicChannel"});
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

	}

	public void OnPrivateMessage(string sender, object message, string channelName)
	{

	}

	public void OnSubscribed(string[] channels, bool[] results)
	{

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
