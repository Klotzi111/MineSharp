﻿using MineSharp.Core.Common;
using MineSharp.Data;
using MineSharp.Data.Protocol;

namespace MineSharp.Protocol.Packets.Clientbound.Play;
#pragma warning disable CS1591
public class EntityStatusPacket : IPacket
{
    public EntityStatusPacket(int entityId, byte status)
    {
        EntityId = entityId;
        Status = status;
    }

    public int EntityId { get; set; }
    public byte Status { get; set; }
    public PacketType Type => StaticType;
public static PacketType StaticType => PacketType.CB_Play_EntityStatus;

    public void Write(PacketBuffer buffer, MinecraftData version)
    {
        buffer.WriteVarInt(EntityId);
        buffer.WriteByte(Status);
    }

    public static IPacket Read(PacketBuffer buffer, MinecraftData version)
    {
        return new EntityStatusPacket(
            buffer.ReadInt(),
            buffer.ReadByte());
    }
}
#pragma warning restore CS1591
