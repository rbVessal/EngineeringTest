using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour 
{
	public Image borderImage;
	// Use this for initialization
	void Start () 
	{
		ChatBackgroundPanel.MoveToTopComplete += ToggleVisibility;
		ChatBackgroundPanel.MoveToOriginalPosStart += ToggleVisibility;
		this.gameObject.SetActive(false);	
	}

	public void Selected()
	{
		borderImage.canvasRenderer.SetAlpha(1.0f);
	}

	public void Deselected()
	{
		borderImage.canvasRenderer.SetAlpha(0.0f);
	}

	void ToggleVisibility()
	{
		if(this.gameObject.activeSelf)
		{
			this.gameObject.SetActive(false);
			borderImage.canvasRenderer.SetAlpha(0.0f);
		}
		else
		{
			this.gameObject.SetActive(true);
			borderImage.canvasRenderer.SetAlpha(0.0f);
		}
	}
}
