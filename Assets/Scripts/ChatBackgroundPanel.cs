using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatBackgroundPanel : MonoBehaviour
{
	public delegate void ScaleExpansionCompleteAction();
	public static event ScaleExpansionCompleteAction ScaleExpansionComplete;
	public delegate void ScaleShrinkStartAction();
	public static event ScaleShrinkStartAction ScaleShrinkStart;

	enum ScaleState
	{
		Expand,
		Shrink
	};
	private Vector2 originalScale;
	private Image background;
	private ScaleState scaleState;

	// Use this for initialization
	void Start()
	{
		background = GetComponent<Image>();
		originalScale = background.rectTransform.localScale;
		scaleState = ScaleState.Shrink;
		GetComponent<Button>().onClick.AddListener(Scale);
	}

	void Scale()
	{
		switch(scaleState)
		{
			case ScaleState.Expand:
			{
				Shrink();
				break;
			}
			case ScaleState.Shrink:
			{
				Expand();
				break;
			}
			default:
			{
				break;
			}
		}
	}

	void Expand()
	{
		//Calculate how much we should scale the chat panel to have it reach the top
		//of the screen
		float scaleToTopY = Screen.height/background.rectTransform.rect.size.y;
		//Calculate the message box segment to subtract from the scale to top
		//so that the chat panel scales up to the bottom of the message box
		//31.0f is the height of the message box
		//TODO: get the height of the message box before it becomes inactive
		float messageBoxSegment = 1/(background.rectTransform.rect.size.y/31.0f);
		scaleToTopY -= messageBoxSegment;
		LeanTween.scaleY(this.gameObject, scaleToTopY, 0.2f).setOnComplete(ScaleExpansionCompleted);
		scaleState = ScaleState.Expand;
	}

	void Shrink()
	{
		LeanTween.scaleY(this.gameObject, originalScale.y, 0.2f).setOnStart(ScaleShrinkStarted);
		scaleState = ScaleState.Shrink;
	}

	void ScaleExpansionCompleted()
	{
		ChatBackgroundPanel.ScaleExpansionComplete();
	}
	
	void ScaleShrinkStarted()
	{
		ChatBackgroundPanel.ScaleShrinkStart();
	}
}
