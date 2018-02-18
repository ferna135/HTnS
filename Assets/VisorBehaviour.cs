﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisorBehaviour : MonoBehaviour {

	public Transform canvas;
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive (true);
			} else {
				canvas.gameObject.SetActive (false);
			}
		}
	}
}
