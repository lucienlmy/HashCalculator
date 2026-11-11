using System.Security.Cryptography;

namespace HashCalculator;

// 实现：.NET（System.Security.Cryptography）
internal class Sha384 : BclHash
{
    public override int DigestLength => 48;

    public override string AlgoName => "SHA-384";

    public override AlgoType AlgoType => AlgoType.SHA_384;

    public override IHashAlgoInfo NewInstance()
    {
        return new Sha384();
    }

    public Sha384() : base(SHA384.Create()) { }
}
