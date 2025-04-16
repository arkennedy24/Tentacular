using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName ="Gavin/Pause Manager")]
public class PauseManager : ScriptableObject
{
	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}	
}
