using System.Security.Cryptography;
using Entitas;
using UnityEngine;

namespace Script.ViewRender
{
    public interface IPhysicsView:IRenderView
    {
        Rigidbody2D Rigidbody2D { get; }

    }
}