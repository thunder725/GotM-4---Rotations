using UnityEngine;

public class EnemyShipsScript : MonoBehaviour
{

    [SerializeField] Vector3 rotateAroundPoint; // The point where the player is located, where they should rotate around
    public float movementSpeed, chosenDistance; 
    [SerializeField] float heightMultiplicator;
    [SerializeField] Vector2 MinMaxHeight; // The minimum and maximum height possible
    [SerializeField] Vector2 MinMaxDistance; // The minimum and maximum distance from the player possible
    
    //                    Something to setup the starting angle
    float startingHeight, startingAngleFromRight; 

    // ======================== [DEFAULT UNITY METHODS] ========================
    void Awake()
    {
        
    }

    void Start()
    {
        transform.position = SelectSpawnPosition();

        // We want them to look towards their rotation, so they'll have a transform.forward aligned with their rotation tangeant
        // The tangeant is obtained from here https://stackoverflow.com/questions/40710168/find-a-vector-tangent-to-a-circle

        Vector3 toCenter = Vector3.up * startingHeight - transform.position;
        Vector3 tangeant = new Vector3(-toCenter.z, 0, toCenter.x).normalized;

        transform.forward = tangeant;

        // Debug.Log("Ship spawned in " + transform.position + " which is exactly " + chosenDistance + " units away from the player");
        
    }

    void Update()
    {
        // Rotate around
        transform.RotateAround(rotateAroundPoint, Vector3.up, movementSpeed * Time.deltaTime);
        
        // Move upwards
        transform.position = new Vector3(transform.position.x, startingHeight + (Mathf.Cos(Time.time * chosenDistance / 20) * heightMultiplicator), transform.position.z);
    }

    // ======================== [SCRIPT METHODS] ========================

    public void GetShot()
    {

    }

    Vector3 SelectSpawnPosition()
    {
        /*
            Select a starting distance from the center of a sphere in (0,0,0) to facilitate calculations
            Select a starting height
            Reverse Engineer a point on the sphere with the matching height and distance

            Offset it by the player's position "rotateAroundPoint" so the sphere is centered on the player


            NOTE: Since the player's position has a height and this is the one thing we must have set for certain,
                we will substract PlayerPos.y from the startingheight to avoid any problem
        */

        chosenDistance = Random.Range(MinMaxDistance.x, MinMaxDistance.y); // This ship's distance to the player
        startingHeight = Random.Range(MinMaxHeight.x, MinMaxHeight.y) - rotateAroundPoint.y; // This ship's starting height - player's height


        // =================================================================================================
        // Select a point on a sphere centered on (0,0,0) of size chosenDistance which a y of startingHeight
        // =================================================================================================


        // First reverse engineer the elevation angle from the horizon (the plane Vector3.right, Vector3.forward)
        // If we draw the scene: the height (y value) is equal to the Sin of the angle * the distance, so we can get the angle

        // sin(a) * d = h   <=>  a = asin(h/d)

        float elevationAngle = Mathf.Asin(startingHeight/chosenDistance); // In radians

        /* 
            Then we'll use a "Spherical Coordinate System" (https://en.wikipedia.org/wiki/Spherical_coordinate_system) where every point needs only 3 values:
                - Distance from 0 (chosenDistance)
                - Angle from the Polar Axis (elevationAngle)
                            NOTE: We calculated the elevation angle from the horizontal plane to the point, not the Polar axis, it'll be important later
                - Angle from one axis defined as the base (for example, angle from Vector3.right)
        
            The last one only says if the ship will spawn in front or behind or on the sides of the player
            But for this game this is irrelevant, it doesn't matter where it spawns, so we'll use a random value
        */

        float angleFromRight = Random.Range(0, 2 * Mathf.PI); // Unsigned angle from Vector3.right ON the horizontal plane, in radians

        // With the Spherical Coordinate System, we can now create the point without any problem 
        // Thanks to https://en.wikipedia.org/wiki/Spherical_coordinate_system#Cartesian_coordinates
        
        // NOTE: Cartesian coordinates use Z as height, not Y, so we invert those two
        // NOTE 2: According to the article: "If θ measures elevation from the reference plane instead of inclination from the zenith the cos θ and sin θ below become switched"
                    // θ is our elevation angle

        var newPos = Vector3.zero;
        newPos.x = chosenDistance * Mathf.Cos(angleFromRight) * Mathf.Cos(elevationAngle);
        newPos.y = chosenDistance * Mathf.Sin(elevationAngle);
        newPos.z = chosenDistance * Mathf.Sin(angleFromRight) * Mathf.Cos(elevationAngle);



        // Then we offset it so that the center is the Player's Position and not the center of the world
        newPos += rotateAroundPoint;


        // Save the real starting height
        startingHeight += rotateAroundPoint.y;

        return newPos;
    }

    public float WhatsYourHeightIn(float time)
    {
        // What's this ship's height after *time* seconds has passed?
        // Used to smooth Ring One's after-shoot rotation

        // Height is calculated by 
            /// startingHeight + (Mathf.Cos(Time.time * chosenDistance / 20) * heightMultiplicator)

        float value = 0;

        // Offset by the time given
        value = startingHeight + (Mathf.Cos((Time.time + time)* chosenDistance / 20) * heightMultiplicator);

        return value;
    }

}
