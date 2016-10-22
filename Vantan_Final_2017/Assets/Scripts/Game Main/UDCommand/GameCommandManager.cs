using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class GameCommandManager : MonoBehaviour {

  [SerializeField]
  private GameObject firstCommand = null;
  [SerializeField]
  private GameObject secondCommand = null;
  [SerializeField]
  private GameObject thirdCommand = null;
  [SerializeField]
  private GameObject fourthCommand = null;
  [SerializeField]
  private GameObject fifthCommand = null;

  private List<ImageType> images;
  private List<GameObject> commandObjects;

  private int previousFrameCommand = -1;
  private int currentCommand = 0;

  private float waitTime;

  void Start () {
    images = new List<ImageType>();
    commandObjects = new List<GameObject>();
    commandObjects.Add(firstCommand);
    commandObjects.Add(secondCommand);
    commandObjects.Add(thirdCommand);
    commandObjects.Add(fourthCommand);
    commandObjects.Add(fifthCommand);
  }
	
	void Update () {
    UpdateCommandIcons(currentCommand);
    previousFrameCommand = currentCommand;
    if(waitTime >= 2.0f) {
      waitTime = 0.0f;
      currentCommand++;
      if(currentCommand > 4) {
        currentCommand = 0;
      }
    }
    waitTime += Time.deltaTime;
	}

  private void UpdateCommandIcons(int currentCommand) {
    if (previousFrameCommand == currentCommand) return;
    Debug.Log(currentCommand);
    for(int i = 0; i < commandObjects.Count; i++) {
      if(i == currentCommand) {
        commandObjects[i].GetComponent<RescaleByState>().currentState = CommandState.Highlighted;
      }
      else {
        commandObjects[i].GetComponent<RescaleByState>().currentState = CommandState.Neutral;
      }
    }
  }

  Sprite ImageTypeToSprite(ImageType imageType) {
    string path = "";
    switch (imageType) {
      case ImageType.Left:
        path = "Sprites/leftArrow";
        break;
      case ImageType.Down:
        path = "Sprites/downArrow";
        break;
      case ImageType.Right:
        path = "Sprites/rightArrow";
        break;
      case ImageType.Up:
        path = "Sprites/upArrow";
        break;

      case ImageType.Square:
        path = "Sprites/square";
        break;
      case ImageType.Cross:
        path = "Sprites/cross";
        break;
      case ImageType.Circle:
        path = "Sprites/circle";
        break;
      case ImageType.Triangle:
        path = "Sprites/triangle";
        break;
    }

    return Resources.Load<Sprite>(path);
  }
}
