using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatSetting : MonoBehaviour
{
    static PlayerStatSetting instance;
    public static PlayerStatSetting Instance => instance;

    bool isSave = false;

    [HideInInspector]
    public List<MagicCard> playerCardsDeck = new List<MagicCard>();

    [HideInInspector]
    public float health, maxHealth, mana, maxMana, healthRegen, manaRegen, moveSpeed;

    public bool IsSave=>isSave;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveStat(float health, float maxHealth, float mana, float maxMana, float healthRegen, float manaRegen, float moveSpeed)
    {
        this.health = health;
        this.maxHealth = maxHealth;
        this.mana = mana;
        this.maxMana = maxMana;
        this.healthRegen = healthRegen;
        this.manaRegen = manaRegen;
        this.moveSpeed = moveSpeed;
        
        isSave = true;
    }

    public void ResetStat()
    {
        isSave = false;


        playerCardsDeck.Clear();
    }

    

}
