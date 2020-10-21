using System;
using System.Collections.Generic;
using UnityEngine;

public class Comments : MonoBehaviour
{
    public event Action<Player> PlayerAdded = delegate { };

    public event Action<Player> PlayerRemoved = delegate { };

    private List<Player> _players;

    private void Awake()
    {
        _players = new List<Player>();
    }

    public Player GetPlayerById(int id)
    {
        return _players.Find(player => player.Id == id);
    }

    public void AddPlayer(Player player)
    {
        _players.Add(player);

        OnPlayerAdded(player);
    }

    public void RemovePlayer(Player player)
    {
        _players.Remove(player);

        OnPlayerRemoved(player);
    }

    public Vector3 GetPlayerPositionById(int id)
    {
        return GetPlayerById(id).transform.position;
    }

    public void OnPlayerAdded(Player player)
    {
        if(PlayerAdded != null)
        {
            PlayerAdded.Invoke(player);
        }
    }

    public void OnPlayerRemoved(Player player)
    {
        if (PlayerAdded != null)
        {
            PlayerRemoved.Invoke(player);
        }
    }
}
