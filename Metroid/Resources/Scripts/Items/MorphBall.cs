using System;
using Godot;

namespace Metroid.Resources.Scripts.Items;

public partial class MorphBall : AbstractItem
{
    protected override void CollectItem(Node body)
    {
        if (body is PlayerController playerController)
        {
            playerController.AbilityManager.hasMorphBall = true;
            
            ActivateItem(false);
        }
    }
}