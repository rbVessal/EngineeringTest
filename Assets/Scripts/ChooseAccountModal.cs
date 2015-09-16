using UnityEngine;
using System.Collections;

public class ChooseAccountModal : MonoBehaviour 
{
	void Start()
	{
		GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
		RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
		LeanTween.moveY(this.gameObject, 
		                (canvasRectTransform.sizeDelta.y/2) + (this.GetComponent<RectTransform>().sizeDelta.y), 
		                0.7f);
	}

	void ToggleVisibility()
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
		ToggleVisibility();
	}
}
