using UnityEngine;
using System.Collections;

public class Checkpoint{

	public PuzzleInventory inventory;
	public GameObject player;
	public GameObject puzzle;
	public Vector2 position;
	public GameObject[] puzzlePieces;

	public PuzzleInventory inventory2;

	public Checkpoint(PuzzleInventory inventory, GameObject player, GameObject puzzle, Vector2 position, GameObject[] puzzlePieces)
	{
		//this.inventory2 = inventory.
		this.inventory = inventory;
		this.player = player;
		this.puzzle = puzzle;
		this.position = position;
		this.puzzlePieces = puzzlePieces;
	}
}
