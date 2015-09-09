using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatPanel : MonoBehaviour
{
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
		Player.LoggedIn += RequestChatHistoryToDisplay;
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
		float scaleToTopY = Screen.height/ background.rectTransform.rect.size.y;
		LeanTween.scaleY(this.gameObject, scaleToTopY, 1.0f);
		scaleState = ScaleState.Expand;
	}

	void Shrink()
	{
		LeanTween.scaleY(this.gameObject, originalScale.y, 1.0f);
		scaleState = ScaleState.Shrink;
	}

	void RequestChatHistoryToDisplay()
	{

	}
}
