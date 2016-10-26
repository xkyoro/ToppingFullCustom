
namespace ToppingFullCustom {
  public enum InputType {
    Neutral,
    Left,
    Down,
    Right,
    Up,
    Square,
    Cross,
    Circle,
    Triangle
  }

  public enum DirectionalInputs {
    Neutral,
    Left,
    Down,
    Right,
    Up
  }

  public enum ActionInputs {
    Neutral,
    Square,
    Cross,
    Circle,
    Triangle
  }

  public class Utility {
    public static InputType DirectionalToInputType(DirectionalInputs dirInput) {
      var dirInt = (int)dirInput;
      return (InputType)dirInt;
    }

    public static InputType ActionToInputType(ActionInputs actInput) {
      var actInt = (int)actInput;
      if (actInput != ActionInputs.Neutral) {
        return (InputType)actInt + 4;
      }
      return InputType.Neutral;
    }
  }
}