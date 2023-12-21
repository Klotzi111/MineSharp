using MineSharp.Core.Common;
using MineSharp.Core.Common.Blocks;
using System.Diagnostics.CodeAnalysis;

namespace MineSharp.Data.BlockCollisionShapes;

public class BlockCollisionShapesProvider
{

    private BlockCollisionShapesVersion _version;
    
    internal BlockCollisionShapesProvider(BlockCollisionShapesVersion version)
    {
        this._version = version;
    }

    public int[] GetShapeIndices(BlockType type)
        => this._version.BlockToIndicesMap[type];

    public bool TryGetShapeIndices(BlockType type, [NotNullWhen(true)] out int[]? indices)
        => this._version.BlockToIndicesMap.TryGetValue(type, out indices);

    public AABB[] GetShapes(BlockType type, int index)
        => this._version.BlockShapes[GetShapeIndices(type)[index]]
            .Select(x => x.Clone())
            .ToArray();

    public AABB[] GetForBlock(Block block)
        => GetShapes(block.Info.Type, block.Metadata);
}
