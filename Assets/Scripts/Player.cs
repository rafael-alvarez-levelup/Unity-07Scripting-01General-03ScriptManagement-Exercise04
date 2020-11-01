using UnityEngine;

/// <summary>
/// The <c>Player</c> class.
/// Contains fields for the player name and the player ID.
/// </summary>
/// <remarks>
/// Provides access to get the player name and the player ID.
/// </remarks>
public class Player : MonoBehaviour
{
    /// <value>
    /// Gets the player name.
    /// </value>
    public string Name { get; private set; }

    /// <value>
    /// Gets the the player ID.
    /// </value>
    public int Id { get; private set; }
}