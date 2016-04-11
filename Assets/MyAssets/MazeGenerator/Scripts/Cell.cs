
using UnityEngine;

[System.Serializable]
public class Cell
{
	public GameObject top;
	public GameObject bottom;
	public GameObject right;
	public GameObject left;

	public bool visited = false;
}
