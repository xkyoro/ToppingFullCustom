using UnityEngine;
using System.Collections;

public class RescaleByState : MonoBehaviour {

  [SerializeField]
  private Vector2 neutralScale = new Vector2(50,50);

  [SerializeField]
  private Vector2 highlightedScale = new Vector2(75,75);

  private CommandState _currentState;

  public CommandState currentState {
    get { return _currentState; }
    set { _currentState = value; }
  }

  void Update () {
	  if(currentState == CommandState.Neutral) {
      GetComponent<RectTransform>().sizeDelta = neutralScale;
    }
    else {
      GetComponent<RectTransform>().sizeDelta = highlightedScale;
    }
	}
}
