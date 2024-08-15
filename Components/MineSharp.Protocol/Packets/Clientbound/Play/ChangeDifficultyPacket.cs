﻿using MineSharp.Core.Serialization;
using MineSharp.Data;
using MineSharp.Data.Protocol;
using static MineSharp.Protocol.Packets.Clientbound.Play.ChangeDifficultyPacket;

namespace MineSharp.Protocol.Packets.Clientbound.Play;

/// <summary>
///     Change difficulty packet
/// </summary>
/// <param name="Difficulty">The difficulty setting</param>
/// <param name="DifficultyLocked">Whether the difficulty is locked</param>
public sealed record ChangeDifficultyPacket(DifficultyLevel Difficulty, bool DifficultyLocked) : IPacketStatic<ChangeDifficultyPacket>
{
    /// <inheritdoc />
    public PacketType Type => StaticType;
    /// <inheritdoc />
    public static PacketType StaticType => PacketType.CB_Play_Difficulty;

    /// <inheritdoc />
    public void Write(PacketBuffer buffer, MinecraftData data)
    {
        buffer.Write((byte)Difficulty);
        buffer.WriteBool(DifficultyLocked);
    }

    /// <inheritdoc />
    public static ChangeDifficultyPacket Read(PacketBuffer buffer, MinecraftData data)
    {
        var difficulty = (DifficultyLevel)buffer.ReadByte();
        var difficultyLocked = buffer.ReadBool();

        return new ChangeDifficultyPacket(difficulty, difficultyLocked);
    }

    static IPacket IPacketStatic.Read(PacketBuffer buffer, MinecraftData data)
    {
        return Read(buffer, data);
    }

    /// <summary>
    ///     Enum representing the difficulty levels
    /// </summary>
    public enum DifficultyLevel : byte
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        Peaceful = 0,
        Easy = 1,
        Normal = 2,
        Hard = 3
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
