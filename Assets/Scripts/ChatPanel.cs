using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatPanel : MonoBehaviour 
{
	private GameObject chatMessagePanel;
	// Use this for initialization
	void Start () 
	{
		chatMessagePanel = Resources.Load("Prefabs/MessagePanel") as GameObject;
		AmericanaChatClient.ReceivedMessage += ReceivedMessage;
	}

	void ReceivedMessage(string sender, string message)
	{
		GameObject chatMessagePanelClone = Instantiate(chatMessagePanel) as GameObject;
		Image[] images = chatMessagePanelClone.transform.GetComponentsInChildren<Image>();
		Image badgeIconImage = images[0];
		foreach(Image image in images)
		{
			if(image.transform.parent == chatMessagePanelClone.transform)
			{
				badgeIconImage = image;
			}
		}
		Sprite badgeIconSprite;
		AccountDatabase.GetAccountImageBasedOnUserName(ref sender, out badgeIconSprite);
		badgeIconImage.sprite = badgeIconSprite;
		Text userName = chatMessagePanelClone.GetComponentInChildren<Text>();
		userName.text = message;
		chatMessagePanelClone.transform.SetParent(this.transform);
	}
}
