using Godot;

namespace Metroid.Resources.Scripts.Items;

public abstract partial class AbstractItem : Area2D
{
    public override void _Ready()
    {
        BodyEntered += CollectItem;
    }
    
    protected abstract void CollectItem(Node body);

    protected void ActivateItem(bool setActive)
    {
        SetProcess(setActive);
        SetPhysicsProcess(setActive);

        if (!setActive)
            Hide();
    }
}