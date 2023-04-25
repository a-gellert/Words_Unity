using System.Collections.Generic;
using System;

[Serializable]
public class SaveData
{
    public int savedLives;
    public int savedCoins;
    public List<bool> savedLevelState;
}
