using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class MessagePanel : MonoBehaviour 
{
	public Image badgeIconImage;
	public Text messageText;

	public void SetupWithSenderAndText(string sender, string text)
	{
		Sprite badgeIconSprite;
		AccountDatabase.GetAccountImageBasedOnUserName(ref sender, out badgeIconSprite);
		badgeIconImage.sprite = badgeIconSprite;

		messageText.text = text;

		//Rebuild the layout immediately to get the layout groups and content size fitters
		//to apply to this dynamically UI added element
		LayoutRebuilder.ForceRebuildLayoutImmediate(this.transform.parent as RectTransform);
	}
}
