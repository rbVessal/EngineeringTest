using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatBackgroundPanel : MonoBehaviour
{
	public delegate void MoveToTopStartAction();
	public static event MoveToTopStartAction MoveToTopStart;

	public delegate void MoveToTopCompleteAction();
	public static event MoveToTopCompleteAction MoveToTopComplete;

	public delegate void MoveToOriginalPosStartAction();
	public static event MoveToOriginalPosStartAction MoveToOriginalPosStart;

	const float TOP_SPACING = 10.0f;

	enum MoveState
	{
		Top,
		Original
	};
	private Vector2 originalPosition;
	private Image background;
	private Image messageBoxImage;
	private MoveState moveState;

	// Use this for initialization
	void Start()
	{
		background = GetComponent<Image>();
		originalPosition = background.rectTransform.position;
		moveState = MoveState.Original;
		//Scale to fit when moved up to the top
		ScaleToFit();
		GetComponent<Button>().onClick.AddListener(Move);
	}

	void Move()
	{
		switch(moveState)
		{
			case MoveState.Top:
			{
				MoveDown();
				break;
			}
			case MoveState.Original:
			{
				MoveUp();
				break;
			}
			default:
			{
				break;
			}
		}
	}

	void ScaleToFit()
	{
		//Calculate how much we should scale the chat panel to have it reach the top
		//of the screen
		//Calculate the message box segment to subtract from the scale to top
		//so that the chat panel scales up to the bottom of the message box
		Image messageBoxImage;
		FindMessageBoxImage(out messageBoxImage);
		//Get the canvas and use its recttransform height to determine the screen height
		GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
		RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();

		float scaleToTopY = canvasRectTransform.sizeDelta.y - messageBoxImage.rectTransform.sizeDelta.y;
		background.rectTransform.sizeDelta = new Vector2(background.rectTransform.sizeDelta.x,
		                                                  scaleToTopY);
		//Also set the height of the scroll view to be the same as the chat background panel
		//so that the content becomes scrollable and fits the size of the chat background panel
		GameObject scrollViewGameObject = gameObject.transform.FindChild("ScrollView").gameObject;
		scrollViewGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollViewGameObject.GetComponent<RectTransform>().sizeDelta.x,
		                                                                           scaleToTopY);
	}

	void FindMessageBoxImage(out Image messageBoxImage)
	{
		GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
		GameObject messageBox = canvas.transform.FindChild("MessageBox").gameObject;
		messageBoxImage = messageBox.GetComponent<Image>();
	}

	void MoveUp()
	{
		Image messageBoxImage;
		FindMessageBoxImage(out messageBoxImage);

		LTDescr moveUpTween = LeanTween.moveY(this.gameObject, 
							  messageBoxImage.rectTransform.position.y - (messageBoxImage.rectTransform.sizeDelta.y * 2.0f),
                              0.5f);
		moveUpTween.setOnStart(MoveToTopStarted);
		moveUpTween.setOnComplete(MoveToTopCompleted);

		moveState = MoveState.Top;
	}

	void MoveDown()
	{
		LTDescr moveDownTween = LeanTween.moveY(this.gameObject, 
				                originalPosition.y,
                                0.5f);
		moveDownTween.setOnStart(MoveToOriginalPosStarted);

		moveState = MoveState.Original;
	}
	
	void MoveToTopStarted()
	{
		ChatBackgroundPanel.MoveToTopStart();
	}

	void MoveToTopCompleted()
	{
		ChatBackgroundPanel.MoveToTopComplete();
	}
	
	void MoveToOriginalPosStarted()
	{
		ChatBackgroundPanel.MoveToOriginalPosStart();
	}
}
