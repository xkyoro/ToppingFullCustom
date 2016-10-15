using UnityEngine;
using System.Collections;

public class InputChecker : MonoBehaviour {

  [SerializeField]
  private GameObject DirUp = null;
  [SerializeField]
  private GameObject DirLeft = null;
  [SerializeField]
  private GameObject DirDown = null;
  [SerializeField]
  private GameObject DirRight = null;

  [SerializeField]
  private GameObject ActUp = null;
  [SerializeField]
  private GameObject ActLeft = null;
  [SerializeField]
  private GameObject ActDown = null;
  [SerializeField]
  private GameObject ActRight = null;

  void Update() {
    UpdateActionInputs();
    UpdateDirectionInputs();
  }

  private void UpdateActionInputs() {
    if (Input.GetAxis("PS4AX") >= 1.0f) {
      ActRight.GetComponent<Renderer>().material.color = Color.red;
      ActLeft.GetComponent<Renderer>().material.color = Color.white;
    }
    else if (Input.GetAxis("PS4AX") <= -1.0f) {
      ActRight.GetComponent<Renderer>().material.color = Color.white;
      ActLeft.GetComponent<Renderer>().material.color = Color.red;
    }
    else {
      ActRight.GetComponent<Renderer>().material.color = Color.white;
      ActLeft.GetComponent<Renderer>().material.color = Color.white;
    }

    if (Input.GetAxis("PS4AY") >= 1.0f) {
      ActUp.GetComponent<Renderer>().material.color = Color.red;
      ActDown.GetComponent<Renderer>().material.color = Color.white;
    }
    else if (Input.GetAxis("PS4AY") <= -1.0f) {
      ActUp.GetComponent<Renderer>().material.color = Color.white;
      ActDown.GetComponent<Renderer>().material.color = Color.red;
    }
    else {
      ActUp.GetComponent<Renderer>().material.color = Color.white;
      ActDown.GetComponent<Renderer>().material.color = Color.white;
    }
  }

  private void UpdateDirectionInputs() {
    if (Input.GetAxis("PS4LX") >= 1.0f || Input.GetAxis("PS4DX") >= 1.0f) {
      DirRight.GetComponent<Renderer>().material.color = Color.red;
      DirLeft.GetComponent<Renderer>().material.color = Color.white;
    }
    else if (Input.GetAxis("PS4LX") <= -1.0f || Input.GetAxis("PS4DX") <= -1.0f) {
      DirRight.GetComponent<Renderer>().material.color = Color.white;
      DirLeft.GetComponent<Renderer>().material.color = Color.red;
    }
    else {
      DirRight.GetComponent<Renderer>().material.color = Color.white;
      DirLeft.GetComponent<Renderer>().material.color = Color.white;
    }

    if (Input.GetAxis("PS4LY") >= 1.0f || Input.GetAxis("PS4DY") >= 1.0f) {
      DirUp.GetComponent<Renderer>().material.color = Color.red;
      DirDown.GetComponent<Renderer>().material.color = Color.white;
    }
    else if (Input.GetAxis("PS4LY") <= -1.0f || Input.GetAxis("PS4DY") <= -1.0f) {
      DirUp.GetComponent<Renderer>().material.color = Color.white;
      DirDown.GetComponent<Renderer>().material.color = Color.red;
    }
    else {
      DirUp.GetComponent<Renderer>().material.color = Color.white;
      DirDown.GetComponent<Renderer>().material.color = Color.white;
    }
  }
}
