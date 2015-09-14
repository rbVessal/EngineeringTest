using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour 
{
	public delegate void SubmitedTextAction(string text);
	public static event SubmitedTextAction SubmitedTextEvent;
	public Image borderImage;
	// Use this for initialization
	void Start () 
	{
		ChatBackgroundPanel.MoveToTopComplete += ToggleVisibility;
		ChatBackgroundPanel.MoveToOriginalPosStart += ToggleVisibility;

		//OnSubmit method is currently broken,
		//so we need to use give the submit event
		//to onEndEdit to let it know to use the 
		//submit event instead of clicking away event
		InputField.SubmitEvent submitEvent = new InputField.SubmitEvent();
		submitEvent.AddListener(SubmittedText);
		InputField inputField = GetComponent<InputField>();
		inputField.onEndEdit = submitEvent;

		this.gameObject.SetActive(false);	
	}

	void SubmittedText(string text)
	{
		InputField inputField = GetComponent<InputField>();
		//Hack:apparently this allows for pressing done or return
		//to work properly on iPhone and iPad
		if(!Input.anyKeyDown)
		{
			MessageBox.SubmitedTextEvent(text);
			inputField.text = "";
		}
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
