using UnityEngine;
using System.Collections.Generic;

public class DebugGamepadInputHandler : MonoBehaviour {

  DebugGamepadInput gamepadInput;

  private void Start() {
    gamepadInput.actInputs = new List<DebugActionInputs>();
    gamepadInput.dirInput = DebugDirectionalInputs.Neutral;
  }

  private void GetActionInputs() {
    gamepadInput.actInputs.Clear();
    if (Input.GetAxis("PS4Square") == 1.0f) {
      gamepadInput.actInputs.Add(DebugActionInputs.ActLeft);
    }
    if (Input.GetAxis("PS4Cross") == 1.0f) {
      gamepadInput.actInputs.Add(DebugActionInputs.ActDown);
    }
    if (Input.GetAxis("PS4Circle") == 1.0f) {
      gamepadInput.actInputs.Add(DebugActionInputs.ActRight);
    }
    if (Input.GetAxis("PS4Triangle") == 1.0f) {
      gamepadInput.actInputs.Add(DebugActionInputs.ActUp);
    }
  }

  private void GetDirectionInputs() {
    DebugDirectionalInputs horizontalInput = DebugDirectionalInputs.Neutral;
    DebugDirectionalInputs verticalInput = DebugDirectionalInputs.Neutral;

    if (Input.GetAxis("PS4LX") >= 1.0f || Input.GetAxis("PS4DX") >= 1.0f) {
      horizontalInput = DebugDirectionalInputs.Right;
    }
    else if (Input.GetAxis("PS4LX") <= -1.0f || Input.GetAxis("PS4DX") <= -1.0f) {
      horizontalInput = DebugDirectionalInputs.Left;
    }
    else {
      horizontalInput = DebugDirectionalInputs.Neutral;
    }

    if (Input.GetAxis("PS4LY") >= 1.0f || Input.GetAxis("PS4DY") >= 1.0f) {
      verticalInput = DebugDirectionalInputs.Up;
    }
    else if (Input.GetAxis("PS4LY") <= -1.0f || Input.GetAxis("PS4DY") <= -1.0f) {
      verticalInput = DebugDirectionalInputs.Down;
    }
    else {
      verticalInput = DebugDirectionalInputs.Neutral;
    }

    MixDirectionalInputs(horizontalInput, verticalInput);
  }

  private void MixDirectionalInputs(DebugDirectionalInputs horizontalInput, DebugDirectionalInputs verticalInput) {
    if (horizontalInput == DebugDirectionalInputs.Neutral) {
      gamepadInput.dirInput = verticalInput;
    }
    else if (horizontalInput == DebugDirectionalInputs.Left) {
      if (verticalInput == DebugDirectionalInputs.Neutral) {
        gamepadInput.dirInput = horizontalInput;
      }
      else if (verticalInput == DebugDirectionalInputs.Up) {
        gamepadInput.dirInput = DebugDirectionalInputs.UpLeft;
      }
      else {
        gamepadInput.dirInput = DebugDirectionalInputs.DownLeft;
      }
    }
    else {
      if (verticalInput == DebugDirectionalInputs.Neutral) {
        gamepadInput.dirInput = horizontalInput;
      }
      else if (verticalInput == DebugDirectionalInputs.Up) {
        gamepadInput.dirInput = DebugDirectionalInputs.UpRight;
      }
      else {
        gamepadInput.dirInput = DebugDirectionalInputs.DownRight;
      }
    }
  }

  public DebugGamepadInput GetInputs() {
    GetActionInputs();
    GetDirectionInputs();
    return gamepadInput;
  }
}
