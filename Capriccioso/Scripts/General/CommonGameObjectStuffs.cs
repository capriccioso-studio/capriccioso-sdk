using System;
using UnityEngine;

/// <summary>
/// Class that has common methods usually related to player, enemy, NPC stuffs like taking damage, dying, etc
/// </summary>
public class CommonGameObjectStuffs : MonoBehaviour
{
    public event Action OnDamageTaken = delegate { };
    public event Action OnDie = delegate { };


    /// <summary>
    /// Ouch! Hahaha
    /// </summary>
    public void TakeDamage()
    {
        OnDamageTaken();
    }

    /// <summary>
    /// Adds a method to be invoked when damage is taken (subscribed to the OnDamageTaken event).
    /// </summary>
    /// <param name="onDamageTakenMethod">The method to be invoked when damage is taken.</param>
    public void AddOnDamageTakenMethod(Action onDamageTakenMethod)
    {
        OnDamageTaken += onDamageTakenMethod;
    }

    /// <summary>
    /// GameObject go bye bye!
    /// </summary>
    public void Die()
    {
        OnDie();
    }

    /// <summary>
    /// Adds a method to be invoked when the game object dies (subscribed to the OnDie event).
    /// </summary>
    /// <param name="onDeathMethod">The method to be invoked when the game object dies.</param>
    public void AddOnDeathMethod(Action onDeathMethod)
    {
        OnDie += onDeathMethod;
    }
}
