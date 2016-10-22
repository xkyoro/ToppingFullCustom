using System.Collections.Generic;

public struct GamepadInput {
  private DirectionalInputs _dirInput;

  public DirectionalInputs dirInput {
    get { return _dirInput; }
    set { _dirInput = value; }
  }

  private List<ActionInputs> _actInputs;

  public List<ActionInputs> actInputs {
    get { return _actInputs; }
    set { _actInputs = value; }
  }
}

public enum DirectionalInputs {
  Neutral,
  Up,
  UpLeft,
  Left,
  DownLeft,
  Down,
  DownRight,
  Right,
  UpRight
}

public enum ActionInputs {
  ActUp,
  ActLeft,
  ActDown,
  ActRight
}