using UnityEngine;
using UnityEditor;

public class ResetObject : Editor {

	[MenuItem("GameObject/Reset Position To Origin %#0")] //x % is ctrl/command, # is shift
	static void Reset () {
		// if we have something selected
		if (Selection.activeGameObject != null) {
			// record an undo state on the transform before we change it so ctrl-z works
			Undo.RecordObject (Selection.activeGameObject.transform, "Moved to origin");
			Selection.activeGameObject.transform.position = Vector3.zero;
		}
	}
}