using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatLeftModulePanel : MonoBehaviour 
{
	private Vector2 originalPosition;
	// Use this for initialization
	void Start () 
	{
		originalPosition = GetComponent<Image>().rectTransform.position;
		ChatBackgroundPanel.MoveToTopStart += SlideInToTarget;
		ChatBackgroundPanel.MoveToOriginalPosStart += SlideOut;
	}

	void SlideInToTarget()
	{
		LeanTween.moveX(this.gameObject, 
		                0.0f,
		                0.1f);
	}
	
	void SlideOut()
	{
		LeanTween.moveX (this.gameObject,
		                 originalPosition.x,
		                 0.1f);
	}
}
