using UnityEngine;
using System.Collections;

public class MessageBox : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		ChatBackgroundPanel.ScaleExpansionComplete += ToggleVisibility;
		ChatBackgroundPanel.ScaleShrinkStart += ToggleVisibility;
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
