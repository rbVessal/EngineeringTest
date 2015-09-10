using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		ChatBackgroundPanel.MoveToTopComplete += ToggleVisibility;
		ChatBackgroundPanel.MoveToOriginalPosStart += ToggleVisibility;
		this.gameObject.SetActive(false);	
	}

	void ToggleVisibility()
	{
		if(this.gameObject.activeSelf)
		{
			this.gameObject.SetActive(false);
		}
		else
		{
			this.gameObject.SetActive(true);
		}
	}
}
