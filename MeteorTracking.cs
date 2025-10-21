using UnityEngine;

public class MeteorTracking : MonoBehaviour
{
    public int meteorsDestroyed = 0;
    public int victoryThreshold = 10;

    public void verifyMeteorDestruction()
    {
        meteorsDestroyed++;

        if (meteorsDestroyed >= victoryThreshold)
        {
            Debug.Log("Meteor destroyed. Count: " + meteorsDestroyed + " on object: " + gameObject.name);
        }
    }

}
