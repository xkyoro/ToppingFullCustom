using UnityEngine;
using System.Collections.Generic;

public class GamepadInputHandler : MonoBehaviour {

  GamepadInput gamePadInput;

  private void Start() {
    gamePadInput.actInputs = new List<ActionInputs>();
    gamePadInput.dirInput = DirectionalInputs.Neutral;
  }

  private void GetActionInputs() {
    gamePadInput.actInputs.Clear();
    if (Input.GetAxis("PS4Square") == 1.0f) {
      gamePadInput.actInputs.Add(ActionInputs.ActLeft);
    }
    if (Input.GetAxis("PS4Cross") == 1.0f) {
      gamePadInput.actInputs.Add(ActionInputs.ActDown);
    }
    if (Input.GetAxis("PS4Circle") == 1.0f) {
      gamePadInput.actInputs.Add(ActionInputs.ActRight);
    }
    if (Input.GetAxis("PS4Triangle") == 1.0f) {
      gamePadInput.actInputs.Add(ActionInputs.ActUp);
    }
  }

  private void GetDirectionInputs() {
    DirectionalInputs horizontalInput = DirectionalInputs.Neutral;
    DirectionalInputs verticalInput = DirectionalInputs.Neutral;

    if (Input.GetAxis("PS4LX") >= 1.0f || Input.GetAxis("PS4DX") >= 1.0f) {
      horizontalInput = DirectionalInputs.Right;
    }
    else if (Input.GetAxis("PS4LX") <= -1.0f || Input.GetAxis("PS4DX") <= -1.0f) {
      horizontalInput = DirectionalInputs.Left;
    }
    else {
      horizontalInput = DirectionalInputs.Neutral;
    }

    if (Input.GetAxis("PS4LY") >= 1.0f || Input.GetAxis("PS4DY") >= 1.0f) {
      verticalInput = DirectionalInputs.Up;
    }
    else if (Input.GetAxis("PS4LY") <= -1.0f || Input.GetAxis("PS4DY") <= -1.0f) {
      verticalInput = DirectionalInputs.Down;
    }
    else {
      verticalInput = DirectionalInputs.Neutral;
    }

    MixDirectionalInputs(horizontalInput, verticalInput);
  }

  private void MixDirectionalInputs(DirectionalInputs horizontalInput, DirectionalInputs verticalInput) {
    if (horizontalInput == DirectionalInputs.Neutral) {
      gamePadInput.dirInput = verticalInput;
    }
    else if (horizontalInput == DirectionalInputs.Left) {
      if (verticalInput == DirectionalInputs.Neutral) {
        gamePadInput.dirInput = horizontalInput;
      }
      else if (verticalInput == DirectionalInputs.Up) {
        gamePadInput.dirInput = DirectionalInputs.UpLeft;
      }
      else {
        gamePadInput.dirInput = DirectionalInputs.DownLeft;
      }
    }
    else {
      if (verticalInput == DirectionalInputs.Neutral) {
        gamePadInput.dirInput = horizontalInput;
      }
      else if (verticalInput == DirectionalInputs.Up) {
        gamePadInput.dirInput = DirectionalInputs.UpRight;
      }
      else {
        gamePadInput.dirInput = DirectionalInputs.DownRight;
      }
    }
  }

  public GamepadInput GetInputs() {
    GetActionInputs();
    GetDirectionInputs();
    return gamePadInput;
  }
}
