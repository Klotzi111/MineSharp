﻿using MineSharp.Core;
using MineSharp.Core.Serialization;
using MineSharp.Data;
using MineSharp.Data.Protocol;

namespace MineSharp.Protocol.Packets.Clientbound.Play;

/// <summary>
///     Set Experience packet
/// </summary>
/// <param name="ExperienceBar">The experience bar value between 0 and 1</param>
/// <param name="Level">The experience level</param>
/// <param name="TotalExperience">The total experience points</param>
public abstract record SetExperiencePacket : IPacketStatic<SetExperiencePacket>
{
    /// <inheritdoc />
    public PacketType Type => StaticType;
    /// <inheritdoc />
    public static PacketType StaticType => PacketType.CB_Play_Experience;

    // all versions contain these fields:
    public abstract float ExperienceBar { get; init; }
    public abstract int Level { get; init; }
    public abstract int TotalExperience { get; init; }

    // may only be called from sub class in this class
    private SetExperiencePacket()
    {
    }

    public sealed record SetExperiencePacketV_1_7_0(float ExperienceBar, short ShortLevel, short ShortTotalExperience) : SetExperiencePacket, IPacketVersionSubTypeStatic<SetExperiencePacketV_1_7_0, SetExperiencePacket>
    {
        /// <inheritdoc />
        public ProtocolVersion FirstVersionUsed => FirstVersionUsedStatic;
        /// <inheritdoc />
        public static ProtocolVersion FirstVersionUsedStatic => ProtocolVersion.V_1_7_0;

        public override int Level
        {
            get
            {
                return ShortLevel;
            }
            init
            {
                ShortLevel = (short)value;
            }
        }
        public override int TotalExperience
        {
            get
            {
                return ShortTotalExperience;
            }
            init
            {
                ShortTotalExperience = (short)value;
            }
        }

        /// <inheritdoc />
        public override void Write(PacketBuffer buffer, MinecraftData data)
        {
            buffer.WriteFloat(ExperienceBar);
            buffer.WriteShort(ShortLevel);
            buffer.WriteShort(ShortTotalExperience);
        }

        /// <inheritdoc />
        public static new SetExperiencePacketV_1_7_0 Read(PacketBuffer buffer, MinecraftData data)
        {
            var experienceBar = buffer.ReadFloat();
            var level = buffer.ReadShort();
            var totalExperience = buffer.ReadShort();

            return new(experienceBar, level, totalExperience);
        }

        static IPacket IPacketVersionSubTypeStatic.Read(PacketBuffer buffer, MinecraftData data)
        {
            return Read(buffer, data);
        }

        static SetExperiencePacket IPacketVersionSubTypeStatic<SetExperiencePacket>.Read(PacketBuffer buffer, MinecraftData data)
        {
            return Read(buffer, data);
        }
    }

    // Level and TotalExperience become VarInt in 1.8.0
    public sealed record SetExperiencePacketV_1_8_0(float ExperienceBar, int Level, int TotalExperience) : SetExperiencePacket, IPacketVersionSubTypeStatic<SetExperiencePacketV_1_8_0, SetExperiencePacket>
    {
        /// <inheritdoc />
        public ProtocolVersion FirstVersionUsed => FirstVersionUsedStatic;
        /// <inheritdoc />
        public static ProtocolVersion FirstVersionUsedStatic => ProtocolVersion.V_1_8_0;

        /// <inheritdoc />
        public override void Write(PacketBuffer buffer, MinecraftData data)
        {
            buffer.WriteFloat(ExperienceBar);
            buffer.WriteVarInt(Level);
            buffer.WriteVarInt(TotalExperience);
        }

        /// <inheritdoc />
        public static new SetExperiencePacketV_1_8_0 Read(PacketBuffer buffer, MinecraftData data)
        {
            var experienceBar = buffer.ReadFloat();
            var level = buffer.ReadVarInt();
            var totalExperience = buffer.ReadVarInt();

            return new(experienceBar, level, totalExperience);
        }

        static IPacket IPacketVersionSubTypeStatic.Read(PacketBuffer buffer, MinecraftData data)
        {
            return Read(buffer, data);
        }

        static SetExperiencePacket IPacketVersionSubTypeStatic<SetExperiencePacket>.Read(PacketBuffer buffer, MinecraftData data)
        {
            return Read(buffer, data);
        }
    }

    // Level and TotalExperience are swapped in 1.19.3
    public sealed record SetExperiencePacketV_1_19_3(float ExperienceBar, int Level, int TotalExperience) : SetExperiencePacket, IPacketVersionSubTypeStatic<SetExperiencePacketV_1_19_3, SetExperiencePacket>
    {
        /// <inheritdoc />
        public ProtocolVersion FirstVersionUsed => FirstVersionUsedStatic;
        /// <inheritdoc />
        public static ProtocolVersion FirstVersionUsedStatic => ProtocolVersion.V_1_19_3;

        /// <inheritdoc />
        public override void Write(PacketBuffer buffer, MinecraftData data)
        {
            buffer.WriteFloat(ExperienceBar);
            buffer.WriteVarInt(TotalExperience);
            buffer.WriteVarInt(Level);
        }

        /// <inheritdoc />
        public static new SetExperiencePacketV_1_19_3 Read(PacketBuffer buffer, MinecraftData data)
        {
            var experienceBar = buffer.ReadFloat();
            var totalExperience = buffer.ReadVarInt();
            var level = buffer.ReadVarInt();

            return new(experienceBar, level, totalExperience);
        }

        static IPacket IPacketVersionSubTypeStatic.Read(PacketBuffer buffer, MinecraftData data)
        {
            return Read(buffer, data);
        }

        static SetExperiencePacket IPacketVersionSubTypeStatic<SetExperiencePacket>.Read(PacketBuffer buffer, MinecraftData data)
        {
            return Read(buffer, data);
        }
    }

    // Level and TotalExperience are swapped back again in 1.20.2
    public sealed record SetExperiencePacketV_1_20_2(float ExperienceBar, int Level, int TotalExperience) : SetExperiencePacket, IPacketVersionSubTypeStatic<SetExperiencePacketV_1_20_2, SetExperiencePacket>
    {
        /// <inheritdoc />
        public ProtocolVersion FirstVersionUsed => FirstVersionUsedStatic;
        /// <inheritdoc />
        public static ProtocolVersion FirstVersionUsedStatic => ProtocolVersion.V_1_20_2;

        /// <inheritdoc />
        public override void Write(PacketBuffer buffer, MinecraftData data)
        {
            buffer.WriteFloat(ExperienceBar);
            buffer.WriteVarInt(Level);
            buffer.WriteVarInt(TotalExperience);
        }

        /// <inheritdoc />
        public static new SetExperiencePacketV_1_20_2 Read(PacketBuffer buffer, MinecraftData data)
        {
            var experienceBar = buffer.ReadFloat();
            var level = buffer.ReadVarInt();
            var totalExperience = buffer.ReadVarInt();

            return new(experienceBar, level, totalExperience);
        }

        static IPacket IPacketVersionSubTypeStatic.Read(PacketBuffer buffer, MinecraftData data)
        {
            return Read(buffer, data);
        }

        static SetExperiencePacket IPacketVersionSubTypeStatic<SetExperiencePacket>.Read(PacketBuffer buffer, MinecraftData data)
        {
            return Read(buffer, data);
        }
    }

    public static readonly PacketVersionSubTypeLookup<SetExperiencePacket> PacketVersionSubTypeLookup = InitializeVersionPackets();

    private static PacketVersionSubTypeLookup<SetExperiencePacket> InitializeVersionPackets()
    {
        PacketVersionSubTypeLookup<SetExperiencePacket> lookup = new();

        lookup.RegisterVersionPacket<SetExperiencePacketV_1_7_0>();
        lookup.RegisterVersionPacket<SetExperiencePacketV_1_8_0>();
        lookup.RegisterVersionPacket<SetExperiencePacketV_1_19_3>();
        lookup.RegisterVersionPacket<SetExperiencePacketV_1_20_2>();

        lookup.Freeze();
        return lookup;
    }

    /// <inheritdoc />
    public abstract void Write(PacketBuffer buffer, MinecraftData data);

    /// <inheritdoc />
    public static SetExperiencePacket Read(PacketBuffer buffer, MinecraftData data)
    {
        return PacketVersionSubTypeLookup.Read(buffer, data);
    }

    static IPacket IPacketStatic.Read(PacketBuffer buffer, MinecraftData data)
    {
        return Read(buffer, data);
    }
}
