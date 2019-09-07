﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInteractable : MonoBehaviour {
	public abstract void OnHit(ControllerColliderHit hit, Player player);
}
