﻿using MineSharp.Core.Serialization;
using MineSharp.Data;
using MineSharp.Data.Protocol;

namespace MineSharp.Protocol.Packets.Serverbound.Play;
#pragma warning disable CS1591
public sealed record KeepAlivePacket(long KeepAliveId) : IPacket
{
    /// <inheritdoc />
    public PacketType Type => StaticType;
    /// <inheritdoc />
    public static PacketType StaticType => PacketType.SB_Play_KeepAlive;

    public void Write(PacketBuffer buffer, MinecraftData version)
    {
        buffer.WriteLong(KeepAliveId);
    }

    public static IPacket Read(PacketBuffer buffer, MinecraftData version)
    {
        var id = buffer.ReadLong();
        return new KeepAlivePacket(id);
    }
}
#pragma warning restore CS1591
