using System;
using System.Security.Cryptography;

namespace HashCalculator;

/// <summary>
/// 把 .NET 基础类库（System.Security.Cryptography）中的 HashAlgorithm
/// 包装为 IHashAlgoInfo，使其能与原生库实现的算法走同一套调度流程。<br/>
/// 子类只需在构造函数里注入底层算法并给出 DigestLength、AlgoName、AlgoType，
/// Initialize、HashCore、HashFinal 均由本类转发给底层算法。
/// </summary>
internal abstract class BclHash : HashAlgorithm, IHashAlgoInfo
{
    private readonly HashAlgorithm algorithm;

    public BclHash(HashAlgorithm algorithm)
    {
        this.algorithm = algorithm;
    }

    public abstract int DigestLength { get; }

    public abstract string AlgoName { get; }

    public abstract AlgoType AlgoType { get; }

    public abstract IHashAlgoInfo NewInstance();

    public override void Initialize()
    {
        this.algorithm.Initialize();
    }

    // 包装的 .NET 算法为纯托管实现，没有需要一次性释放的非托管状态；
    // 其内部状态由 Initialize 复位。
    public void Release() { }

    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
        this.algorithm.TransformBlock(array, ibStart, cbSize, null, 0);
    }

    protected override byte[] HashFinal()
    {
        this.algorithm.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
        return this.algorithm.Hash;
    }
}
