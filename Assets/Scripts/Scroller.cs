using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public int speed = 10;	
		
    public int direction = -1;
	
	public bool isLooping = false;
	
	private List<Transform> backgroundParts;
	
	// 3 - Get all the children
	void Start()
	{
		// For infinite background only
		if (isLooping)
		{
			// Get all the children of the layer with a renderer
			backgroundParts = new List<Transform>();
			
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				
				// Add only the visible children
				if (child.GetComponent<Renderer>() != null)
				{
					backgroundParts.Add(child);
				}
			}
			
			// Sort by position.
			// Note: Get the children from left to right.
			// We would need to add a few conditions to handle
			// all the possible scrolling directions.
			backgroundParts = backgroundParts.OrderBy(
				t => t.position.x
				).ToList();
		}
	}
	
	void Update()
	{
		// Movement
		Vector3 movement = new Vector3(
			speed * direction,
			0,
			0);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);
		
		// 4 - Loop
		if (isLooping)
		{
			// Get the first object.
			// The list is ordered from left (x position) to right.
			Transform firstChild = backgroundParts.FirstOrDefault();
			
			if (firstChild != null)
			{
				// Check if the child is already (partly) before the camera.
				// We test the position first because the IsVisibleFrom
				// method is a bit heavier to execute.
				if (firstChild.position.x < (Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect))
				{
					// If the child is already on the left of the camera,
					// we test if it's completely outside and needs to be
					// recycled.
					if (firstChild.GetComponent<Renderer>().isVisible == false)
					{
						// Get the last child position.
						Transform lastChild = backgroundParts.LastOrDefault();
						Vector3 lastPosition = lastChild.transform.position;
						Vector3 lastSize = (lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min);
						
						// Set the position of the recyled one to be AFTER
						// the last child.
						firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);
						
						// Set the recycled child to the last position
						// of the backgroundPart list.
						backgroundParts.Remove(firstChild);
						backgroundParts.Add(firstChild);
					}
				}
			}
		}
	}
}