using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The <c>Comments</c> Class.
/// Contains a list of players and methods for performing transformations on that list.
/// <list type="bullet">
/// <item>
/// <term>AddPlayer</term>
/// </item>
/// <item>
/// <term>RemovePlayer</term>
/// </item>
/// </list>
/// </summary>
/// <remarks>
/// <para>This class can add an remove players from the players list.</para>
/// <para>It also cand get players by its position an by its ID.</para>
/// </remarks>
public class Comments : MonoBehaviour
{
    /// <summary>
    /// Declaration of an event that is invoked when a player is added to the players list.
    /// </summary>
    public event Action<Player> PlayerAdded = delegate { };

    /// <summary>
    /// Declaration of an event that is invoked when a player is removed from the players list.
    /// </summary>
    public event Action<Player> PlayerRemoved = delegate { };

    /// <summary>
    /// Declaration of the players list.
    /// </summary>
    private List<Player> _players;

    /// <summary>
    /// Unity Awake Method.
    /// </summary>
    /// <remarks>
    /// Initializes the players list to be empty.
    /// </remarks>
    private void Awake()
    {
        _players = new List<Player>();
    }

    /// <summary>
    /// Gets a player by his <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The Identification Number of the player.</param>
    /// <returns>
    /// The player.
    /// </returns>
    /// <example>
    /// <code>
    /// Player playerOne = GetPlayerById(0);
    /// playerOne.transform.position = Vector3.zero;
    /// </code>
    /// </example>
    /// <seealso cref="Comments.GetPlayerPositionById(int)"/>
    public Player GetPlayerById(int id)
    {
        return _players.Find(player => player.Id == id);
    }

    /// <summary>
    /// Adds a <paramref name="player"/> to the players list.
    /// </summary>
    /// <remarks>
    /// Calls the <c>OnPlayerAdded</c> method.
    /// </remarks>
    /// <param name="player">The <c>Player</c> class.</param>
    /// <example>
    /// <code>
    /// AddPlayer(playerOne);
    /// </code>
    /// </example>
    /// See <see cref="Comments.RemovePlayer(Player)"/> to remove players.
    public void AddPlayer(Player player)
    {
        _players.Add(player);

        OnPlayerAdded(player);
    }

    /// <summary>
    /// Removes a <paramref name="player"/> from the players list.
    /// </summary>
    /// <remarks>
    /// Calls the <c>OnPlayerRemoved</c> method.
    /// </remarks>
    /// <param name="player">The <c>Player</c> class.</param>
    /// <example>
    /// <code>
    /// RemovePlayer(playerOne);
    /// </code>
    /// </example>
    /// See <see cref="Comments.AddPlayer(Player)"/> to add players.
    public void RemovePlayer(Player player)
    {
        _players.Remove(player);

        OnPlayerRemoved(player);
    }

    /// <summary>
    /// Gets a player position by his <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The Identification number of the player.</param>
    /// <returns>
    /// The position of the player.
    /// </returns>
    /// <example>
    /// <code>
    /// Vector3 playerPosition = GetPlayerPositionById(1);
    /// </code>
    /// </example>
    /// <seealso cref="Comments.GetPlayerById(int)"/>
    public Vector3 GetPlayerPositionById(int id)
    {
        return GetPlayerById(id).transform.position;
    }

    /// <summary>
    /// Invokes the <c>PlayerAdded</c> event.
    /// </summary>
    /// <param name="player">The <c>Player</c> class.</param>
    /// <seealso cref="OnPlayerAdded(Player)"/>
    public void OnPlayerAdded(Player player)
    {
        if (PlayerAdded != null)
        {
            PlayerAdded.Invoke(player);
        }
    }

    /// <summary>
    /// Invokes the <c>PlayerRemoved</c> event.
    /// </summary>
    /// <param name="player">The <c>Player</c> class.</param>
    /// <seealso cref="Comments.OnPlayerAdded(Player)"/>
    public void OnPlayerRemoved(Player player)
    {
        if (PlayerAdded != null)
        {
            PlayerRemoved.Invoke(player);
        }
    }
}