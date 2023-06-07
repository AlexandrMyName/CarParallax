using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Inventory
{
    internal interface IItem 
    {
        string Id { get; }
        ItemInfo Info { get; }
    }
}
