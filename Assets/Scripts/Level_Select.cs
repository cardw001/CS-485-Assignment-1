﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Select : MonoBehaviour {

	public void sceneSelect(string level)
	{
		SceneManager.LoadScene(level);
	}
}
