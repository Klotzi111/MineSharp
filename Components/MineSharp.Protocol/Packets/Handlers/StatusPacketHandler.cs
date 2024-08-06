﻿using MineSharp.Core.Common.Protocol;
using MineSharp.Data.Protocol;

namespace MineSharp.Protocol.Packets.Handlers;

internal class StatusPacketHandler : GameStatePacketHandler
{
    private readonly MinecraftClient client;

    public StatusPacketHandler(MinecraftClient client)
        : base(GameState.Status)
    {
        this.client = client;
    }

    public override Task HandleIncoming(IPacket packet)
    {
        return Task.CompletedTask;
    }

    public override Task HandleOutgoing(IPacket packet)
    {
        return Task.CompletedTask;
    }

    public override bool HandlesIncoming(PacketType type)
    {
        return false;
    }
}
