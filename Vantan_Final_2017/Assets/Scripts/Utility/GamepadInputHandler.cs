using UnityEngine;
using System.Collections.Generic;
using TFC = ToppingFullCustom;

namespace ToppingFullCustom {
  public class GamepadInputHandler : MonoBehaviour {
    public static List<InputType> GetInputs() {
      List<InputType> inputs = new List<InputType>();
      GetDirectionalInputs(inputs);
      GetActionInputs(inputs);

      return inputs;
    }

    private static void GetActionInputs(List<InputType> inputs) {
      ActionInputs actInput = ActionInputs.Neutral;

      if (Input.GetAxis("PS4Square") >= 0.5f) {
        actInput = ActionInputs.Square;
        inputs.Add(TFC.Utility.ActionToInputType(actInput));
      }

      if (Input.GetAxis("PS4Cross") >= 0.5f) {
        actInput = ActionInputs.Cross;
        inputs.Add(TFC.Utility.ActionToInputType(actInput));
      }

      if (Input.GetAxis("PS4Circle") >= 0.5f) {
        actInput = ActionInputs.Circle;
        inputs.Add(TFC.Utility.ActionToInputType(actInput));
      }

      if (Input.GetAxis("PS4Triangle") >= 0.5f) {
        actInput = ActionInputs.Triangle;
        inputs.Add(TFC.Utility.ActionToInputType(actInput));
      }
    }

    private static void GetDirectionalInputs(List<InputType> inputs) {
      DirectionalInputs horInput;
      DirectionalInputs vertInput;

      if ((Input.GetAxis("PS4LX") >= 0.5f) || (Input.GetAxis("PS4DX") >= 0.5f)) {
        horInput = DirectionalInputs.Right;
      }
      else if ((Input.GetAxis("PS4LX") <= -0.5f) || (Input.GetAxis("PS4DX") <= -0.5f)) {
        horInput = DirectionalInputs.Left;
      }
      else {
        horInput = DirectionalInputs.Neutral;
      }

      if ((Input.GetAxis("PS4LY") >= 0.5f) || (Input.GetAxis("PS4DY") >= 0.5f)) {
        vertInput = DirectionalInputs.Up;
      }
      else if ((Input.GetAxis("PS4LY") <= -0.5f) || (Input.GetAxis("PS4DY") <= -0.5f)) {
        vertInput = DirectionalInputs.Down;
      }
      else {
        vertInput = DirectionalInputs.Neutral;
      }

      if (horInput != DirectionalInputs.Neutral) {
        inputs.Add(TFC.Utility.DirectionalToInputType(horInput));
      }

      if (vertInput != DirectionalInputs.Neutral) {
        inputs.Add(TFC.Utility.DirectionalToInputType(vertInput));
      }
    }
  }
}