using UnityEngine;
using Unity = UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UDC = UDCommand;
using TFC = ToppingFullCustom;

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

  private List<UDC.ImageType> images;
  private List<GameObject> commandObjects;
  private List<TFC.InputType> inputList;

  [SerializeField]
  private UDC.Dificulty dificulty;

  private int previousFrameCommand = -1;
  private int currentCommand = 0;

  private TFC.InputType lockedCommand;
  private bool resetedToNeutral;

  private float waitTime;

  void Start () {
    images = new List<UDC.ImageType>();
    commandObjects = new List<GameObject>();
    inputList = new List<TFC.InputType>();
    commandObjects.Add(firstCommand);
    commandObjects.Add(secondCommand);
    commandObjects.Add(thirdCommand);
    commandObjects.Add(fourthCommand);
    commandObjects.Add(fifthCommand);
  }
	
	void Update () {
    if (currentCommand == 0 && (currentCommand != previousFrameCommand)) {
      GenerateRandomCommands();
    }
    UpdateCommandIcons(currentCommand);
    previousFrameCommand = currentCommand;
    CheckGamepadInput();
    ResetCurrentCommand();
	}

  private void GenerateRandomCommands() {
    SetSpritesByDificulty();
    images.Clear();
    inputList.Clear();
    for(var i = 0; i < DificultyToQtt(); i++) {
      images.Add((UDC.ImageType)Unity.Random.Range(0, 8));
    }

    for(var i = 0; i < images.Count; i++) {
      commandObjects[i].GetComponent<Image>().sprite = ImageTypeToSprite(images[i]);
    }

    foreach(var img in images) {
      inputList.Add(ImageTypeToInputType(img));
    }
  }

  private void SetSpritesByDificulty() {
    foreach(var obj in commandObjects) {
      obj.SetActive(false);
    }

    for(int i = 0; i < DificultyToQtt(); i++) {
      commandObjects[i].SetActive(true);
    }
  }

  private int DificultyToQtt() {
    int res = 3;
    switch (dificulty) {
      case UDC.Dificulty.Easy:
        res = 3;
        break;
      case UDC.Dificulty.Medium:
        res = 4;
        break;
      case UDC.Dificulty.Hard:
        res = 5;
        break;
    }

    return res;
  }

  private void CheckGamepadInput() {
    var inputs = TFC.GamepadInputHandler.GetInputs();
    if (resetedToNeutral) {
      if (inputs.Contains(inputList[currentCommand])) {
        lockedCommand = inputList[currentCommand];
        resetedToNeutral = false;
        currentCommand++;
      }
    }
    else {
      if(!inputs.Contains(lockedCommand)) {
        resetedToNeutral = true;
      }
    }
  }

  private void ResetCurrentCommand() {
    if(currentCommand >= DificultyToQtt()) {
      currentCommand = 0;
    }
  }

  private void UpdateCommandIcons(int currentCommand) {
    if (previousFrameCommand == currentCommand) return;
    for(int i = 0; i < commandObjects.Count; i++) {
      if(i == currentCommand) {
        commandObjects[i].GetComponent<UDC.RescaleByState>().currentState = UDC.CommandState.Highlighted;
      }
      else {
        commandObjects[i].GetComponent<UDC.RescaleByState>().currentState = UDC.CommandState.Neutral;
      }
    }
  }

  private Sprite ImageTypeToSprite(UDC.ImageType imageType) {
    string path = "";
    switch (imageType) {
      case UDC.ImageType.Left:
        path = "Sprites/UDCommand/leftArrow";
        break;
      case UDC.ImageType.Down:
        path = "Sprites/UDCommand/downArrow";
        break;
      case UDC.ImageType.Right:
        path = "Sprites/UDCommand/rightArrow";
        break;
      case UDC.ImageType.Up:
        path = "Sprites/UDCommand/upArrow";
        break;

      case UDC.ImageType.Square:
        path = "Sprites/UDCommand/square";
        break;
      case UDC.ImageType.Cross:
        path = "Sprites/UDCommand/cross";
        break;
      case UDC.ImageType.Circle:
        path = "Sprites/UDCommand/circle";
        break;
      case UDC.ImageType.Triangle:
        path = "Sprites/UDCommand/triangle";
        break;
    }

    return Resources.Load<Sprite>(path);
  }

  private TFC.InputType ImageTypeToInputType(UDC.ImageType imageType) {
    return (TFC.InputType)imageType + 1;
  }
}
