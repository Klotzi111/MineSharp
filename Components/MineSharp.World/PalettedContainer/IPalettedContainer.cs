﻿using MineSharp.Core.Types;
using MineSharp.Protocol.Packets;
using MineSharp.World.PalettedContainer.Palettes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSharp.World.PalettedContainer {
    public interface IPalettedContainer {

        public IPalette Palette { get; set; }
        public int Capacity { get; }
        public IntBitArray Data { get; set; }

        public static void Read(PacketBuffer buffer) {
            throw new NotImplementedException();
        }

        public int GetAt(int index);

        public void SetAt(int index, int state);
    }
}